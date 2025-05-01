using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace File_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //cmbBaseSelection.Items.Add("Base-16 (Hex)");
            //cmbBaseSelection.Items.Add("Base-64");
            cmbBaseSelection.SelectedIndex = 0; // Default to Hex
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private readonly Dictionary<string, string> fileSignatures = new Dictionary<string, string>
{
    { "FFD8FF", "JPEG" },       // JPEG Image
    { "89504E47", "PNG" },      // PNG Image
    { "25504446", "PDF" },      // PDF Document
    { "504B0304", "ZIP" },      // ZIP Archive
    { "47494638", "GIF" }       // GIF Image
};

        private string GetFileType(string filePath)
        {
            byte[] fileHeader = new byte[8]; // Read more bytes for better detection
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Read(fileHeader, 0, fileHeader.Length);
            }

            string fileHeaderHex = BitConverter.ToString(fileHeader).Replace("-", "");

            foreach (var signature in fileSignatures)
            {
                if (fileHeaderHex.StartsWith(signature.Key))
                {
                    return signature.Value;
                }
            }

            return "Unknown";
        }

        private bool DoesExtensionMatchType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            string fileType = GetFileType(filePath);

            var extensionToType = new Dictionary<string, string>
    {
        { ".jpg", "JPEG" },
        { ".jpeg", "JPEG" },
        { ".png", "PNG" },
        { ".pdf", "PDF" },
        { ".zip", "ZIP" },
        { ".jar", "ZIP" },
        { ".gif", "GIF" }
    };

            // Debug output
            MessageBox.Show($"File Path: {filePath}\nDetected File Type: {fileType}\nExtension: {extension}");

            return extensionToType.TryGetValue(extension, out string expectedType) && expectedType == fileType;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();
                string fileType = GetFileType(filePath);

                // Map extensions to types
                var extensionToType = new Dictionary<string, string>
        {
            { ".jpg", "JPEG" },
            { ".jpeg", "JPEG" },
            { ".png", "PNG" },
            { ".pdf", "PDF" },
            { ".zip", "ZIP" },
            { ".jar", "ZIP" },
            { ".gif", "GIF" }
        };

                // Check if extension matches file type
                bool isMatch = extensionToType.TryGetValue(extension, out string expectedType) && expectedType == fileType;

                // Build the message to display
                string resultMessage = $"File Path: {filePath}\n";
                resultMessage += $"Detected File Type: {fileType}\n";
                resultMessage += $"Extension: {extension}\n";
                resultMessage += isMatch ? "The file type matches the extension." : "The file type does NOT match the extension.\n" +
                    "Consider deleting this file.";

                // Show the message
                MessageBox.Show(resultMessage, "File Type and Extension Check");
            }
        }



        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                string inputText = txtHexInput.Text.Trim();
                string selectedBase = cmbBaseSelection.SelectedItem.ToString();

                if (selectedBase == "Base-16 (Hex)")
                {
                    txtAsciiOutput.Text = HexToAscii(inputText);
                }
                else if (selectedBase == "Base-64")
                {
                    txtAsciiOutput.Text = Base64ToAscii(inputText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HexToAscii(string hex)
        {
            hex = hex.Replace(" ", ""); // Remove spaces
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex input must have an even number of characters.");

            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return Encoding.ASCII.GetString(raw);
        }

        private string Base64ToAscii(string base64)
        {
            try
            {
                base64 = base64.Trim(); // Remove unnecessary spaces
                byte[] bytes = Convert.FromBase64String(base64);
                return Encoding.ASCII.GetString(bytes);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid Base64 format. Ensure the input is correctly formatted.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}