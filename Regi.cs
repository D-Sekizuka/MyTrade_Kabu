using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyTrade_Kabu
{
    public partial class Regi : Form
    {
        public Regi()
        {
            InitializeComponent();
            {
                comboBox1.Items.Add("-選択されていません-");
                comboBox1.Items.Add("買建");
                comboBox1.Items.Add("売建");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox3.Text == ""|| comboBox1.SelectedItem == null || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("空欄があるため、登録できません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // 取引Noのインデックス
                if(File.Exists(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "NumberIndex.txt"))
                {
                    // フォルダがあるので何もしない
                }
                else
                {
                    StreamWriter sw3 = new StreamWriter(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "NumberIndex.txt");
                    sw3.WriteLine(0);
                    sw3.Close();
                }
                // NumberIndexから数字を読み込んで1を足す
                StreamReader sr = new StreamReader(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "NumberIndex.txt");
                textBox1.Text = "取引No." + (int.Parse(sr.ReadLine()) + 1).ToString();
                sr.Close();
                // NumberIndexを上書き

                StreamWriter sw4 = new StreamWriter(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "NumberIndex.txt");
                sw4.WriteLine(textBox1.Text.Split('.')[1]);
                sw4.Close();


                if (Directory.Exists(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + textBox1.Text + @"\"))
                {

                }
                else
                {
                    Directory.CreateDirectory(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + textBox1.Text + @"\");
                }

                string dt1 = dateTimePicker1.Value.ToShortDateString();
                DateTime dateFrom = DateTime.Parse(dt1);

                string dt2 = dateTimePicker2.Value.ToShortDateString();
                DateTime dateTo = DateTime.Parse(dt2);
                TimeSpan interval = dateTo - dateFrom;

                double amount = 0;
                double percent = 0;
                double tb4 = int.Parse(textBox4.Text);
                double tb5 = int.Parse(textBox5.Text);
                double tb6 = int.Parse(textBox6.Text);
                if (comboBox1.SelectedIndex == 1)
                {
                    double buy = tb4 * tb5;
                    double sell = tb4 * tb6;
                    amount = sell - buy;

                    double div = tb6 / tb5;
                    double _percent = (div - 1) * 100;
                    percent = Math.Truncate(_percent * 10) / 10;
                }
                else if(comboBox1.SelectedIndex == 2)
                {
                    double sell = tb4 * tb5;
                    double buy = tb4 * tb6;                 
                    amount = sell - buy;

                    double div = tb6 / tb5;
                    double _percent = (div - 1) * -100;
                    percent = Math.Truncate(_percent * 10) / 10;
                }

                StreamWriter sw = new StreamWriter(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + textBox1.Text + @"\" + textBox1.Text + ".txt");
                sw.WriteLine(textBox1.Text);
                sw.WriteLine(dateTimePicker1.Value.ToShortDateString());
                sw.WriteLine(dateTimePicker2.Value.ToShortDateString());
                sw.WriteLine(textBox2.Text);
                sw.WriteLine(textBox3.Text);
                sw.WriteLine(comboBox1.SelectedItem);
                sw.WriteLine(textBox4.Text);
                sw.WriteLine(textBox5.Text);
                sw.WriteLine(textBox6.Text);
                sw.WriteLine(amount);
                sw.WriteLine(percent + "%");
                sw.WriteLine(interval.Days);
                sw.WriteLine(textBox7.Text);
                sw.Close();

                

                StreamWriter sw2 = new StreamWriter(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "SearchIndex.csv", true);
                string s = textBox1.Text + "," + dateTimePicker1.Value + "," + dateTimePicker2.Value + "," + textBox2.Text + "," + textBox3.Text + "," + comboBox1.SelectedItem + "," 
                    + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + ","  + amount + "," + percent + "%" + "," + interval.Days + "," + textBox7.Text;
                sw2.WriteLine(s);
                sw2.Close();

                MessageBox.Show("登録しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Text = "--登録後、自動付与--";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.SelectedIndex = 0;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }
    }
}
