namespace pbTestManyToMany3_CF_Live
{
    partial class frmSwitchBoard
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
            this.btnSetupTestData = new System.Windows.Forms.Button();
            this.btnClearDb = new System.Windows.Forms.Button();
            this.btnCreateDb = new System.Windows.Forms.Button();
            this.btnDisplayDb = new System.Windows.Forms.Button();
            this.btnSandP = new System.Windows.Forms.Button();
            this.btnPandK = new System.Windows.Forms.Button();
            this.btnProjectsKeywords = new System.Windows.Forms.Button();
            this.btnMultiUpdate = new System.Windows.Forms.Button();
            this.btnPKX = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetupTestData
            // 
            this.btnSetupTestData.Location = new System.Drawing.Point(21, 63);
            this.btnSetupTestData.Name = "btnSetupTestData";
            this.btnSetupTestData.Size = new System.Drawing.Size(133, 23);
            this.btnSetupTestData.TabIndex = 0;
            this.btnSetupTestData.Text = "Setup Test Data";
            this.btnSetupTestData.UseVisualStyleBackColor = true;
            this.btnSetupTestData.Click += new System.EventHandler(this.btnSetupTestdData_Click);
            // 
            // btnClearDb
            // 
            this.btnClearDb.Location = new System.Drawing.Point(21, 105);
            this.btnClearDb.Name = "btnClearDb";
            this.btnClearDb.Size = new System.Drawing.Size(133, 23);
            this.btnClearDb.TabIndex = 1;
            this.btnClearDb.Text = "Clear the Database";
            this.btnClearDb.UseVisualStyleBackColor = true;
            this.btnClearDb.Click += new System.EventHandler(this.btnClearDb_Click);
            // 
            // btnCreateDb
            // 
            this.btnCreateDb.Location = new System.Drawing.Point(21, 21);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(133, 23);
            this.btnCreateDb.TabIndex = 2;
            this.btnCreateDb.Text = "Create a New Database";
            this.btnCreateDb.UseVisualStyleBackColor = true;
            this.btnCreateDb.Click += new System.EventHandler(this.btnCreateDb_Click);
            // 
            // btnDisplayDb
            // 
            this.btnDisplayDb.Location = new System.Drawing.Point(21, 144);
            this.btnDisplayDb.Name = "btnDisplayDb";
            this.btnDisplayDb.Size = new System.Drawing.Size(147, 23);
            this.btnDisplayDb.TabIndex = 3;
            this.btnDisplayDb.Text = "Display All Database Data";
            this.btnDisplayDb.UseVisualStyleBackColor = true;
            this.btnDisplayDb.Click += new System.EventHandler(this.btnDisplayDb_Click);
            // 
            // btnSandP
            // 
            this.btnSandP.Location = new System.Drawing.Point(273, 21);
            this.btnSandP.Name = "btnSandP";
            this.btnSandP.Size = new System.Drawing.Size(199, 23);
            this.btnSandP.TabIndex = 4;
            this.btnSandP.Text = "Solutions and Projects";
            this.btnSandP.UseVisualStyleBackColor = true;
            // 
            // btnPandK
            // 
            this.btnPandK.Enabled = false;
            this.btnPandK.Location = new System.Drawing.Point(273, 63);
            this.btnPandK.Name = "btnPandK";
            this.btnPandK.Size = new System.Drawing.Size(199, 23);
            this.btnPandK.TabIndex = 5;
            this.btnPandK.Text = "Projects and Keywords";
            this.btnPandK.UseVisualStyleBackColor = true;
            this.btnPandK.Click += new System.EventHandler(this.btnPandK_Click);
            // 
            // btnProjectsKeywords
            // 
            this.btnProjectsKeywords.Location = new System.Drawing.Point(273, 105);
            this.btnProjectsKeywords.Name = "btnProjectsKeywords";
            this.btnProjectsKeywords.Size = new System.Drawing.Size(199, 23);
            this.btnProjectsKeywords.TabIndex = 6;
            this.btnProjectsKeywords.Text = "Projects Keywords";
            this.btnProjectsKeywords.UseVisualStyleBackColor = true;
            this.btnProjectsKeywords.Click += new System.EventHandler(this.btnProjectsKeywords_Click);
            // 
            // btnMultiUpdate
            // 
            this.btnMultiUpdate.Location = new System.Drawing.Point(273, 144);
            this.btnMultiUpdate.Name = "btnMultiUpdate";
            this.btnMultiUpdate.Size = new System.Drawing.Size(199, 23);
            this.btnMultiUpdate.TabIndex = 7;
            this.btnMultiUpdate.Text = "Multiple Update";
            this.btnMultiUpdate.UseVisualStyleBackColor = true;
            this.btnMultiUpdate.Click += new System.EventHandler(this.btnMultiUpdate_Click);
            // 
            // btnPKX
            // 
            this.btnPKX.Location = new System.Drawing.Point(273, 199);
            this.btnPKX.Name = "btnPKX";
            this.btnPKX.Size = new System.Drawing.Size(199, 23);
            this.btnPKX.TabIndex = 8;
            this.btnPKX.Text = "Update Projects, Keyword and Xrefs";
            this.btnPKX.UseVisualStyleBackColor = true;
            this.btnPKX.Click += new System.EventHandler(this.btnPKX_Click);
            // 
            // frmSwitchBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPKX);
            this.Controls.Add(this.btnMultiUpdate);
            this.Controls.Add(this.btnProjectsKeywords);
            this.Controls.Add(this.btnPandK);
            this.Controls.Add(this.btnSandP);
            this.Controls.Add(this.btnDisplayDb);
            this.Controls.Add(this.btnCreateDb);
            this.Controls.Add(this.btnClearDb);
            this.Controls.Add(this.btnSetupTestData);
            this.Name = "frmSwitchBoard";
            this.Text = "Switchboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetupTestData;
        private System.Windows.Forms.Button btnClearDb;
        private System.Windows.Forms.Button btnCreateDb;
        private System.Windows.Forms.Button btnDisplayDb;
        private System.Windows.Forms.Button btnSandP;
        private System.Windows.Forms.Button btnPandK;
        private System.Windows.Forms.Button btnProjectsKeywords;
        private System.Windows.Forms.Button btnMultiUpdate;
        private System.Windows.Forms.Button btnPKX;
    }
}

