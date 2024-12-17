namespace scottishglennprototype
{
    partial class prototype
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddAsset = new Button();
            btnEditAsset = new Button();
            btnDeleteAsset = new Button();
            dataGridViewAssets = new DataGridView();
            btnCheckVulnerabilities = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            SuspendLayout();
            // 
            // btnAddAsset
            // 
            btnAddAsset.Location = new Point(272, 519);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(323, 198);
            btnAddAsset.TabIndex = 1;
            btnAddAsset.Text = "add asset";
            btnAddAsset.UseVisualStyleBackColor = true;
            btnAddAsset.Click += btnAddAsset_Click;
            // 
            // btnEditAsset
            // 
            btnEditAsset.Location = new Point(1294, 519);
            btnEditAsset.Name = "btnEditAsset";
            btnEditAsset.Size = new Size(323, 198);
            btnEditAsset.TabIndex = 4;
            btnEditAsset.Text = "edit asset";
            btnEditAsset.UseVisualStyleBackColor = true;
            btnEditAsset.Click += btnEditAsset_Click;
            // 
            // btnDeleteAsset
            // 
            btnDeleteAsset.Location = new Point(956, 519);
            btnDeleteAsset.Name = "btnDeleteAsset";
            btnDeleteAsset.Size = new Size(323, 198);
            btnDeleteAsset.TabIndex = 5;
            btnDeleteAsset.Text = "delete asset";
            btnDeleteAsset.UseVisualStyleBackColor = true;
            btnDeleteAsset.Click += btnDeleteAsset_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(272, 31);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.RowHeadersWidth = 62;
            dataGridViewAssets.Size = new Size(1345, 429);
            dataGridViewAssets.TabIndex = 6;
            // 
            // btnCheckVulnerabilities
            // 
            btnCheckVulnerabilities.Location = new Point(616, 519);
            btnCheckVulnerabilities.Name = "btnCheckVulnerabilities";
            btnCheckVulnerabilities.Size = new Size(323, 198);
            btnCheckVulnerabilities.TabIndex = 7;
            btnCheckVulnerabilities.Text = "check vulnerabilities";
            btnCheckVulnerabilities.UseVisualStyleBackColor = true;
            btnCheckVulnerabilities.Click += btnCheckVulnerabilities_Click;
            // 
            // prototype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnCheckVulnerabilities);
            Controls.Add(dataGridViewAssets);
            Controls.Add(btnDeleteAsset);
            Controls.Add(btnEditAsset);
            Controls.Add(btnAddAsset);
            Name = "prototype";
            Text = "Form1";
            Load += prototype_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddAsset;
        private Button btnEditAsset;
        private Button btnDeleteAsset;
        private DataGridView dataGridViewAssets;
        private Button btnCheckVulnerabilities;
    }
}
