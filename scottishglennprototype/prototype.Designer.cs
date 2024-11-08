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
            textBox = new TextBox();
            btnAddAsset = new Button();
            btnViewAsset = new Button();
            btnEditAsset = new Button();
            btnDeleteAsset = new Button();
            dataGridViewAssets = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(183, 227);
            textBox.Name = "textBox";
            textBox.Size = new Size(352, 23);
            textBox.TabIndex = 2;
            // 
            // btnAddAsset
            // 
            btnAddAsset.Location = new Point(183, 256);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(352, 23);
            btnAddAsset.TabIndex = 1;
            btnAddAsset.Text = "add asset";
            btnAddAsset.UseVisualStyleBackColor = true;
            btnAddAsset.Click += btnAddAsset_Click;
            // 
            // btnViewAsset
            // 
            btnViewAsset.Location = new Point(183, 285);
            btnViewAsset.Name = "btnViewAsset";
            btnViewAsset.Size = new Size(352, 23);
            btnViewAsset.TabIndex = 3;
            btnViewAsset.Text = "view asset";
            btnViewAsset.UseVisualStyleBackColor = true;
            btnViewAsset.Click += btnViewAsset_Click;
            // 
            // btnEditAsset
            // 
            btnEditAsset.Location = new Point(183, 314);
            btnEditAsset.Name = "btnEditAsset";
            btnEditAsset.Size = new Size(352, 23);
            btnEditAsset.TabIndex = 4;
            btnEditAsset.Text = "edit asset";
            btnEditAsset.UseVisualStyleBackColor = true;
            btnEditAsset.Click += btnEditAsset_Click;
            // 
            // btnDeleteAsset
            // 
            btnDeleteAsset.Location = new Point(183, 343);
            btnDeleteAsset.Name = "btnDeleteAsset";
            btnDeleteAsset.Size = new Size(352, 23);
            btnDeleteAsset.TabIndex = 5;
            btnDeleteAsset.Text = "delete asset";
            btnDeleteAsset.UseVisualStyleBackColor = true;
            btnDeleteAsset.Click += btnDeleteAsset_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(183, 71);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.Size = new Size(352, 150);
            dataGridViewAssets.TabIndex = 6;
            // 
            // prototype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewAssets);
            Controls.Add(btnDeleteAsset);
            Controls.Add(btnEditAsset);
            Controls.Add(btnViewAsset);
            Controls.Add(btnAddAsset);
            Controls.Add(textBox);
            Name = "prototype";
            Text = "Form1";
            Load += prototype_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private Button btnAddAsset;
        private Button btnViewAsset;
        private Button btnEditAsset;
        private Button btnDeleteAsset;
        private DataGridView dataGridViewAssets;
    }
}
