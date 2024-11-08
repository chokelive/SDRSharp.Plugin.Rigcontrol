
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
            chkEnable = new System.Windows.Forms.CheckBox();
            cbRig = new System.Windows.Forms.ComboBox();
            Label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lblRigName = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            lblFrequency = new System.Windows.Forms.Label();
            lblMode = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            bb_omniRigConfig = new System.Windows.Forms.Button();
            chkSyncRigToSdr = new System.Windows.Forms.CheckBox();
            chkSyncdrToRig = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // chkEnable
            // 
            chkEnable.AutoSize = true;
            chkEnable.Location = new System.Drawing.Point(93, 5);
            chkEnable.Name = "chkEnable";
            chkEnable.Size = new System.Drawing.Size(61, 19);
            chkEnable.TabIndex = 0;
            chkEnable.Text = "Enable";
            chkEnable.UseVisualStyleBackColor = true;
            chkEnable.CheckedChanged += chkEnable_CheckedChanged;
            // 
            // cbRig
            // 
            cbRig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbRig.FormattingEnabled = true;
            cbRig.Location = new System.Drawing.Point(4, 3);
            cbRig.Name = "cbRig";
            cbRig.Size = new System.Drawing.Size(69, 23);
            cbRig.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(3, 32);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(56, 15);
            Label1.TabIndex = 2;
            Label1.Text = "RigName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 15);
            label3.TabIndex = 4;
            label3.Text = "Frequency";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 82);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 15);
            label4.TabIndex = 5;
            label4.Text = "Mode";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(49, 186);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 15);
            label5.TabIndex = 6;
            label5.Text = "Dev by E29AHU";
            // 
            // lblRigName
            // 
            lblRigName.AutoSize = true;
            lblRigName.Location = new System.Drawing.Point(96, 34);
            lblRigName.Name = "lblRigName";
            lblRigName.Size = new System.Drawing.Size(38, 15);
            lblRigName.TabIndex = 7;
            lblRigName.Text = "label6";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(96, 49);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(38, 15);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "label7";
            // 
            // lblFrequency
            // 
            lblFrequency.AutoSize = true;
            lblFrequency.Location = new System.Drawing.Point(96, 64);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new System.Drawing.Size(38, 15);
            lblFrequency.TabIndex = 9;
            lblFrequency.Text = "label8";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new System.Drawing.Point(96, 82);
            lblMode.Name = "lblMode";
            lblMode.Size = new System.Drawing.Size(38, 15);
            lblMode.TabIndex = 10;
            lblMode.Text = "label9";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(5, 186);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(38, 15);
            lblVersion.TabIndex = 11;
            lblVersion.Text = "label6";
            // 
            // bb_omniRigConfig
            // 
            bb_omniRigConfig.Location = new System.Drawing.Point(3, 147);
            bb_omniRigConfig.Name = "bb_omniRigConfig";
            bb_omniRigConfig.Size = new System.Drawing.Size(103, 25);
            bb_omniRigConfig.TabIndex = 12;
            bb_omniRigConfig.Text = "OmniRig Config";
            bb_omniRigConfig.UseVisualStyleBackColor = true;
            bb_omniRigConfig.Click += bb_omniRigConfig_Click;
            // 
            // chkSyncRigToSdr
            // 
            chkSyncRigToSdr.AutoSize = true;
            chkSyncRigToSdr.Checked = true;
            chkSyncRigToSdr.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSyncRigToSdr.Location = new System.Drawing.Point(5, 101);
            chkSyncRigToSdr.Name = "chkSyncRigToSdr";
            chkSyncRigToSdr.Size = new System.Drawing.Size(109, 19);
            chkSyncRigToSdr.TabIndex = 13;
            chkSyncRigToSdr.Text = "Sync Rig to SDR";
            chkSyncRigToSdr.UseVisualStyleBackColor = true;
            chkSyncRigToSdr.CheckedChanged += chkSyncRigToSdr_CheckedChanged;
            // 
            // chkSyncdrToRig
            // 
            chkSyncdrToRig.AutoSize = true;
            chkSyncdrToRig.Checked = true;
            chkSyncdrToRig.CheckState = System.Windows.Forms.CheckState.Checked;
            chkSyncdrToRig.Location = new System.Drawing.Point(5, 122);
            chkSyncdrToRig.Name = "chkSyncdrToRig";
            chkSyncdrToRig.Size = new System.Drawing.Size(109, 19);
            chkSyncdrToRig.TabIndex = 14;
            chkSyncdrToRig.Text = "Sync SDR to Rig";
            chkSyncdrToRig.UseVisualStyleBackColor = true;
            chkSyncdrToRig.CheckedChanged += chkSyncdrToRig_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(5, 201);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(137, 15);
            label6.TabIndex = 16;
            label6.Text = "LO sync by Magalex2x14";
            // 
            // RigControlPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(chkSyncdrToRig);
            Controls.Add(chkSyncRigToSdr);
            Controls.Add(bb_omniRigConfig);
            Controls.Add(lblVersion);
            Controls.Add(lblMode);
            Controls.Add(lblFrequency);
            Controls.Add(lblStatus);
            Controls.Add(lblRigName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Label1);
            Controls.Add(cbRig);
            Controls.Add(chkEnable);
            Name = "RigControlPanel";
            Size = new System.Drawing.Size(174, 221);
            Load += RigControlPanel_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.CheckBox chkSyncRigToSdr;
        private System.Windows.Forms.CheckBox chkSyncdrToRig;
        private System.Windows.Forms.Label label6;
    }
}