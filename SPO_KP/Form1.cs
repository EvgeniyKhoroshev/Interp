using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SPO_KP
{
    public partial class Form1 : Form
    {
        double LLtestTACT, LRtestTACT, LLtestTIME,LRtestTIME;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LexicalAnalyzer lx = new LexicalAnalyzer();
            TranslationTable t;
            Queue er = new Queue();
            string st = "";
            string tokens = "";
            t = lx.doAnalyze(richTextBox1.Lines, out er, out st);
            foreach (TranslationTable.translationTable b in t.TranslationList)
            {
                if (b.Token != '_')
                {
                    richTextBox3.Text += b.Token;
                    tokens += b.Token;
                }
                t.ClearBuffer();
            }
            richTextBox3.Text += "\n\n";
            label4.Text = "Количество токенов: " + Convert.ToString(tokens.Count()); 
            foreach (string s in er)
            {
                richTextBox2.Text += '\n' + s;
            }
            richTextBox3.AppendText( st );
            string LOG, err;
            SA_LL1 ll = new SA_LL1();
            long time = 0, ticks = 0;
            ll.Do(tokens, out LOG, out err, out time,out ticks);
            LLtestTIME += time;
            LLtestTACT += ticks;
            richTextBox4.AppendText("Время выполнения разбора (в тактах микропроцессора) :" + Convert.ToString(ticks));
            richTextBox4.AppendText("\nВремя выполнения разбора (в мс) :" + Convert.ToString(time));
            richTextBox4.AppendText(LOG);
            richTextBox2.AppendText(err);
            SA_LR1 lr = new SA_LR1();
            string log = "";
            string output = "";
            time = 0;
            output = lr.LRAnalisys(tokens, out log, out time, out ticks);
            LRtestTIME += time;
            LRtestTACT += ticks;
            richTextBox5.AppendText("Время выполнения разбора (в тактах микропроцессора) :" + Convert.ToString(ticks));
            richTextBox5.AppendText("\nВремя выполнения разбора (в мс) :" + Convert.ToString(time));
            richTextBox5.AppendText(output + "\n" + log);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "Количество токенов: ";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LLtestTACT = 0;
            LRtestTACT = 0;
            LLtestTIME = 0;
            LRtestTIME = 0;
            for (int i= 0; i<100; ++i)
            {
                button1_Click(sender, e);
                button2_Click(sender, e);
                GC.Collect();
            }
            richTextBox2.AppendText("\nСреднее время выполнения LL анализа:" + Convert.ToString(LLtestTIME / 100));
            richTextBox2.AppendText("\nСреднее время выполнения LR анализа:" + Convert.ToString(LRtestTIME / 100));
            richTextBox2.AppendText("\nСреднее количество тактов МП LL анализа:" + Convert.ToString(LLtestTACT / 100));
            richTextBox2.AppendText("\nСреднее количество тактов МП LR анализа:" + Convert.ToString(LRtestTACT / 100));




        }
    }
}
