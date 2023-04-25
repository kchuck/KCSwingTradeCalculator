using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCSwingTradeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double netLiq;
        double entryPrice;
        double stopPrice;
        int maxShareNum;
        int adjShareNum;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                netLiq = Convert.ToDouble(textBox1.Text);
            else
                netLiq = 1;
            if (textBox2.Text != "")
                entryPrice = Convert.ToDouble(textBox2.Text);
            else
                entryPrice = 1;
            if (textBox3.Text != "")
                stopPrice = Convert.ToDouble(textBox3.Text);
            else
                stopPrice = 0;
            if ((entryPrice - stopPrice) != 0)
                maxShareNum = Convert.ToInt32(Math.Abs((netLiq * 0.01) / (entryPrice - stopPrice)));
            else
                maxShareNum = 0;
            textBox4.Text = maxShareNum.ToString("D");
            textBox5.Text = (maxShareNum * entryPrice).ToString("F2");
            textBox6.Text = (100 * maxShareNum * entryPrice / netLiq).ToString("F2");
            if (textBox7.Text != "")
                adjShareNum = Convert.ToInt32(textBox7.Text);
            else
                adjShareNum = 0;
            textBox8.Text = (adjShareNum * entryPrice).ToString("F2");
            textBox9.Text = (100 * adjShareNum * entryPrice / netLiq).ToString("F2");
            textBox10.Text = (100 * adjShareNum * Math.Abs(entryPrice - stopPrice) / netLiq).ToString("F2");
            textBox11.Text = (100 * maxShareNum * Math.Abs(entryPrice - stopPrice) / netLiq).ToString("F2");
        }
    }
}
