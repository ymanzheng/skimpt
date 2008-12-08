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
        this.components = new System.ComponentModel.Container();
        this.lifeTimer = new System.Windows.Forms.Timer(this.components);
        this.fileNameLabel = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.hostingChoicesComboBox = new System.Windows.Forms.ComboBox();
        this.hostingPictureList = new System.Windows.Forms.ImageList(this.components);
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.effectsComboBox = new System.Windows.Forms.ComboBox();
        this.applyEffectButton = new SkimptControls.GlassButton();
        this.uploadToFtpButton = new SkimptControls.GlassButton();
        this.uploadToSiteButton = new SkimptControls.GlassButton();
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
        this.groupBox1.Location = new System.Drawing.Point(3, 28);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(302, 57);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Upload ";
        // 
        // hostingChoicesComboBox
        // 
        this.hostingChoicesComboBox.FormattingEnabled = true;
        this.hostingChoicesComboBox.Items.AddRange(new object[] {
            "Kalleload.net",
            "Imgpurse.com",
            "Imageshack.us",
            "Tinypic.com",
            "Imgcow.com"});
        this.hostingChoicesComboBox.Location = new System.Drawing.Point(18, 23);
        this.hostingChoicesComboBox.Name = "hostingChoicesComboBox";
        this.hostingChoicesComboBox.Size = new System.Drawing.Size(121, 26);
        this.hostingChoicesComboBox.TabIndex = 0;
        // 
        // hostingPictureList
        // 
        this.hostingPictureList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        this.hostingPictureList.ImageSize = new System.Drawing.Size(16, 16);
        this.hostingPictureList.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.applyEffectButton);
        this.groupBox2.Controls.Add(this.effectsComboBox);
        this.groupBox2.Location = new System.Drawing.Point(3, 91);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(302, 57);
        this.groupBox2.TabIndex = 7;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Effects";
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
        // applyEffectButton
        // 
        this.applyEffectButton.BackColor = System.Drawing.Color.GreenYellow;
        this.applyEffectButton.ForeColor = System.Drawing.Color.Maroon;
        this.applyEffectButton.Location = new System.Drawing.Point(145, 23);
        this.applyEffectButton.Name = "applyEffectButton";
        this.applyEffectButton.ShineColor = System.Drawing.Color.Chartreuse;
        this.applyEffectButton.Size = new System.Drawing.Size(148, 26);
        this.applyEffectButton.TabIndex = 2;
        this.applyEffectButton.Text = "apply selected effect";
        this.applyEffectButton.Click += new System.EventHandler(this.applyEffectButton_Click);
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
        // toastform
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(308, 155);
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
        this.Load += new System.EventHandler(this.toastform_Load);
        this.Activated += new System.EventHandler(this.toastform_Activated);
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.toastform_FormClosed);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.toastform_FormClosing);
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
    private System.Windows.Forms.ImageList hostingPictureList;
    private System.Windows.Forms.ComboBox hostingChoicesComboBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox effectsComboBox;
    private SkimptControls.GlassButton uploadToSiteButton;
    private SkimptControls.GlassButton uploadToFtpButton;
    private SkimptControls.GlassButton applyEffectButton;
}


