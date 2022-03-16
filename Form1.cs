using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; // ファイルを読み込むために追加

namespace ReedBooks
{
    public partial class Form1 : Form
    {
        static int num_of_books = 0;
        static int space_of_add = 60;

        static List<Label> name_of_book = new List<Label>();
        static List<Label> progress_of_book = new List<Label>();
        static List<ProgressBar> progressBars = new List<ProgressBar>();
        static List<Button> buttons = new List<Button>();

        static List<string> name_str = new List<string>();
        static List<int> now = new List<int>();
        public static List<int> all = new List<int>();

        public static int pushed_button;

        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;

            read_file();
        }

        // テキストファイルからの読み込み
        private void read_file()
        {
            string file_path = @"data.txt";
            if(File.Exists(file_path) == false)
            {
                using (FileStream fs = File.Create(file_path)) ;
            }

            StreamReader sr = new StreamReader(file_path);

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                string[] del = { "$%$" };
                string[] lines = line.Split(del, StringSplitOptions.None);

                name_str.Add(lines[0]);

                // 本の名前
                Label label1 = new Label();
                label1.Location = new Point(50, 80 + num_of_books * space_of_add);
                label1.Size = new Size(400, 15);
                label1.Text = lines[0];
                this.Controls.Add(label1);
                name_of_book.Add(label1);

                now.Add(Int32.Parse(lines[1]));
                all.Add(Int32.Parse(lines[2]));
                int progre = (int)((double)now[num_of_books] / all[num_of_books] * 100);

                // 本の進捗(プログレスバー)
                ProgressBar progressBar1 = new ProgressBar();
                progressBar1.Location = new Point(50, 100 + num_of_books * space_of_add);
                progressBar1.Size = new Size(400, 20);
                progressBar1.Value = progre;
                progressBar1.ForeColor = Color.LightBlue;
                progressBar1.Style = ProgressBarStyle.Continuous;
                this.Controls.Add(progressBar1);
                progressBars.Add(progressBar1);

                // 本の進捗(ページ数)
                Label label2 = new Label();
                label2.Location = new Point(470, 95 + num_of_books * space_of_add);
                label2.Size = new Size(60, 35);
                label2.Text = $"{now[num_of_books]} / {all[num_of_books]}";
                this.Controls.Add(label2);
                progress_of_book.Add(label2);

                // 編集ボタン
                Button button2 = new Button();
                button2.Location = new Point(545, 75 + num_of_books * space_of_add);
                button2.Size = new Size(30, 50);
                button2.Text = "編集";
                button2.Tag = num_of_books;
                button2.Click += show_form2;
                this.Controls.Add(button2);
                buttons.Add(button2);

                num_of_books++;
            }

            sr.Close();
        }

        // 値の設定 <= Form2
        public static void set_value(int n, int a)
        {
            now[pushed_button] = n;
            all[pushed_button] = a;
            progress_of_book[pushed_button].Text = $"{n} / {a}";
            progressBars[pushed_button].Value = (int)((double)n / a * 100);
        }

        // 削除 <= Form2
        public static void remove_items()
        {
            // 非表示
            name_of_book[pushed_button].Visible = false;
            progress_of_book[pushed_button].Visible = false;
            progressBars[pushed_button].Visible = false;
            buttons[pushed_button].Visible = false;

            // 要素の削除
            name_of_book.RemoveAt(pushed_button);
            progress_of_book.RemoveAt(pushed_button);
            progressBars.RemoveAt(pushed_button);
            buttons.RemoveAt(pushed_button);
            name_str.RemoveAt(pushed_button);
            now.RemoveAt(pushed_button);
            all.RemoveAt(pushed_button);

            num_of_books--;

            // 配置の変更
            for(int i = pushed_button; i < num_of_books; i++)
            {
                name_of_book[i].Top -= space_of_add;
                progress_of_book[i].Top -= space_of_add;
                progressBars[i].Top -= space_of_add;
                buttons[i].Top -= space_of_add;
                buttons[i].Tag = (int)buttons[i].Tag - 1;
            }
        }

        // 編集ボタンクリック時の動作
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_of_add.Text.Contains("$%$"))
            {
                MessageBox.Show("\"$%$\"は区切り文字として使用しています。\nこの文字列は使用しないでください。", "エラー");
                return;
            }

            // 本の名前
            Label label1 = new Label();
            label1.Location = new Point(50, 80 + num_of_books * space_of_add);
            label1.Size = new Size(400, 15);
            label1.Text = textBox_of_add.Text;
            this.Controls.Add(label1);
            name_of_book.Add(label1);
            name_str.Add(label1.Text);

            textBox_of_add.Text = ""; // 入力が済んだらテキストボックスを空に

            // 0/100で初期化
            now.Add(0);
            all.Add(100);
            int progre = (int)((double)now[num_of_books] / all[num_of_books] * 100);

            // 本の進捗(プログレスバー)
            ProgressBar progressBar1 = new ProgressBar();
            progressBar1.Location = new Point(50, 100 + num_of_books * space_of_add);
            progressBar1.Size = new Size(400, 20);
            progressBar1.Value = progre;
            progressBar1.ForeColor = Color.LightBlue;
            progressBar1.Style = ProgressBarStyle.Continuous;
            this.Controls.Add(progressBar1);
            progressBars.Add(progressBar1);

            // 本の進捗(ページ数)
            Label label2 = new Label();
            label2.Location = new Point(470, 95 + num_of_books * space_of_add);
            label2.Size = new Size(60, 35);
            label2.Text = $"{now[num_of_books]} / {all[num_of_books]}";
            this.Controls.Add(label2);
            progress_of_book.Add(label2);

            // 編集ボタン
            Button button2 = new Button();
            button2.Location = new Point(545, 75 + num_of_books * space_of_add);
            button2.Size = new Size(30, 50);
            button2.Text = "編集";
            button2.Tag = num_of_books;
            button2.Click += show_form2;
            this.Controls.Add(button2);
            buttons.Add(button2);

            num_of_books++; // 本の数の追加
        }

        // 編集画面の表示 => Form2
        private void show_form2(object sender, EventArgs e)
        {
            pushed_button = (int)((Button)sender).Tag;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // テキストファイルに書き込み
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter writer = new StreamWriter("data.txt");
            
            for (int i = 0; i < num_of_books; i++)
            {
                writer.WriteLine(name_str[i] + "$%$" + now[i] + "$%$" + all[i]);
            }

            writer.Close();
        }

        // ココから下はゴミ

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
