namespace LiveSplit.UI.Components
{
    partial class ObsPipeSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPipeName = new System.Windows.Forms.Label();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.txtEnableZeroCopy = new System.Windows.Forms.Label();
            this.chkEnableZeroCopy = new System.Windows.Forms.CheckBox();
            this.txtBufferCount = new System.Windows.Forms.Label();
            this.nudBufferCount = new System.Windows.Forms.NumericUpDown();
            this.txtStatus = new System.Windows.Forms.Label();
            this.txtStatusValue = new System.Windows.Forms.Label();
            this.txtImageFormat = new System.Windows.Forms.Label();
            this.cbbImageFormat = new System.Windows.Forms.ComboBox();
            this.txtCompression = new System.Windows.Forms.Label();
            this.chkCompression = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPipeName
            // 
            this.txtPipeName.AutoSize = true;
            this.txtPipeName.Location = new System.Drawing.Point(43, 13);
            this.txtPipeName.Name = "txtPipeName";
            this.txtPipeName.Size = new System.Drawing.Size(62, 13);
            this.txtPipeName.TabIndex = 0;
            this.txtPipeName.Text = "Pipe Name:";
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(111, 10);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(148, 20);
            this.tbPipeName.TabIndex = 1;
            // 
            // txtEnableZeroCopy
            // 
            this.txtEnableZeroCopy.AutoSize = true;
            this.txtEnableZeroCopy.Location = new System.Drawing.Point(10, 43);
            this.txtEnableZeroCopy.Name = "txtEnableZeroCopy";
            this.txtEnableZeroCopy.Size = new System.Drawing.Size(95, 13);
            this.txtEnableZeroCopy.TabIndex = 2;
            this.txtEnableZeroCopy.Text = "Enable Zero Copy:";
            // 
            // chkEnableZeroCopy
            // 
            this.chkEnableZeroCopy.AutoSize = true;
            this.chkEnableZeroCopy.Location = new System.Drawing.Point(111, 43);
            this.chkEnableZeroCopy.Name = "chkEnableZeroCopy";
            this.chkEnableZeroCopy.Size = new System.Drawing.Size(15, 14);
            this.chkEnableZeroCopy.TabIndex = 3;
            this.chkEnableZeroCopy.UseVisualStyleBackColor = true;
            // 
            // txtBufferCount
            // 
            this.txtBufferCount.AutoSize = true;
            this.txtBufferCount.Location = new System.Drawing.Point(36, 71);
            this.txtBufferCount.Name = "txtBufferCount";
            this.txtBufferCount.Size = new System.Drawing.Size(69, 13);
            this.txtBufferCount.TabIndex = 4;
            this.txtBufferCount.Text = "Buffer Count:";
            // 
            // nudBufferCount
            // 
            this.nudBufferCount.Location = new System.Drawing.Point(111, 69);
            this.nudBufferCount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBufferCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBufferCount.Name = "nudBufferCount";
            this.nudBufferCount.Size = new System.Drawing.Size(42, 20);
            this.nudBufferCount.TabIndex = 5;
            this.nudBufferCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(65, 157);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(40, 13);
            this.txtStatus.TabIndex = 6;
            this.txtStatus.Text = "Status:";
            // 
            // txtStatusValue
            // 
            this.txtStatusValue.Location = new System.Drawing.Point(111, 157);
            this.txtStatusValue.Name = "txtStatusValue";
            this.txtStatusValue.Size = new System.Drawing.Size(355, 50);
            this.txtStatusValue.TabIndex = 7;
            this.txtStatusValue.Text = "status";
            // 
            // txtImageFormat
            // 
            this.txtImageFormat.AutoSize = true;
            this.txtImageFormat.Location = new System.Drawing.Point(31, 101);
            this.txtImageFormat.Name = "txtImageFormat";
            this.txtImageFormat.Size = new System.Drawing.Size(74, 13);
            this.txtImageFormat.TabIndex = 8;
            this.txtImageFormat.Text = "Image Format:";
            // 
            // cbbImageFormat
            // 
            this.cbbImageFormat.FormattingEnabled = true;
            this.cbbImageFormat.Location = new System.Drawing.Point(111, 98);
            this.cbbImageFormat.Name = "cbbImageFormat";
            this.cbbImageFormat.Size = new System.Drawing.Size(148, 21);
            this.cbbImageFormat.TabIndex = 9;
            this.cbbImageFormat.SelectedIndexChanged += new System.EventHandler(this.cbbImageFormat_SelectedIndexChanged);
            // 
            // txtCompression
            // 
            this.txtCompression.AutoSize = true;
            this.txtCompression.Location = new System.Drawing.Point(35, 131);
            this.txtCompression.Name = "txtCompression";
            this.txtCompression.Size = new System.Drawing.Size(70, 13);
            this.txtCompression.TabIndex = 10;
            this.txtCompression.Text = "Compression:";
            // 
            // chkCompression
            // 
            this.chkCompression.AutoSize = true;
            this.chkCompression.Location = new System.Drawing.Point(111, 131);
            this.chkCompression.Name = "chkCompression";
            this.chkCompression.Size = new System.Drawing.Size(15, 14);
            this.chkCompression.TabIndex = 11;
            this.chkCompression.UseVisualStyleBackColor = true;
            // 
            // ObsPipeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCompression);
            this.Controls.Add(this.txtCompression);
            this.Controls.Add(this.cbbImageFormat);
            this.Controls.Add(this.txtImageFormat);
            this.Controls.Add(this.txtStatusValue);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.nudBufferCount);
            this.Controls.Add(this.txtBufferCount);
            this.Controls.Add(this.chkEnableZeroCopy);
            this.Controls.Add(this.txtEnableZeroCopy);
            this.Controls.Add(this.tbPipeName);
            this.Controls.Add(this.txtPipeName);
            this.Name = "ObsPipeSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 453);
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtPipeName;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Label txtEnableZeroCopy;
        private System.Windows.Forms.CheckBox chkEnableZeroCopy;
        private System.Windows.Forms.Label txtBufferCount;
        private System.Windows.Forms.NumericUpDown nudBufferCount;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label txtStatusValue;
        private System.Windows.Forms.Label txtImageFormat;
        private System.Windows.Forms.ComboBox cbbImageFormat;
        private System.Windows.Forms.Label txtCompression;
        private System.Windows.Forms.CheckBox chkCompression;
    }
}
