namespace scottishglennprototype
{
    partial class login_page
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
            usrnmBox = new TextBox();
            pswrdBox = new TextBox();
            loginBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // usrnmBox
            // 
            usrnmBox.Location = new Point(218, 142);
            usrnmBox.Name = "usrnmBox";
            usrnmBox.Size = new Size(350, 23);
            usrnmBox.TabIndex = 0;
            // 
            // pswrdBox
            // 
            pswrdBox.Location = new Point(218, 199);
            pswrdBox.Name = "pswrdBox";
            pswrdBox.Size = new Size(350, 23);
            pswrdBox.TabIndex = 1;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(218, 256);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(350, 23);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 145);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 202);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // login_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loginBtn);
            Controls.Add(pswrdBox);
            Controls.Add(usrnmBox);
            Name = "login_page";
            Text = "login_page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usrnmBox;
        private TextBox pswrdBox;
        private Button loginBtn;
        private Label label1;
        private Label label2;
    }
}