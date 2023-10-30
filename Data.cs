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
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
            {
                comboBox1.Items.Add("2023年");
                comboBox1.Items.Add("2024年");
                comboBox1.Items.Add("2025年");
            }
        }

        private void Data_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader(@"C:\Users\seki-\Desktop\株\TradeDataKabu\" + "SearchIndex.csv");

            int totalAmount = 0;
            double totalPercentPlus = 0;
            double totalPercentMinus = 0;
            double count = 0;
            double countPlus = 0;
            double countMinus = 0;
            int dayCountPlus = 0;
            int dayCountMinus = 0;
            double totalCountBuy = 0;
            double totalCountSell = 0;
            double countBuyPlus = 0;
            double totalPerBuyPlus = 0;
            double countBuyMinus = 0;
            double totalPerBuyMinus = 0;
            double countSellPlus = 0;      
            double totalPerSellPlus = 0;
            double countSellMinus = 0;
            double totalPerSellMinus = 0;


            var jan = new List<string[]>();
            var feb = new List<string[]>();
            var mar = new List<string[]>();
            var apr = new List<string[]>();
            var may = new List<string[]>();
            var jun = new List<string[]>();
            var jul = new List<string[]>();
            var aug = new List<string[]>();
            var sep = new List<string[]>();
            var oct = new List<string[]>();
            var nov = new List<string[]>();
            var dec = new List<string[]>();

            while (sr.Peek() > -1)
            {
                string s = sr.ReadLine();
                string[] s_array = s.Split(',');

                

                var amount = int.Parse(s_array[9]);
                totalAmount += amount;

                string sPercent = s_array[10].Replace("%", "");
                var percent = double.Parse(sPercent);
                var dayCount = int.Parse(s_array[11]);

                if (percent > 0)
                {
                    totalPercentPlus += percent;
                    dayCountPlus += dayCount;
                    countPlus++;

                    if (s_array[5] == "買建")
                    {
                        totalCountBuy++;
                        totalPerBuyPlus += percent;
                        countBuyPlus++;
                    }    
                    else
                    {
                        totalCountSell++;
                        totalPerSellPlus += percent;
                        countSellPlus++;
                    }              
                }
                else
                {
                    totalPercentMinus += percent;
                    dayCountMinus += dayCount;
                    countMinus++;

                    if (s_array[5] == "買建")
                    {
                        totalCountBuy++;
                        totalPerBuyMinus += percent;
                        countBuyMinus++;
                    }                
                    else
                    {
                        totalCountSell++;
                        totalPerSellMinus += percent;
                        countSellMinus++;
                    }
                }

                count++;

                DateTime date = DateTime.Parse(s_array[1]);

                if (date.Month == 1)
                {
                    jan.Add(s_array);
                }
                else if (date.Month == 2)
                {
                    feb.Add(s_array);
                }
                else if (date.Month == 3)
                {
                    mar.Add(s_array);
                }
                else if (date.Month == 4)
                {
                    apr.Add(s_array);
                }
                else if (date.Month == 5)
                {
                    may.Add(s_array);
                }
                else if (date.Month == 6)
                {
                    jun.Add(s_array);
                }
                else if (date.Month == 7)
                {
                    jul.Add(s_array);
                }
                else if (date.Month == 8)
                {
                    aug.Add(s_array);
                }
                else if (date.Month == 9)
                {
                    sep.Add(s_array);
                }
                else if (date.Month == 10)
                {
                    oct.Add(s_array);
                }
                else if (date.Month == 11)
                {
                    nov.Add(s_array);
                }
                else
                {
                    dec.Add(s_array);
                }
            }

            var monthData = new List<string>[12];
            var janList = CulcPerformance(jan);
            monthData[0] = janList;
            var febList = CulcPerformance(feb);
            monthData[1] = febList;
            var marList = CulcPerformance(mar);
            monthData[2] = marList;
            var aprList = CulcPerformance(apr);
            monthData[3] = aprList;
            var mayList = CulcPerformance(may);
            monthData[4] = mayList;
            var junList = CulcPerformance(jun);
            monthData[5] = junList;
            var julList = CulcPerformance(jul);
            monthData[6] = julList;
            var augList = CulcPerformance(aug);
            monthData[7] = augList;
            var sepList = CulcPerformance(sep);
            monthData[8] = sepList;
            var octList = CulcPerformance(oct);
            monthData[9] = octList;
            var novList = CulcPerformance(nov);
            monthData[10] = novList;
            var decList = CulcPerformance(dec);
            monthData[11] = decList;

            for (int i = 0; i < monthData.Length; i++)
            {
                var mdList = monthData[i];
                dataGridView1.Rows.Add("23/" + (i + 1), mdList[0], mdList[1], mdList[2], mdList[3], mdList[4], mdList[5], mdList[6], mdList[7], mdList[8], mdList[9], mdList[10], mdList[11], mdList[12]);
            }       

            double ta = totalAmount;
            string s_ta = ta.ToString("F0");
            double wr = countPlus/count * 100;
            string s_wr = wr.ToString("F2");
            double pp = totalPercentPlus / countPlus;
            string s_pp = pp.ToString("F2");
            double pm = totalPercentMinus / countMinus;
            string s_pm = pm.ToString("F2");

            double dcp;
            if (countPlus != 0)
                dcp = dayCountPlus / countPlus;
            else
                dcp = 0;                           
            string s_dcp = dcp.ToString("F1");

            double dcm;
            if (countMinus != 0)
                dcm = dayCountMinus / countMinus;
            else
                dcm = 0;
            string s_dcm = dcm.ToString("F1");

            double wrb;
            if (totalCountBuy != 0)
                wrb = countBuyPlus / totalCountBuy * 100;
            else
                wrb = 0;
            string s_wrb = wrb.ToString("F2");

            double wrs;
            if (totalCountSell != 0)
                wrs = countSellPlus / totalCountSell * 100;
            else
                wrs = 0;
            string s_wrs = wrs.ToString("F2");

            double abp;
            if (totalCountBuy != 0)
                abp = totalPerBuyPlus / countBuyPlus;
            else
                abp = 0;
            string s_abp = abp.ToString("F2");

            double abm;
            if (totalCountBuy != 0)
                abm = totalPerBuyMinus / countBuyMinus;
            else
                abm = 0;
            string s_abm = abm.ToString("F2");

            double asp;
            if (totalCountSell != 0)
                asp = totalPerSellPlus / countSellPlus;
            else
                asp = 0;
            string s_asp = asp.ToString("F2");

            double asm;
            if (totalCountSell != 0)
                asm = totalPerSellMinus / countSellMinus;
            else
                asm = 0;
            string s_asm = asm.ToString("F2");


            dataGridView1.Rows.Add("年平均", s_ta + "円", s_wr + "%", count, s_pp + "%", s_pm + "%", s_dcp, s_dcm, s_wrb + "%", s_wrs + "%", s_abp + "%", s_abm + "%", s_asp + "%", s_asm + "%");
            sr.Close();
        }

        private List<string> CulcPerformance(List<string[]> tradeData)
        {
            int totalAmount = 0;
            double totalPercentPlus = 0;
            double totalPercentMinus = 0;
            double totalPerBuyPlus = 0;
            double totalPerBuyMinus = 0;
            double totalPerSellPlus = 0;
            double totalPerSellMinus = 0;
            double count = tradeData.Count;
            double countPlus = 0;
            double countMinus = 0;
            int dayCountPlus = 0;
            int dayCountMinus = 0;
            double totalCountBuy = 0;
            double countBuyPlus = 0;
            double countBuyMinus = 0;
            double totalCountSell = 0;
            double countSellPlus = 0;
            double countSellMinus = 0;

            for (int i = 0; i < tradeData.Count; i++)
            {
                var td_array = tradeData[i];

                var amount = int.Parse(td_array[9]);
                totalAmount += amount;

                string sPercent = td_array[10].Replace("%", "");
                var percent = double.Parse(sPercent);
                var dayCount = int.Parse(td_array[11]);

                if (percent > 0)
                {
                    totalPercentPlus += percent;
                    dayCountPlus += dayCount;
                    countPlus++;

                    if (td_array[5] == "買建")
                    {
                        totalCountBuy++;
                        totalPerBuyPlus += percent;
                        countBuyPlus++;
                    }
                    else
                    {
                        totalCountSell++;
                        totalPerSellPlus += percent;
                        countSellPlus++;
                    }
                }
                else
                {
                    totalPercentMinus += percent;
                    dayCountMinus += dayCount;
                    countMinus++;

                    if (td_array[5] == "買建")
                    {
                        totalCountBuy++;
                        totalPerBuyMinus += percent;
                        countBuyMinus++;
                    }                
                    else
                    {
                        totalCountSell++;
                        totalPerSellMinus += percent;
                        countSellMinus++;
                    }             
                }
            }

            double ta = totalAmount;
            string s_ta = ta.ToString("F0");
            double wr = countPlus / count * 100;
            string s_wr = wr.ToString("F2");
            string s_count = count.ToString();
            double pp = totalPercentPlus / countPlus;
            string s_pp = pp.ToString("F2");
            double pm = totalPercentMinus / countMinus;
            string s_pm = pm.ToString("F2");

            double dcp;
            if (countPlus != 0)
                dcp = dayCountPlus / countPlus;
            else
                dcp = 0;
            string s_dcp = dcp.ToString("F1");

            double dcm;
            if (countMinus != 0)
                dcm = dayCountMinus / countMinus;
            else
                dcm = 0;
            string s_dcm = dcm.ToString("F1");

            double wrb;
            if (totalCountBuy != 0)
                wrb = countBuyPlus / totalCountBuy * 100;
            else
                wrb = 0;
            string s_wrb = wrb.ToString("F2");

            double wrs;
            if (totalCountSell != 0)
                wrs = countSellPlus / totalCountSell * 100;
            else
                wrs = 0;
            string s_wrs = wrs.ToString("F2");

            double abp;
            if (totalCountBuy != 0)
                abp = totalPerBuyPlus / countBuyPlus;
            else
                abp = 0;
            string s_abp = abp.ToString("F2");

            double abm;
            if (totalCountBuy != 0)
                abm = totalPerBuyMinus / countBuyMinus;
            else
                abm = 0;
            string s_abm = abm.ToString("F2");

            double asp;
            if (totalCountSell != 0)
                asp = totalPerSellPlus / countSellPlus;
            else
                asp = 0;
            string s_asp = asp.ToString("F2");

            double asm;
            if (totalCountSell != 0)
                asm = totalPerSellMinus / countSellMinus;
            else
                asm = 0;
            string s_asm = asm.ToString("F2");

            var performanceList = new List<string> { s_ta + "円", s_wr + "%", s_count, s_pp + "%", s_pm + "%", s_dcp, s_dcm, s_wrb + "%", s_wrs + "%", s_abp + "%", s_abm + "%", s_asp + "%", s_asm + "%" };
            if (count == 0)
            {
                for (int i = 0; i < performanceList.Count; i++)
                    performanceList[i] = "";
            }
            
            return performanceList;
        }
    }
}
