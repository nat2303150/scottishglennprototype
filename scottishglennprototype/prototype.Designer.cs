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
            btnViewAsset = new Button();
            btnEditAsset = new Button();
            btnDeleteAsset = new Button();
            dataGridViewAssets = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            SuspendLayout();
            // 
            // btnAddAsset
            // 
            btnAddAsset.Location = new Point(261, 427);
            btnAddAsset.Margin = new Padding(4, 5, 4, 5);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(503, 38);
            btnAddAsset.TabIndex = 1;
            btnAddAsset.Text = "add asset";
            btnAddAsset.UseVisualStyleBackColor = true;
            btnAddAsset.Click += btnAddAsset_Click;
            // 
            // btnViewAsset
            // 
            btnViewAsset.Location = new Point(261, 475);
            btnViewAsset.Margin = new Padding(4, 5, 4, 5);
            btnViewAsset.Name = "btnViewAsset";
            btnViewAsset.Size = new Size(503, 38);
            btnViewAsset.TabIndex = 3;
            btnViewAsset.Text = "view asset";
            btnViewAsset.UseVisualStyleBackColor = true;
            btnViewAsset.Click += btnViewAsset_Click;
            // 
            // btnEditAsset
            // 
            btnEditAsset.Location = new Point(261, 523);
            btnEditAsset.Margin = new Padding(4, 5, 4, 5);
            btnEditAsset.Name = "btnEditAsset";
            btnEditAsset.Size = new Size(503, 38);
            btnEditAsset.TabIndex = 4;
            btnEditAsset.Text = "edit asset";
            btnEditAsset.UseVisualStyleBackColor = true;
            btnEditAsset.Click += btnEditAsset_Click;
            // 
            // btnDeleteAsset
            // 
            btnDeleteAsset.Location = new Point(261, 572);
            btnDeleteAsset.Margin = new Padding(4, 5, 4, 5);
            btnDeleteAsset.Name = "btnDeleteAsset";
            btnDeleteAsset.Size = new Size(503, 38);
            btnDeleteAsset.TabIndex = 5;
            btnDeleteAsset.Text = "delete asset";
            btnDeleteAsset.UseVisualStyleBackColor = true;
            btnDeleteAsset.Click += btnDeleteAsset_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(261, 167);
            dataGridViewAssets.Margin = new Padding(4, 5, 4, 5);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.RowHeadersWidth = 62;
            dataGridViewAssets.Size = new Size(503, 250);
            dataGridViewAssets.TabIndex = 6;
            // 
            // prototype
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(dataGridViewAssets);
            Controls.Add(btnDeleteAsset);
            Controls.Add(btnEditAsset);
            Controls.Add(btnViewAsset);
            Controls.Add(btnAddAsset);
            Margin = new Padding(4, 5, 4, 5);
            Name = "prototype";
            Text = "Form1";
            Load += prototype_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddAsset;
        private Button btnViewAsset;
        private Button btnEditAsset;
        private Button btnDeleteAsset;
        private DataGridView dataGridViewAssets;
    }
}
