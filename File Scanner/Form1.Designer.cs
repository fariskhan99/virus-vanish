namespace File_Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            txtHexInput = new TextBox();
            btnConvert = new Button();
            txtAsciiOutput = new TextBox();
            cmbBaseSelection = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 204);
            label1.Name = "label1";
            label1.Size = new Size(292, 20);
            label1.TabIndex = 0;
            label1.Text = "Files will be scanned for potential malware";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(209, 146);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Upload Files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(324, 597);
            label2.Name = "label2";
            label2.Size = new Size(509, 20);
            label2.TabIndex = 2;
            label2.Text = "*VirusVanishLLC is not responsible for computers spontaneously combusting";
            // 
            // txtHexInput
            // 
            txtHexInput.Location = new Point(899, 111);
            txtHexInput.Name = "txtHexInput";
            txtHexInput.Size = new Size(125, 27);
            txtHexInput.TabIndex = 3;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(917, 214);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(94, 29);
            btnConvert.TabIndex = 4;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // txtAsciiOutput
            // 
            txtAsciiOutput.Location = new Point(899, 265);
            txtAsciiOutput.Name = "txtAsciiOutput";
            txtAsciiOutput.ReadOnly = true;
            txtAsciiOutput.Size = new Size(125, 27);
            txtAsciiOutput.TabIndex = 5;
            // 
            // cmbBaseSelection
            // 
            cmbBaseSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBaseSelection.FormattingEnabled = true;
            cmbBaseSelection.Items.AddRange(new object[] { "Base-16 (Hex)", "Base-64" });
            cmbBaseSelection.Location = new Point(885, 159);
            cmbBaseSelection.Name = "cmbBaseSelection";
            cmbBaseSelection.Size = new Size(151, 28);
            cmbBaseSelection.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(850, 76);
            label3.Name = "label3";
            label3.Size = new Size(234, 20);
            label3.TabIndex = 7;
            label3.Text = "Base 16 and 64 to ASCII Converter";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 635);
            Controls.Add(label3);
            Controls.Add(cmbBaseSelection);
            Controls.Add(txtAsciiOutput);
            Controls.Add(btnConvert);
            Controls.Add(txtHexInput);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "FileScan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox txtHexInput;
        private Button btnConvert;
        private TextBox txtAsciiOutput;
        private ComboBox cmbBaseSelection;
        private Label label3;
    }
}
