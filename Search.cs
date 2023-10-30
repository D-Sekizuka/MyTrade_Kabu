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
    public partial class Search : Form
    {
        Brows brows = null;

        public Search()
        {
            InitializeComponent();
            {
                comboBox1.Items.Add("-選択されていません -");
                comboBox1.Items.Add("買建");
                comboBox1.Items.Add("売建");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "SearchIndex.csv");

            while(sr.Peek() > -1)
            {
                string s = sr.ReadLine();
                string[] s_array = s.Split(',');

                string date1 = s_array[1].Split(' ')[0];
                DateTime dt1 = dateTimePicker1.Value.Date;
                DateTime dt2 = dateTimePicker2.Value.Date;
                DateTime dt_data1 = DateTime.Parse(s_array[1]).Date;

                if(checkBox1.Checked)
                {
                    if(dt_data1 < dt1 || dt2 < dt_data1)
                    {
                        continue;
                    }
                }

                string date2 = s_array[2].Split(' ')[0];
                DateTime dt3 = dateTimePicker1.Value.Date;
                DateTime dt4 = dateTimePicker2.Value.Date;
                DateTime dt_data2 = DateTime.Parse(s_array[2]).Date;

                if (checkBox2.Checked)
                {
                    if (dt_data2 < dt1 || dt2 < dt_data2)
                    {
                        continue;
                    }
                }

                if (textBox1.Text != "")
                {
                    if(s_array[3] != textBox1.Text)
                    {
                        continue;
                    }
                }

                if(comboBox1.SelectedItem != null && comboBox1.SelectedIndex != 0)
                {
                    if(s_array[5] != comboBox1.SelectedItem.ToString())
                    {
                        continue;
                    }
                }

                if (textBox2.Text != "")
                {
                    string sa = s_array[10].Split('%')[0];
                    double tb2 = double.Parse(textBox2.Text);
                    double percent = double.Parse(sa);
                    if (percent < tb2)
                    {
                        continue;
                    }
                }

                if (textBox3.Text != "")
                {
                    string sa = s_array[10].Split('%')[0];
                    double tb3 = double.Parse(textBox3.Text);
                    double percent = double.Parse(sa);
                    if (tb3 < percent)
                    {
                        continue;
                    }
                }

                dataGridView1.Rows.Add(date1, date2, s_array[3], s_array[4], s_array[5], s_array[10], s_array[9], s_array[0]);
            }
            sr.Close();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("この検索条件に合うデータはありません", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = !dateTimePicker1.Enabled;
            dateTimePicker2.Enabled = !dateTimePicker2.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Enabled = !dateTimePicker3.Enabled;
            dateTimePicker4.Enabled = !dateTimePicker4.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            checkBox2.Checked = false;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("閲覧対象が選択されていません");
            }
            else
            {
                string dir = @"C:\Users\seki-\Desktop\株\TradeDataKabu\" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + @"\";
                string s = dir + dataGridView1.CurrentRow.Cells[7].Value.ToString() + ".txt";

                if (brows == null || brows.IsDisposed)
                {
                    brows = new Brows(s);
                    brows.Show();
                }
            }   
        }
    }
}
