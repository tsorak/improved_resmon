namespace resmonV2
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbl_debug = new System.Windows.Forms.Label();
            this.tbx_pName = new System.Windows.Forms.TextBox();
            this.lbx_matches = new System.Windows.Forms.ListBox();
            this.btn_suspend = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.btn_terminate = new System.Windows.Forms.Button();
            this.cbx_showAll = new System.Windows.Forms.CheckBox();
            this.lbl_selectedProc = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_debug
            // 
            this.lbl_debug.AutoSize = true;
            this.lbl_debug.Location = new System.Drawing.Point(498, 175);
            this.lbl_debug.Name = "lbl_debug";
            this.lbl_debug.Size = new System.Drawing.Size(37, 13);
            this.lbl_debug.TabIndex = 0;
            this.lbl_debug.Text = "debug";
            // 
            // tbx_pName
            // 
            this.tbx_pName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_pName.Location = new System.Drawing.Point(12, 12);
            this.tbx_pName.Name = "tbx_pName";
            this.tbx_pName.Size = new System.Drawing.Size(477, 31);
            this.tbx_pName.TabIndex = 1;
            // 
            // lbx_matches
            // 
            this.lbx_matches.Enabled = false;
            this.lbx_matches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbx_matches.FormattingEnabled = true;
            this.lbx_matches.ItemHeight = 16;
            this.lbx_matches.Location = new System.Drawing.Point(12, 49);
            this.lbx_matches.Name = "lbx_matches";
            this.lbx_matches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbx_matches.Size = new System.Drawing.Size(477, 260);
            this.lbx_matches.TabIndex = 2;
            this.lbx_matches.SelectedIndexChanged += new System.EventHandler(this.Lbx_matches_SelectedIndexChanged);
            // 
            // btn_suspend
            // 
            this.btn_suspend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_suspend.Location = new System.Drawing.Point(500, 49);
            this.btn_suspend.Name = "btn_suspend";
            this.btn_suspend.Size = new System.Drawing.Size(167, 37);
            this.btn_suspend.TabIndex = 3;
            this.btn_suspend.Text = "Suspend";
            this.btn_suspend.UseVisualStyleBackColor = true;
            this.btn_suspend.Click += new System.EventHandler(this.Btn_suspend_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_resume.Location = new System.Drawing.Point(500, 92);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(167, 37);
            this.btn_resume.TabIndex = 4;
            this.btn_resume.Text = "Resume";
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Click += new System.EventHandler(this.Btn_resume_Click);
            // 
            // btn_terminate
            // 
            this.btn_terminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_terminate.Location = new System.Drawing.Point(500, 135);
            this.btn_terminate.Name = "btn_terminate";
            this.btn_terminate.Size = new System.Drawing.Size(167, 37);
            this.btn_terminate.TabIndex = 5;
            this.btn_terminate.Text = "Terminate";
            this.btn_terminate.UseVisualStyleBackColor = true;
            this.btn_terminate.Click += new System.EventHandler(this.Btn_terminate_Click);
            // 
            // cbx_showAll
            // 
            this.cbx_showAll.AutoSize = true;
            this.cbx_showAll.Location = new System.Drawing.Point(501, 263);
            this.cbx_showAll.Name = "cbx_showAll";
            this.cbx_showAll.Size = new System.Drawing.Size(117, 17);
            this.cbx_showAll.TabIndex = 6;
            this.cbx_showAll.Text = "Show all processes";
            this.cbx_showAll.UseVisualStyleBackColor = true;
            this.cbx_showAll.CheckedChanged += new System.EventHandler(this.Cbx_showAll_CheckedChanged);
            // 
            // lbl_selectedProc
            // 
            this.lbl_selectedProc.AutoSize = true;
            this.lbl_selectedProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_selectedProc.Location = new System.Drawing.Point(497, 12);
            this.lbl_selectedProc.Name = "lbl_selectedProc";
            this.lbl_selectedProc.Size = new System.Drawing.Size(157, 24);
            this.lbl_selectedProc.TabIndex = 7;
            this.lbl_selectedProc.Text = "Selected Process";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(501, 286);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(166, 23);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 324);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.lbl_selectedProc);
            this.Controls.Add(this.cbx_showAll);
            this.Controls.Add(this.btn_terminate);
            this.Controls.Add(this.btn_resume);
            this.Controls.Add(this.btn_suspend);
            this.Controls.Add(this.lbx_matches);
            this.Controls.Add(this.tbx_pName);
            this.Controls.Add(this.lbl_debug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Resource Monitor V2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_debug;
        private System.Windows.Forms.TextBox tbx_pName;
        private System.Windows.Forms.ListBox lbx_matches;
        private System.Windows.Forms.Button btn_suspend;
        private System.Windows.Forms.Button btn_resume;
        private System.Windows.Forms.Button btn_terminate;
        private System.Windows.Forms.CheckBox cbx_showAll;
        private System.Windows.Forms.Label lbl_selectedProc;
        private System.Windows.Forms.Button btn_refresh;
    }
}

