partial class toastform
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
        this.lifeTimer = new System.Windows.Forms.Timer();
        this.fileNameLabel = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.uploadToFtpButton = new SkimptControls.GlassButton();
        this.uploadToSiteButton = new SkimptControls.GlassButton();
        this.hostingChoicesComboBox = new System.Windows.Forms.ComboBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.applyEffectButton = new SkimptControls.GlassButton();
        this.effectsComboBox = new System.Windows.Forms.ComboBox();
        this.previewBox = new System.Windows.Forms.PictureBox();
        this.optimizeImageCheckbox = new System.Windows.Forms.CheckBox();
        this.timerButton = new SkimptControls.GlassButton();
        this.saveImageButton = new SkimptControls.GlassButton();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // lifeTimer
        // 
        this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
        // 
        // fileNameLabel
        // 
        this.fileNameLabel.AutoSize = true;
        this.fileNameLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fileNameLabel.ForeColor = System.Drawing.Color.Blue;
        this.fileNameLabel.Location = new System.Drawing.Point(48, 7);
        this.fileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.fileNameLabel.Name = "fileNameLabel";
        this.fileNameLabel.Size = new System.Drawing.Size(15, 18);
        this.fileNameLabel.TabIndex = 4;
        this.fileNameLabel.Text = "#";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(38, 18);
        this.label1.TabIndex = 5;
        this.label1.Text = "File: ";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.uploadToFtpButton);
        this.groupBox1.Controls.Add(this.uploadToSiteButton);
        this.groupBox1.Controls.Add(this.hostingChoicesComboBox);
        this.groupBox1.Location = new System.Drawing.Point(15, 194);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(348, 57);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Upload ";
        // 
        // uploadToFtpButton
        // 
        this.uploadToFtpButton.BackColor = System.Drawing.Color.Pink;
        this.uploadToFtpButton.ForeColor = System.Drawing.Color.Black;
        this.uploadToFtpButton.InnerBorderColor = System.Drawing.Color.Red;
        this.uploadToFtpButton.Location = new System.Drawing.Point(221, 22);
        this.uploadToFtpButton.Name = "uploadToFtpButton";
        this.uploadToFtpButton.Size = new System.Drawing.Size(75, 26);
        this.uploadToFtpButton.TabIndex = 8;
        this.uploadToFtpButton.Text = "to ftp";
        this.uploadToFtpButton.Click += new System.EventHandler(this.uploadToFtpButton_Click);
        // 
        // uploadToSiteButton
        // 
        this.uploadToSiteButton.BackColor = System.Drawing.Color.Red;
        this.uploadToSiteButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.uploadToSiteButton.InnerBorderColor = System.Drawing.Color.Pink;
        this.uploadToSiteButton.Location = new System.Drawing.Point(145, 22);
        this.uploadToSiteButton.Name = "uploadToSiteButton";
        this.uploadToSiteButton.Size = new System.Drawing.Size(75, 26);
        this.uploadToSiteButton.TabIndex = 3;
        this.uploadToSiteButton.Text = "to site";
        this.uploadToSiteButton.Click += new System.EventHandler(this.uploadToSiteButton_Click);
        // 
        // hostingChoicesComboBox
        // 
        this.hostingChoicesComboBox.FormattingEnabled = true;
        this.hostingChoicesComboBox.Items.AddRange(new object[] {
            "Imgur.com"});
        this.hostingChoicesComboBox.Location = new System.Drawing.Point(18, 23);
        this.hostingChoicesComboBox.Name = "hostingChoicesComboBox";
        this.hostingChoicesComboBox.Size = new System.Drawing.Size(121, 26);
        this.hostingChoicesComboBox.TabIndex = 0;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.applyEffectButton);
        this.groupBox2.Controls.Add(this.effectsComboBox);
        this.groupBox2.Location = new System.Drawing.Point(15, 129);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(348, 57);
        this.groupBox2.TabIndex = 7;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Effects";
        // 
        // applyEffectButton
        // 
        this.applyEffectButton.BackColor = System.Drawing.Color.GreenYellow;
        this.applyEffectButton.ForeColor = System.Drawing.Color.Maroon;
        this.applyEffectButton.Location = new System.Drawing.Point(148, 22);
        this.applyEffectButton.Name = "applyEffectButton";
        this.applyEffectButton.ShineColor = System.Drawing.Color.Chartreuse;
        this.applyEffectButton.Size = new System.Drawing.Size(148, 26);
        this.applyEffectButton.TabIndex = 2;
        this.applyEffectButton.Text = "apply selected effect";
        this.applyEffectButton.Click += new System.EventHandler(this.applyEffectButton_Click);
        // 
        // effectsComboBox
        // 
        this.effectsComboBox.FormattingEnabled = true;
        this.effectsComboBox.Items.AddRange(new object[] {
            "grayscale",
            "invert",
            "flip",
            "watermark",
            "brightness"});
        this.effectsComboBox.Location = new System.Drawing.Point(18, 23);
        this.effectsComboBox.Name = "effectsComboBox";
        this.effectsComboBox.Size = new System.Drawing.Size(121, 26);
        this.effectsComboBox.TabIndex = 0;
        // 
        // previewBox
        // 
        this.previewBox.Location = new System.Drawing.Point(15, 28);
        this.previewBox.Name = "previewBox";
        this.previewBox.Size = new System.Drawing.Size(100, 100);
        this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.previewBox.TabIndex = 8;
        this.previewBox.TabStop = false;
        // 
        // optimizeImageCheckbox
        // 
        this.optimizeImageCheckbox.AutoSize = true;
        this.optimizeImageCheckbox.Location = new System.Drawing.Point(121, 28);
        this.optimizeImageCheckbox.Name = "optimizeImageCheckbox";
        this.optimizeImageCheckbox.Size = new System.Drawing.Size(242, 22);
        this.optimizeImageCheckbox.TabIndex = 9;
        this.optimizeImageCheckbox.Text = "Optimize Image before uploading?";
        this.optimizeImageCheckbox.UseVisualStyleBackColor = true;
        // 
        // timerButton
        // 
        this.timerButton.Location = new System.Drawing.Point(121, 56);
        this.timerButton.Name = "timerButton";
        this.timerButton.Size = new System.Drawing.Size(241, 29);
        this.timerButton.TabIndex = 11;
        this.timerButton.Text = "pause timer";
        this.timerButton.Click += new System.EventHandler(this.glassButton1_Click);
        // 
        // saveImageButton
        // 
        this.saveImageButton.Location = new System.Drawing.Point(121, 94);
        this.saveImageButton.Name = "saveImageButton";
        this.saveImageButton.Size = new System.Drawing.Size(241, 29);
        this.saveImageButton.TabIndex = 12;
        this.saveImageButton.Text = "save image";
        this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
        // 
        // toastform
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(375, 263);
        this.Controls.Add(this.saveImageButton);
        this.Controls.Add(this.timerButton);
        this.Controls.Add(this.optimizeImageCheckbox);
        this.Controls.Add(this.previewBox);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.fileNameLabel);
        this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "toastform";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "Picture Options";
        this.TopMost = true;
        this.Activated += new System.EventHandler(this.toastform_Activated);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.toastform_FormClosing);
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.toastform_FormClosed);
        this.Load += new System.EventHandler(this.toastform_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox2.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer lifeTimer;
    private System.Windows.Forms.Label fileNameLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox hostingChoicesComboBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox effectsComboBox;
    private SkimptControls.GlassButton uploadToSiteButton;
    private SkimptControls.GlassButton uploadToFtpButton;
    private SkimptControls.GlassButton applyEffectButton;
    private System.Windows.Forms.PictureBox previewBox;
    private System.Windows.Forms.CheckBox optimizeImageCheckbox;
    private SkimptControls.GlassButton timerButton;
    private SkimptControls.GlassButton saveImageButton;
}


