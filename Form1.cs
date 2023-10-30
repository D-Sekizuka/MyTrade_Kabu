using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTrade_Kabu
{
    public partial class TopPage : Form
    {
        // ビルドの際にはコンソールアプリからWindowsアプリに変更する    

        Regi regi = null;
        Search search = null;
        Data data = null;

        public TopPage()
        {        
            //変更
            InitializeComponent();
        }

        private void tourokubtn_Click(object sender, EventArgs e)
        {
            if(regi == null || regi.IsDisposed)
            {
                regi = new Regi();
                regi.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (search == null || search.IsDisposed)
            {
                search = new Search();
                search.Show();
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data == null || data.IsDisposed)
            {
                data = new Data();
                data.Show();
            }
        }
    }
}
