using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReedBooks
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            textBox2.Text = $"{Form1.all[Form1.pushed_button]}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 数字以外の記号が含まれていないか確認
            if (textBox1.Text.All(char.IsDigit) == false || textBox2.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("正しい数値を入力してください。", "エラー");
                return;
            }

            // テキストボックスが空でないか確認
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("数値を入力してください。", "エラー");
                return;
            }

            // 全角文字が含まれていないか確認
            Encoding shiftjisEnc = Encoding.GetEncoding("Shift_JIS");
            int chrByteNum1 = shiftjisEnc.GetByteCount(textBox1.Text);
            int chrByteNum2 = shiftjisEnc.GetByteCount(textBox2.Text);
            bool isAllHalfNum1 = (chrByteNum1 == textBox1.Text.Length);
            bool isAllHalfNum2 = (chrByteNum2 == textBox2.Text.Length);

            if (isAllHalfNum1 == false || isAllHalfNum2 == false)
            {
                MessageBox.Show("全角文字が含まれています。", "エラー");
                return;
            }

            int now = Int32.Parse(textBox1.Text);
            int all = Int32.Parse(textBox2.Text);
            
            // 現在のページ数が全ページ数を上回ってないかの確認
            if (now > all || all == 0)
            {
                MessageBox.Show("数値が不適切です。", "エラー");
                return;
            }

            Form1.set_value(now, all);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.remove_items();

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
