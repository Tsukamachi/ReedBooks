namespace ReedBooks
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_of_add = new System.Windows.Forms.TextBox();
            this.button_of_add = new System.Windows.Forms.Button();
            this.label_of_add = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_of_add
            // 
            this.textBox_of_add.Location = new System.Drawing.Point(390, 40);
            this.textBox_of_add.Name = "textBox_of_add";
            this.textBox_of_add.Size = new System.Drawing.Size(600, 31);
            this.textBox_of_add.TabIndex = 0;
            this.textBox_of_add.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_of_add
            // 
            this.button_of_add.Location = new System.Drawing.Point(1023, 30);
            this.button_of_add.Name = "button_of_add";
            this.button_of_add.Size = new System.Drawing.Size(120, 50);
            this.button_of_add.TabIndex = 2;
            this.button_of_add.Text = "追加";
            this.button_of_add.UseVisualStyleBackColor = true;
            this.button_of_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_of_add
            // 
            this.label_of_add.AutoSize = true;
            this.label_of_add.Location = new System.Drawing.Point(259, 43);
            this.label_of_add.Name = "label_of_add";
            this.label_of_add.Size = new System.Drawing.Size(102, 24);
            this.label_of_add.TabIndex = 3;
            this.label_of_add.Text = "本の追加";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 822);
            this.Controls.Add(this.label_of_add);
            this.Controls.Add(this.button_of_add);
            this.Controls.Add(this.textBox_of_add);
            this.Name = "Form1";
            this.Text = "読書管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_of_add;
        private System.Windows.Forms.Button button_of_add;
        private System.Windows.Forms.Label label_of_add;
    }
}

