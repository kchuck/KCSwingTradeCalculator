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
            //textBox2.Text = entryPrice.ToString("F2");
            //textBox9.Text = adjStopPrice.ToString("F2");
            textBox12.Text = stopPercent.ToString("F2");
        }

        double netLiq=1;
        double entryPrice=0;
        double stopPrice;
        double stopPercent = 5;
        double adjStopPrice = 0;
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
                entryPrice = 0;
            if (textBox12.Text != "")
                stopPercent = Convert.ToDouble(textBox12.Text);
            else
                stopPercent = 0;
            if (textBox9.Text != "")
                adjStopPrice = Convert.ToDouble(textBox9.Text);
            else
                adjStopPrice = 0;
            if (checkBox1.Checked)
                //short
                stopPrice = entryPrice * (1 + stopPercent / 100);
            else
                //long
                stopPrice = entryPrice * (1 - stopPercent / 100);
            textBox3.Text = stopPrice.ToString("F2");
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
            textBox10.Text = (100 * adjShareNum * Math.Abs(entryPrice - adjStopPrice) / netLiq).ToString("F2");
            textBox11.Text = (100 * maxShareNum * Math.Abs(entryPrice - stopPrice) / netLiq).ToString("F2");
            
        }
    }
}
