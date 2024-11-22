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
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            SuspendLayout();
            // 
            // btnAddAsset
            // 
            btnAddAsset.Location = new Point(68, 418);
            btnAddAsset.Margin = new Padding(4, 5, 4, 5);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(462, 38);
            btnAddAsset.TabIndex = 1;
            btnAddAsset.Text = "add asset";
            btnAddAsset.UseVisualStyleBackColor = true;
            btnAddAsset.Click += btnAddAsset_Click;
            // 
            // btnEditAsset
            // 
            btnEditAsset.Location = new Point(769, 418);
            btnEditAsset.Margin = new Padding(4, 5, 4, 5);
            btnEditAsset.Name = "btnEditAsset";
            btnEditAsset.Size = new Size(462, 38);
            btnEditAsset.TabIndex = 4;
            btnEditAsset.Text = "edit asset";
            btnEditAsset.UseVisualStyleBackColor = true;
            btnEditAsset.Click += btnEditAsset_Click;
            // 
            // btnDeleteAsset
            // 
            btnDeleteAsset.Location = new Point(68, 493);
            btnDeleteAsset.Margin = new Padding(4, 5, 4, 5);
            btnDeleteAsset.Name = "btnDeleteAsset";
            btnDeleteAsset.Size = new Size(462, 38);
            btnDeleteAsset.TabIndex = 5;
            btnDeleteAsset.Text = "delete asset";
            btnDeleteAsset.UseVisualStyleBackColor = true;
            btnDeleteAsset.Click += btnDeleteAsset_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(68, 142);
            dataGridViewAssets.Margin = new Padding(4, 5, 4, 5);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.RowHeadersWidth = 62;
            dataGridViewAssets.Size = new Size(1163, 250);
            dataGridViewAssets.TabIndex = 6;
            // 
            // prototype
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 750);
            Controls.Add(dataGridViewAssets);
            Controls.Add(btnDeleteAsset);
            Controls.Add(btnEditAsset);
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
        private Button btnEditAsset;
        private Button btnDeleteAsset;
        private DataGridView dataGridViewAssets;
    }
}
