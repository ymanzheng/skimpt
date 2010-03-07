namespace Skimpt3.GUI {
    partial class Options {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label4 = new System.Windows.Forms.Label();
            this.apiTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultImageText = new System.Windows.Forms.TextBox();
            this.errorMessagecheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.optimizeImageCheckBox = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.removeContext = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(403, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Are you uploading to IMGUR.COM? If so, I need your API key:";
            // 
            // apiTextBox
            // 
            this.apiTextBox.Location = new System.Drawing.Point(16, 40);
            this.apiTextBox.Name = "apiTextBox";
            this.apiTextBox.Size = new System.Drawing.Size(399, 20);
            this.apiTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Where do you want your images to be saved?";
            // 
            // defaultImageText
            // 
            this.defaultImageText.Location = new System.Drawing.Point(16, 94);
            this.defaultImageText.Name = "defaultImageText";
            this.defaultImageText.Size = new System.Drawing.Size(314, 20);
            this.defaultImageText.TabIndex = 9;
            // 
            // errorMessagecheckBox
            // 
            this.errorMessagecheckBox.AutoSize = true;
            this.errorMessagecheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessagecheckBox.ForeColor = System.Drawing.SystemColors.Control;
            this.errorMessagecheckBox.Location = new System.Drawing.Point(16, 194);
            this.errorMessagecheckBox.Name = "errorMessagecheckBox";
            this.errorMessagecheckBox.Size = new System.Drawing.Size(240, 23);
            this.errorMessagecheckBox.TabIndex = 10;
            this.errorMessagecheckBox.Text = "Show all cryptic error messages?";
            this.errorMessagecheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(246, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "Submit!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(348, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 36);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel!";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(439, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "How long do you want your image processing form to be open for?";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AsciiOnly = true;
            this.maskedTextBox1.Location = new System.Drawing.Point(16, 151);
            this.maskedTextBox1.Mask = "00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(399, 20);
            this.maskedTextBox1.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(337, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // optimizeImageCheckBox
            // 
            this.optimizeImageCheckBox.AutoSize = true;
            this.optimizeImageCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optimizeImageCheckBox.ForeColor = System.Drawing.SystemColors.Control;
            this.optimizeImageCheckBox.Location = new System.Drawing.Point(271, 194);
            this.optimizeImageCheckBox.Name = "optimizeImageCheckBox";
            this.optimizeImageCheckBox.Size = new System.Drawing.Size(144, 23);
            this.optimizeImageCheckBox.TabIndex = 16;
            this.optimizeImageCheckBox.Text = "Optimize images?";
            this.optimizeImageCheckBox.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Info;
            this.button4.Location = new System.Drawing.Point(33, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 36);
            this.button4.TabIndex = 17;
            this.button4.Text = "Create Context Menu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // removeContext
            // 
            this.removeContext.AutoSize = true;
            this.removeContext.Location = new System.Drawing.Point(12, 249);
            this.removeContext.Name = "removeContext";
            this.removeContext.Size = new System.Drawing.Size(15, 14);
            this.removeContext.TabIndex = 18;
            this.removeContext.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(456, 297);
            this.Controls.Add(this.removeContext);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.optimizeImageCheckBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorMessagecheckBox);
            this.Controls.Add(this.defaultImageText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apiTextBox);
            this.Controls.Add(this.label4);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apiTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox defaultImageText;
        private System.Windows.Forms.CheckBox errorMessagecheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox optimizeImageCheckBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox removeContext;


    }
}