namespace FileTransferApp
{
    partial class Form2
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
            this.fileBtn2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileBtn2
            // 
            this.fileBtn2.Location = new System.Drawing.Point(479, 157);
            this.fileBtn2.Name = "fileBtn2";
            this.fileBtn2.Size = new System.Drawing.Size(37, 29);
            this.fileBtn2.TabIndex = 4;
            this.fileBtn2.Text = "...";
            this.fileBtn2.UseVisualStyleBackColor = true;
            this.fileBtn2.Click += new System.EventHandler(this.fileBtn2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(270, 27);
            this.textBox1.TabIndex = 3;
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(522, 157);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(94, 29);
            this.listenBtn.TabIndex = 5;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listenBtn);
            this.Controls.Add(this.fileBtn2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button fileBtn2;
        private TextBox textBox1;
        private Button listenBtn;
    }
}