namespace pbTestManyToMany3_CF
{
    partial class frmDbMaint
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
            this.btnUpdateProjects = new System.Windows.Forms.Button();
            this.btnUpdateKeywords = new System.Windows.Forms.Button();
            this.btnUpdateReferences = new System.Windows.Forms.Button();
            this.btnUpdateP_K = new System.Windows.Forms.Button();
            this.btnClearDatabase = new System.Windows.Forms.Button();
            this.btnInitDatabase = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnUpdateSolutions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateProjects
            // 
            this.btnUpdateProjects.Location = new System.Drawing.Point(27, 24);
            this.btnUpdateProjects.Name = "btnUpdateProjects";
            this.btnUpdateProjects.Size = new System.Drawing.Size(191, 23);
            this.btnUpdateProjects.TabIndex = 0;
            this.btnUpdateProjects.Text = "Update &Projects";
            this.btnUpdateProjects.UseVisualStyleBackColor = true;
            this.btnUpdateProjects.Click += new System.EventHandler(this.btnUpdateProjects_Click);
            // 
            // btnUpdateKeywords
            // 
            this.btnUpdateKeywords.Location = new System.Drawing.Point(27, 74);
            this.btnUpdateKeywords.Name = "btnUpdateKeywords";
            this.btnUpdateKeywords.Size = new System.Drawing.Size(191, 23);
            this.btnUpdateKeywords.TabIndex = 1;
            this.btnUpdateKeywords.Text = "Update &Keywords";
            this.btnUpdateKeywords.UseVisualStyleBackColor = true;
            // 
            // btnUpdateReferences
            // 
            this.btnUpdateReferences.Location = new System.Drawing.Point(27, 124);
            this.btnUpdateReferences.Name = "btnUpdateReferences";
            this.btnUpdateReferences.Size = new System.Drawing.Size(191, 23);
            this.btnUpdateReferences.TabIndex = 2;
            this.btnUpdateReferences.Text = "Update &References";
            this.btnUpdateReferences.UseVisualStyleBackColor = true;
            this.btnUpdateReferences.Click += new System.EventHandler(this.btnUpdateReferences_Click);
            // 
            // btnUpdateP_K
            // 
            this.btnUpdateP_K.Location = new System.Drawing.Point(27, 174);
            this.btnUpdateP_K.Name = "btnUpdateP_K";
            this.btnUpdateP_K.Size = new System.Drawing.Size(191, 23);
            this.btnUpdateP_K.TabIndex = 3;
            this.btnUpdateP_K.Text = "Update Projects <--> Keywords";
            this.btnUpdateP_K.UseVisualStyleBackColor = true;
            // 
            // btnClearDatabase
            // 
            this.btnClearDatabase.Location = new System.Drawing.Point(313, 24);
            this.btnClearDatabase.Name = "btnClearDatabase";
            this.btnClearDatabase.Size = new System.Drawing.Size(102, 23);
            this.btnClearDatabase.TabIndex = 4;
            this.btnClearDatabase.Text = "&Clear Database";
            this.btnClearDatabase.UseVisualStyleBackColor = true;
            this.btnClearDatabase.Click += new System.EventHandler(this.btnClearDatabase_Click);
            // 
            // btnInitDatabase
            // 
            this.btnInitDatabase.Location = new System.Drawing.Point(313, 76);
            this.btnInitDatabase.Name = "btnInitDatabase";
            this.btnInitDatabase.Size = new System.Drawing.Size(102, 23);
            this.btnInitDatabase.TabIndex = 5;
            this.btnInitDatabase.Text = "&Initialize Database";
            this.btnInitDatabase.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(101, 289);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSolutions
            // 
            this.btnUpdateSolutions.Location = new System.Drawing.Point(27, 224);
            this.btnUpdateSolutions.Name = "btnUpdateSolutions";
            this.btnUpdateSolutions.Size = new System.Drawing.Size(191, 23);
            this.btnUpdateSolutions.TabIndex = 7;
            this.btnUpdateSolutions.Text = "Update Solutions";
            this.btnUpdateSolutions.UseVisualStyleBackColor = true;
            this.btnUpdateSolutions.Click += new System.EventHandler(this.btnUpdateSolutions_Click);
            // 
            // frmDbMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 351);
            this.Controls.Add(this.btnUpdateSolutions);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnInitDatabase);
            this.Controls.Add(this.btnClearDatabase);
            this.Controls.Add(this.btnUpdateP_K);
            this.Controls.Add(this.btnUpdateReferences);
            this.Controls.Add(this.btnUpdateKeywords);
            this.Controls.Add(this.btnUpdateProjects);
            this.Name = "frmDbMaint";
            this.Text = "Database Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateProjects;
        private System.Windows.Forms.Button btnUpdateKeywords;
        private System.Windows.Forms.Button btnUpdateReferences;
        private System.Windows.Forms.Button btnUpdateP_K;
        private System.Windows.Forms.Button btnClearDatabase;
        private System.Windows.Forms.Button btnInitDatabase;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnUpdateSolutions;
    }
}