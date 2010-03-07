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
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.hostingChoicesComboBox = new System.Windows.Forms.ComboBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.effectsComboBox = new System.Windows.Forms.ComboBox();
        this.previewBox = new System.Windows.Forms.PictureBox();
        this.filetextbox = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.URLTextbox = new System.Windows.Forms.TextBox();
        this.optimizeImage = new System.Windows.Forms.CheckBox();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.saveImageButton = new SkimptControls.GlassButton();
        this.timerButton = new SkimptControls.GlassButton();
        this.applyEffectButton = new SkimptControls.GlassButton();
        this.uploadToSiteButton = new SkimptControls.GlassButton();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // lifeTimer
        // 
        this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.ForeColor = System.Drawing.SystemColors.Window;
        this.label1.Location = new System.Drawing.Point(12, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(38, 18);
        this.label1.TabIndex = 5;
        this.label1.Text = "File: ";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.uploadToSiteButton);
        this.groupBox1.Controls.Add(this.hostingChoicesComboBox);
        this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
        this.groupBox1.Location = new System.Drawing.Point(8, 215);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(217, 57);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Upload ";
        // 
        // hostingChoicesComboBox
        // 
        this.hostingChoicesComboBox.FormattingEnabled = true;
        this.hostingChoicesComboBox.Items.AddRange(new object[] {
            "Imgur.com"});
        this.hostingChoicesComboBox.Location = new System.Drawing.Point(6, 22);
        this.hostingChoicesComboBox.Name = "hostingChoicesComboBox";
        this.hostingChoicesComboBox.Size = new System.Drawing.Size(121, 26);
        this.hostingChoicesComboBox.TabIndex = 0;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.applyEffectButton);
        this.groupBox2.Controls.Add(this.effectsComboBox);
        this.groupBox2.ForeColor = System.Drawing.SystemColors.Window;
        this.groupBox2.Location = new System.Drawing.Point(8, 152);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(217, 57);
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
            "brightness",
            ""});
        this.effectsComboBox.Location = new System.Drawing.Point(6, 23);
        this.effectsComboBox.Name = "effectsComboBox";
        this.effectsComboBox.Size = new System.Drawing.Size(95, 26);
        this.effectsComboBox.TabIndex = 0;
        // 
        // previewBox
        // 
        this.previewBox.BackColor = System.Drawing.Color.White;
        this.previewBox.Location = new System.Drawing.Point(8, 64);
        this.previewBox.Name = "previewBox";
        this.previewBox.Size = new System.Drawing.Size(88, 64);
        this.previewBox.TabIndex = 8;
        this.previewBox.TabStop = false;
        // 
        // filetextbox
        // 
        this.filetextbox.Location = new System.Drawing.Point(56, 4);
        this.filetextbox.Name = "filetextbox";
        this.filetextbox.Size = new System.Drawing.Size(169, 25);
        this.filetextbox.TabIndex = 13;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.ForeColor = System.Drawing.SystemColors.Window;
        this.label2.Location = new System.Drawing.Point(12, 38);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(35, 18);
        this.label2.TabIndex = 14;
        this.label2.Text = "URL:";
        // 
        // URLTextbox
        // 
        this.URLTextbox.Location = new System.Drawing.Point(56, 35);
        this.URLTextbox.Name = "URLTextbox";
        this.URLTextbox.Size = new System.Drawing.Size(169, 25);
        this.URLTextbox.TabIndex = 15;
        // 
        // optimizeImage
        // 
        this.optimizeImage.AutoSize = true;
        this.optimizeImage.ForeColor = System.Drawing.SystemColors.Window;
        this.optimizeImage.Location = new System.Drawing.Point(14, 134);
        this.optimizeImage.Name = "optimizeImage";
        this.optimizeImage.Size = new System.Drawing.Size(211, 22);
        this.optimizeImage.TabIndex = 16;
        this.optimizeImage.Text = "compress before save/upload";
        this.optimizeImage.UseVisualStyleBackColor = true;
        this.optimizeImage.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        // 
        // backgroundWorker1
        // 
        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        // 
        // saveImageButton
        // 
        this.saveImageButton.Location = new System.Drawing.Point(102, 99);
        this.saveImageButton.Name = "saveImageButton";
        this.saveImageButton.Size = new System.Drawing.Size(123, 29);
        this.saveImageButton.TabIndex = 12;
        this.saveImageButton.Text = "save image";
        this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
        // 
        // timerButton
        // 
        this.timerButton.Location = new System.Drawing.Point(102, 64);
        this.timerButton.Name = "timerButton";
        this.timerButton.Size = new System.Drawing.Size(123, 29);
        this.timerButton.TabIndex = 11;
        this.timerButton.Text = "pause timer";
        this.timerButton.Click += new System.EventHandler(this.glassButton1_Click);
        // 
        // applyEffectButton
        // 
        this.applyEffectButton.BackColor = System.Drawing.Color.GreenYellow;
        this.applyEffectButton.ForeColor = System.Drawing.Color.Maroon;
        this.applyEffectButton.Location = new System.Drawing.Point(110, 22);
        this.applyEffectButton.Name = "applyEffectButton";
        this.applyEffectButton.ShineColor = System.Drawing.Color.Chartreuse;
        this.applyEffectButton.Size = new System.Drawing.Size(101, 26);
        this.applyEffectButton.TabIndex = 2;
        this.applyEffectButton.Text = "apply effect";
        this.applyEffectButton.Click += new System.EventHandler(this.applyEffectButton_Click);
        // 
        // uploadToSiteButton
        // 
        this.uploadToSiteButton.BackColor = System.Drawing.Color.Red;
        this.uploadToSiteButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.uploadToSiteButton.InnerBorderColor = System.Drawing.Color.Pink;
        this.uploadToSiteButton.Location = new System.Drawing.Point(133, 21);
        this.uploadToSiteButton.Name = "uploadToSiteButton";
        this.uploadToSiteButton.Size = new System.Drawing.Size(78, 26);
        this.uploadToSiteButton.TabIndex = 3;
        this.uploadToSiteButton.Text = "to site";
        this.uploadToSiteButton.Click += new System.EventHandler(this.uploadToSiteButton_Click);
        // 
        // toastform
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Black;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(233, 277);
        this.Controls.Add(this.optimizeImage);
        this.Controls.Add(this.URLTextbox);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.filetextbox);
        this.Controls.Add(this.saveImageButton);
        this.Controls.Add(this.timerButton);
        this.Controls.Add(this.previewBox);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.label1);
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
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox hostingChoicesComboBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox effectsComboBox;
    private SkimptControls.GlassButton uploadToSiteButton;
    private SkimptControls.GlassButton applyEffectButton;
    private System.Windows.Forms.PictureBox previewBox;
    private SkimptControls.GlassButton timerButton;
    private SkimptControls.GlassButton saveImageButton;
    private System.Windows.Forms.TextBox filetextbox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox URLTextbox;
    private System.Windows.Forms.CheckBox optimizeImage;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
}


