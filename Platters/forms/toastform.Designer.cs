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
        this.uploadtoFtpBtn = new System.Windows.Forms.Button();
        this.uploadBtn = new System.Windows.Forms.Button();
        this.hostingChoicesComboBox = new System.Windows.Forms.ComboBox();
        this.hostingPictureList = new System.Windows.Forms.ImageList(this.components);
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.applyEffectsButton = new System.Windows.Forms.Button();
        this.effectsComboBox = new System.Windows.Forms.ComboBox();
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
        this.groupBox1.Controls.Add(this.uploadtoFtpBtn);
        this.groupBox1.Controls.Add(this.uploadBtn);
        this.groupBox1.Controls.Add(this.hostingChoicesComboBox);
        this.groupBox1.Location = new System.Drawing.Point(3, 28);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(302, 57);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Upload ";
        // 
        // uploadtoFtpBtn
        // 
        this.uploadtoFtpBtn.Location = new System.Drawing.Point(217, 23);
        this.uploadtoFtpBtn.Name = "uploadtoFtpBtn";
        this.uploadtoFtpBtn.Size = new System.Drawing.Size(66, 26);
        this.uploadtoFtpBtn.TabIndex = 2;
        this.uploadtoFtpBtn.Text = "ftp";
        this.uploadtoFtpBtn.UseVisualStyleBackColor = true;
        this.uploadtoFtpBtn.Click += new System.EventHandler(this.uploadtoFtpBtn_Click);
        // 
        // uploadBtn
        // 
        this.uploadBtn.Location = new System.Drawing.Point(145, 24);
        this.uploadBtn.Name = "uploadBtn";
        this.uploadBtn.Size = new System.Drawing.Size(66, 26);
        this.uploadBtn.TabIndex = 1;
        this.uploadBtn.Text = "site";
        this.uploadBtn.UseVisualStyleBackColor = true;
        this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
        // 
        // hostingChoicesComboBox
        // 
        this.hostingChoicesComboBox.FormattingEnabled = true;
        this.hostingChoicesComboBox.Items.AddRange(new object[] {
            "Kalleload.com",
            "Imgpurse.com",
            "Imageshack.us",
            "Tinypic.com"});
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
        this.groupBox2.Controls.Add(this.applyEffectsButton);
        this.groupBox2.Controls.Add(this.effectsComboBox);
        this.groupBox2.Location = new System.Drawing.Point(3, 91);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(302, 57);
        this.groupBox2.TabIndex = 7;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Effects";
        // 
        // applyEffectsButton
        // 
        this.applyEffectsButton.Location = new System.Drawing.Point(145, 24);
        this.applyEffectsButton.Name = "applyEffectsButton";
        this.applyEffectsButton.Size = new System.Drawing.Size(66, 26);
        this.applyEffectsButton.TabIndex = 1;
        this.applyEffectsButton.Text = "apply";
        this.applyEffectsButton.UseVisualStyleBackColor = true;
        this.applyEffectsButton.Click += new System.EventHandler(this.applyEffectsButton_Click_1);
        // 
        // effectsComboBox
        // 
        this.effectsComboBox.FormattingEnabled = true;
        this.effectsComboBox.Items.AddRange(new object[] {
            "grayscale",
            "invert",
            "flip",
            "watermark"});
        this.effectsComboBox.Location = new System.Drawing.Point(18, 23);
        this.effectsComboBox.Name = "effectsComboBox";
        this.effectsComboBox.Size = new System.Drawing.Size(121, 26);
        this.effectsComboBox.TabIndex = 0;
        // 
        // toastform
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
    private System.Windows.Forms.Button uploadBtn;
    private System.Windows.Forms.Button uploadtoFtpBtn;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button applyEffectsButton;
    private System.Windows.Forms.ComboBox effectsComboBox;
}

