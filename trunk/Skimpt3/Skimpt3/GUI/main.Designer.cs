namespace Skimpt3.GUI
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.glassButton1 = new SkimptControls.GlassButton();
            this.hightlightButton = new SkimptControls.GlassButton();
            this.cameraButton = new SkimptControls.GlassButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // glassButton1
            // 
            this.glassButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.glassButton1.FadeOnFocus = true;
            this.glassButton1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton1.ForeColor = System.Drawing.Color.Black;
            this.glassButton1.Location = new System.Drawing.Point(12, 108);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.ShineColor = System.Drawing.Color.LimeGreen;
            this.glassButton1.Size = new System.Drawing.Size(168, 36);
            this.glassButton1.TabIndex = 7;
            this.glassButton1.Text = "Options";
            // 
            // hightlightButton
            // 
            this.hightlightButton.BackColor = System.Drawing.Color.SteelBlue;
            this.hightlightButton.FadeOnFocus = true;
            this.hightlightButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hightlightButton.ForeColor = System.Drawing.Color.Black;
            this.hightlightButton.Location = new System.Drawing.Point(12, 66);
            this.hightlightButton.Name = "hightlightButton";
            this.hightlightButton.ShineColor = System.Drawing.Color.SkyBlue;
            this.hightlightButton.Size = new System.Drawing.Size(168, 36);
            this.hightlightButton.TabIndex = 5;
            this.hightlightButton.Text = "Highlight mode";
            // 
            // cameraButton
            // 
            this.cameraButton.BackColor = System.Drawing.Color.DarkViolet;
            this.cameraButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraButton.ForeColor = System.Drawing.Color.Black;
            this.cameraButton.Location = new System.Drawing.Point(12, 24);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.ShineColor = System.Drawing.Color.Thistle;
            this.cameraButton.Size = new System.Drawing.Size(168, 36);
            this.cameraButton.TabIndex = 6;
            this.cameraButton.Text = "Camera Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 178);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glassButton1);
            this.Controls.Add(this.hightlightButton);
            this.Controls.Add(this.cameraButton);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(200, 180);
            this.Name = "main";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Skimpt3";           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SkimptControls.GlassButton cameraButton;
        private SkimptControls.GlassButton hightlightButton;
        private SkimptControls.GlassButton glassButton1;
        private System.Windows.Forms.Label label1;

    }
}