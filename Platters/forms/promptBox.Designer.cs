namespace Skimpt.forms
{
    partial class promptBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.promptButtonEnter = new System.Windows.Forms.Button();
            this.userInput = new System.Windows.Forms.TextBox();
            this.promptButtonBrowse = new System.Windows.Forms.Button();
            this.promptBoxLabel = new System.Windows.Forms.Label();
            this.promtBoxBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // promptButtonEnter
            // 
            this.promptButtonEnter.Location = new System.Drawing.Point(235, 78);
            this.promptButtonEnter.Name = "promptButtonEnter";
            this.promptButtonEnter.Size = new System.Drawing.Size(59, 30);
            this.promptButtonEnter.TabIndex = 0;
            this.promptButtonEnter.Text = "button1";
            this.promptButtonEnter.UseVisualStyleBackColor = true;
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(28, 42);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(449, 20);
            this.userInput.TabIndex = 1;
            // 
            // promptButtonBrowse
            // 
            this.promptButtonBrowse.Location = new System.Drawing.Point(494, 42);
            this.promptButtonBrowse.Name = "promptButtonBrowse";
            this.promptButtonBrowse.Size = new System.Drawing.Size(35, 20);
            this.promptButtonBrowse.TabIndex = 2;
            this.promptButtonBrowse.Text = "button1";
            this.promptButtonBrowse.UseVisualStyleBackColor = true;
            // 
            // promptBoxLabel
            // 
            this.promptBoxLabel.AutoSize = true;
            this.promptBoxLabel.Location = new System.Drawing.Point(31, 21);
            this.promptBoxLabel.Name = "promptBoxLabel";
            this.promptBoxLabel.Size = new System.Drawing.Size(35, 13);
            this.promptBoxLabel.TabIndex = 3;
            this.promptBoxLabel.Text = "label1";
            this.promptBoxLabel.Click += new System.EventHandler(this.promptBoxLabel_Click);
            // 
            // promtBoxBrowseDialog
            // 
            this.promtBoxBrowseDialog.SelectedPath = "C:\\";
            // 
            // promptBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(555, 112);
            this.Controls.Add(this.promptBoxLabel);
            this.Controls.Add(this.promptButtonBrowse);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.promptButtonEnter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(300, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "promptBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "promptBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.promptBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button promptButtonEnter;
        public System.Windows.Forms.TextBox userInput;
        public System.Windows.Forms.Button promptButtonBrowse;
        public System.Windows.Forms.Label promptBoxLabel;
        private System.Windows.Forms.FolderBrowserDialog promtBoxBrowseDialog;

    }
}