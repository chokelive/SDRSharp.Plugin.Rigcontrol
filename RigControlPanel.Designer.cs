
namespace SDRSharp.Plugin.RigControl
{
    partial class RigControlPanel
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
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.cbRig = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRigName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.bb_omniRigConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(93, 5);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(61, 19);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // cbRig
            // 
            this.cbRig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRig.FormattingEnabled = true;
            this.cbRig.Location = new System.Drawing.Point(4, 3);
            this.cbRig.Name = "cbRig";
            this.cbRig.Size = new System.Drawing.Size(69, 23);
            this.cbRig.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 15);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "RigName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Dev by E29AHU";
            // 
            // lblRigName
            // 
            this.lblRigName.AutoSize = true;
            this.lblRigName.Location = new System.Drawing.Point(96, 34);
            this.lblRigName.Name = "lblRigName";
            this.lblRigName.Size = new System.Drawing.Size(38, 15);
            this.lblRigName.TabIndex = 7;
            this.lblRigName.Text = "label6";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(96, 49);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "label7";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(96, 64);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(38, 15);
            this.lblFrequency.TabIndex = 9;
            this.lblFrequency.Text = "label8";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(96, 82);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(38, 15);
            this.lblMode.TabIndex = 10;
            this.lblMode.Text = "label9";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 129);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(38, 15);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "label6";
            // 
            // bb_omniRigConfig
            // 
            this.bb_omniRigConfig.Location = new System.Drawing.Point(4, 101);
            this.bb_omniRigConfig.Name = "bb_omniRigConfig";
            this.bb_omniRigConfig.Size = new System.Drawing.Size(103, 25);
            this.bb_omniRigConfig.TabIndex = 12;
            this.bb_omniRigConfig.Text = "OmniRig Config";
            this.bb_omniRigConfig.UseVisualStyleBackColor = true;
            this.bb_omniRigConfig.Click += new System.EventHandler(this.bb_omniRigConfig_Click);
            // 
            // RigControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bb_omniRigConfig);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRigName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbRig);
            this.Controls.Add(this.chkEnable);
            this.Name = "RigControlPanel";
            this.Size = new System.Drawing.Size(174, 153);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.ComboBox cbRig;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRigName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button bb_omniRigConfig;
    }
}