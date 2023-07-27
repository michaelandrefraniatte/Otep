using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
namespace NonogramGeneratorAndPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static uint CurrentResolution = 0;
        private static bool Closinggetstate;
        private static Stopwatch stopwatch = new Stopwatch();
        public static BackgroundWorker backgroundWorker = new BackgroundWorker();
        private int seconds;
        private bool showbravo;
        private bool play, playrandom, create;
        private int[] arraycreate = new int[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21, b22, b23, b24, b25, b26, b27, b28, b29, b30, b31, b32, b33, b34, b35, b36, b37, b38, b39, b40, b41, b42, b43, b44, b45, b46, b47, b48, b49, b50, b51, b52, b53, b54, b55, b56, b57, b58, b59, b60, b61, b62, b63, b64;
        private int countlabel1;
        private int[] arraylabel1 = new int[8];
        public static List<int> countarraylabel1 = new List<int>();
        private int countlabel2;
        private int[] arraylabel2 = new int[8];
        public static List<int> countarraylabel2 = new List<int>();
        private int countlabel3;
        private int[] arraylabel3 = new int[8];
        public static List<int> countarraylabel3 = new List<int>();
        private int countlabel4;
        private int[] arraylabel4 = new int[8];
        public static List<int> countarraylabel4 = new List<int>();
        private int countlabel5;
        private int[] arraylabel5 = new int[8];
        public static List<int> countarraylabel5 = new List<int>();
        private int countlabel6;
        private int[] arraylabel6 = new int[8];
        public static List<int> countarraylabel6 = new List<int>();
        private int countlabel7;
        private int[] arraylabel7 = new int[8];
        public static List<int> countarraylabel7 = new List<int>();
        private int countlabel8;
        private int[] arraylabel8 = new int[8];
        public static List<int> countarraylabel8 = new List<int>();
        private int countlabel9;
        private int[] arraylabel9 = new int[8];
        public static List<int> countarraylabel9 = new List<int>();
        private int countlabel10;
        private int[] arraylabel10 = new int[8];
        public static List<int> countarraylabel10 = new List<int>();
        private int countlabel11;
        private int[] arraylabel11 = new int[8];
        public static List<int> countarraylabel11 = new List<int>();
        private int countlabel12;
        private int[] arraylabel12 = new int[8];
        public static List<int> countarraylabel12 = new List<int>();
        private int countlabel13;
        private int[] arraylabel13 = new int[8];
        public static List<int> countarraylabel13 = new List<int>();
        private int countlabel14;
        private int[] arraylabel14 = new int[8];
        public static List<int> countarraylabel14 = new List<int>();
        private int countlabel15;
        private int[] arraylabel15 = new int[8];
        public static List<int> countarraylabel15 = new List<int>();
        private int countlabel16;
        private int[] arraylabel16 = new int[8];
        public static List<int> countarraylabel16 = new List<int>();
        public static string arraycreatefromstring;
        private int[] arrayplay = new int[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static string arrayplayfromstring;
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopwatch.Stop();
            Closinggetstate = true;
            TimeEndPeriod(1);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            backgroundWorker.DoWork += new DoWorkEventHandler(NPAG_thr);
            backgroundWorker.RunWorkerAsync();
        }
        private void NPAG_thr(object sender, DoWorkEventArgs e)
        {
            for (; ; )
            {
                if (Closinggetstate)
                    return;
                seconds = stopwatch.Elapsed.Seconds;
                if (seconds >= 60)
                    seconds = seconds - 60;
                label17.Text = stopwatch.Elapsed.Minutes.ToString() + ":" + seconds.ToString();
                if (create)
                {
                    textBox1.Text = string.Join(",", Array.ConvertAll(arraycreate, i => i.ToString()));
                }
                if (create)
                {
                    arraylabel1[0] = arraycreate[0];
                    arraylabel1[1] = arraycreate[8];
                    arraylabel1[2] = arraycreate[16];
                    arraylabel1[3] = arraycreate[24];
                    arraylabel1[4] = arraycreate[32];
                    arraylabel1[5] = arraycreate[40];
                    arraylabel1[6] = arraycreate[48];
                    arraylabel1[7] = arraycreate[56];
                }
                if (play | playrandom)
                {
                    arraylabel1[0] = arrayplay[0];
                    arraylabel1[1] = arrayplay[8];
                    arraylabel1[2] = arrayplay[16];
                    arraylabel1[3] = arrayplay[24];
                    arraylabel1[4] = arrayplay[32];
                    arraylabel1[5] = arrayplay[40];
                    arraylabel1[6] = arrayplay[48];
                    arraylabel1[7] = arrayplay[56];
                }
                countlabel1 = 0;
                foreach (int values in arraylabel1)
                {
                    if (values == 1)
                        countlabel1++;
                    else
                    {
                        countarraylabel1.Add(countlabel1);
                        countlabel1 = 0;
                    }
                }
                countarraylabel1.Add(countlabel1);
                label1.Text = string.Join("\n", Array.ConvertAll(countarraylabel1.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel1.Clear();
                if (create)
                {
                    arraylabel2[0] = arraycreate[1];
                    arraylabel2[1] = arraycreate[9];
                    arraylabel2[2] = arraycreate[17];
                    arraylabel2[3] = arraycreate[25];
                    arraylabel2[4] = arraycreate[33];
                    arraylabel2[5] = arraycreate[41];
                    arraylabel2[6] = arraycreate[49];
                    arraylabel2[7] = arraycreate[57];
                }
                if (play | playrandom)
                {
                    arraylabel2[0] = arrayplay[1];
                    arraylabel2[1] = arrayplay[9];
                    arraylabel2[2] = arrayplay[17];
                    arraylabel2[3] = arrayplay[25];
                    arraylabel2[4] = arrayplay[33];
                    arraylabel2[5] = arrayplay[41];
                    arraylabel2[6] = arrayplay[49];
                    arraylabel2[7] = arrayplay[57];
                }
                countlabel2 = 0;
                foreach (int values in arraylabel2)
                {
                    if (values == 1)
                        countlabel2++;
                    else
                    {
                        countarraylabel2.Add(countlabel2);
                        countlabel2 = 0;
                    }
                }
                countarraylabel2.Add(countlabel2);
                label2.Text = string.Join("\n", Array.ConvertAll(countarraylabel2.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel2.Clear();
                if (create)
                {
                    arraylabel3[0] = arraycreate[2];
                    arraylabel3[1] = arraycreate[10];
                    arraylabel3[2] = arraycreate[18];
                    arraylabel3[3] = arraycreate[26];
                    arraylabel3[4] = arraycreate[34];
                    arraylabel3[5] = arraycreate[42];
                    arraylabel3[6] = arraycreate[50];
                    arraylabel3[7] = arraycreate[58];
                }
                if (play | playrandom)
                {
                    arraylabel3[0] = arrayplay[2];
                    arraylabel3[1] = arrayplay[10];
                    arraylabel3[2] = arrayplay[18];
                    arraylabel3[3] = arrayplay[26];
                    arraylabel3[4] = arrayplay[34];
                    arraylabel3[5] = arrayplay[42];
                    arraylabel3[6] = arrayplay[50];
                    arraylabel3[7] = arrayplay[58];
                }
                countlabel3 = 0;
                foreach (int values in arraylabel3)
                {
                    if (values == 1)
                        countlabel3++;
                    else
                    {
                        countarraylabel3.Add(countlabel3);
                        countlabel3 = 0;
                    }
                }
                countarraylabel3.Add(countlabel3);
                label3.Text = string.Join("\n", Array.ConvertAll(countarraylabel3.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel3.Clear();
                if (create)
                {
                    arraylabel4[0] = arraycreate[3];
                    arraylabel4[1] = arraycreate[11];
                    arraylabel4[2] = arraycreate[19];
                    arraylabel4[3] = arraycreate[27];
                    arraylabel4[4] = arraycreate[35];
                    arraylabel4[5] = arraycreate[43];
                    arraylabel4[6] = arraycreate[51];
                    arraylabel4[7] = arraycreate[59];
                }
                if (play | playrandom)
                {
                    arraylabel4[0] = arrayplay[3];
                    arraylabel4[1] = arrayplay[11];
                    arraylabel4[2] = arrayplay[19];
                    arraylabel4[3] = arrayplay[27];
                    arraylabel4[4] = arrayplay[35];
                    arraylabel4[5] = arrayplay[43];
                    arraylabel4[6] = arrayplay[51];
                    arraylabel4[7] = arrayplay[59];
                }
                countlabel4 = 0;
                foreach (int values in arraylabel4)
                {
                    if (values == 1)
                        countlabel4++;
                    else
                    {
                        countarraylabel4.Add(countlabel4);
                        countlabel4 = 0;
                    }
                }
                countarraylabel4.Add(countlabel4);
                label4.Text = string.Join("\n", Array.ConvertAll(countarraylabel4.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel4.Clear();
                if (create)
                {
                    arraylabel5[0] = arraycreate[4];
                    arraylabel5[1] = arraycreate[12];
                    arraylabel5[2] = arraycreate[20];
                    arraylabel5[3] = arraycreate[28];
                    arraylabel5[4] = arraycreate[36];
                    arraylabel5[5] = arraycreate[44];
                    arraylabel5[6] = arraycreate[52];
                    arraylabel5[7] = arraycreate[60];
                }
                if (play | playrandom)
                {
                    arraylabel5[0] = arrayplay[4];
                    arraylabel5[1] = arrayplay[12];
                    arraylabel5[2] = arrayplay[20];
                    arraylabel5[3] = arrayplay[28];
                    arraylabel5[4] = arrayplay[36];
                    arraylabel5[5] = arrayplay[44];
                    arraylabel5[6] = arrayplay[52];
                    arraylabel5[7] = arrayplay[60];
                }
                countlabel5 = 0;
                foreach (int values in arraylabel5)
                {
                    if (values == 1)
                        countlabel5++;
                    else
                    {
                        countarraylabel5.Add(countlabel5);
                        countlabel5 = 0;
                    }
                }
                countarraylabel5.Add(countlabel5);
                label5.Text = string.Join("\n", Array.ConvertAll(countarraylabel5.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel5.Clear();
                if (create)
                {
                    arraylabel6[0] = arraycreate[5];
                    arraylabel6[1] = arraycreate[13];
                    arraylabel6[2] = arraycreate[21];
                    arraylabel6[3] = arraycreate[29];
                    arraylabel6[4] = arraycreate[37];
                    arraylabel6[5] = arraycreate[45];
                    arraylabel6[6] = arraycreate[53];
                    arraylabel6[7] = arraycreate[61];
                }
                if (play | playrandom)
                {
                    arraylabel6[0] = arrayplay[5];
                    arraylabel6[1] = arrayplay[13];
                    arraylabel6[2] = arrayplay[21];
                    arraylabel6[3] = arrayplay[29];
                    arraylabel6[4] = arrayplay[37];
                    arraylabel6[5] = arrayplay[45];
                    arraylabel6[6] = arrayplay[53];
                    arraylabel6[7] = arrayplay[61];
                }
                countlabel6 = 0;
                foreach (int values in arraylabel6)
                {
                    if (values == 1)
                        countlabel6++;
                    else
                    {
                        countarraylabel6.Add(countlabel6);
                        countlabel6 = 0;
                    }
                }
                countarraylabel6.Add(countlabel6);
                label6.Text = string.Join("\n", Array.ConvertAll(countarraylabel6.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel6.Clear();
                if (create)
                {
                    arraylabel7[0] = arraycreate[6 + 8 * 0];
                    arraylabel7[1] = arraycreate[6 + 8 * 1];
                    arraylabel7[2] = arraycreate[6 + 8 * 2];
                    arraylabel7[3] = arraycreate[6 + 8 * 3];
                    arraylabel7[4] = arraycreate[6 + 8 * 4];
                    arraylabel7[5] = arraycreate[6 + 8 * 5];
                    arraylabel7[6] = arraycreate[6 + 8 * 6];
                    arraylabel7[7] = arraycreate[6 + 8 * 7];
                }
                if (play | playrandom)
                {
                    arraylabel7[0] = arrayplay[6 + 8 * 0];
                    arraylabel7[1] = arrayplay[6 + 8 * 1];
                    arraylabel7[2] = arrayplay[6 + 8 * 2];
                    arraylabel7[3] = arrayplay[6 + 8 * 3];
                    arraylabel7[4] = arrayplay[6 + 8 * 4];
                    arraylabel7[5] = arrayplay[6 + 8 * 5];
                    arraylabel7[6] = arrayplay[6 + 8 * 6];
                    arraylabel7[7] = arrayplay[6 + 8 * 7];
                }
                countlabel7 = 0;
                foreach (int values in arraylabel7)
                {
                    if (values == 1)
                        countlabel7++;
                    else
                    {
                        countarraylabel7.Add(countlabel7);
                        countlabel7 = 0;
                    }
                }
                countarraylabel7.Add(countlabel7);
                label7.Text = string.Join("\n", Array.ConvertAll(countarraylabel7.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel7.Clear();
                if (create)
                {
                    arraylabel8[0] = arraycreate[7 + 8 * 0];
                    arraylabel8[1] = arraycreate[7 + 8 * 1];
                    arraylabel8[2] = arraycreate[7 + 8 * 2];
                    arraylabel8[3] = arraycreate[7 + 8 * 3];
                    arraylabel8[4] = arraycreate[7 + 8 * 4];
                    arraylabel8[5] = arraycreate[7 + 8 * 5];
                    arraylabel8[6] = arraycreate[7 + 8 * 6];
                    arraylabel8[7] = arraycreate[7 + 8 * 7];
                }
                if (play | playrandom)
                {
                    arraylabel8[0] = arrayplay[7 + 8 * 0];
                    arraylabel8[1] = arrayplay[7 + 8 * 1];
                    arraylabel8[2] = arrayplay[7 + 8 * 2];
                    arraylabel8[3] = arrayplay[7 + 8 * 3];
                    arraylabel8[4] = arrayplay[7 + 8 * 4];
                    arraylabel8[5] = arrayplay[7 + 8 * 5];
                    arraylabel8[6] = arrayplay[7 + 8 * 6];
                    arraylabel8[7] = arrayplay[7 + 8 * 7];
                }
                countlabel8 = 0;
                foreach (int values in arraylabel8)
                {
                    if (values == 1)
                        countlabel8++;
                    else
                    {
                        countarraylabel8.Add(countlabel8);
                        countlabel8 = 0;
                    }
                }
                countarraylabel8.Add(countlabel8);
                label8.Text = string.Join("\n", Array.ConvertAll(countarraylabel8.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel8.Clear();
                if (create)
                {
                    arraylabel9[0] = arraycreate[0];
                    arraylabel9[1] = arraycreate[1];
                    arraylabel9[2] = arraycreate[2];
                    arraylabel9[3] = arraycreate[3];
                    arraylabel9[4] = arraycreate[4];
                    arraylabel9[5] = arraycreate[5];
                    arraylabel9[6] = arraycreate[6];
                    arraylabel9[7] = arraycreate[7];
                }
                if (play | playrandom)
                {
                    arraylabel9[0] = arrayplay[0];
                    arraylabel9[1] = arrayplay[1];
                    arraylabel9[2] = arrayplay[2];
                    arraylabel9[3] = arrayplay[3];
                    arraylabel9[4] = arrayplay[4];
                    arraylabel9[5] = arrayplay[5];
                    arraylabel9[6] = arrayplay[6];
                    arraylabel9[7] = arrayplay[7];
                }
                countlabel9 = 0;
                foreach (int values in arraylabel9)
                {
                    if (values == 1)
                        countlabel9++;
                    else
                    {
                        countarraylabel9.Add(countlabel9);
                        countlabel9 = 0;
                    }
                }
                countarraylabel9.Add(countlabel9);
                label9.Text = string.Join(" ", Array.ConvertAll(countarraylabel9.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel9.Clear();
                if (create)
                {
                    arraylabel10[0] = arraycreate[8];
                    arraylabel10[1] = arraycreate[9];
                    arraylabel10[2] = arraycreate[10];
                    arraylabel10[3] = arraycreate[11];
                    arraylabel10[4] = arraycreate[12];
                    arraylabel10[5] = arraycreate[13];
                    arraylabel10[6] = arraycreate[14];
                    arraylabel10[7] = arraycreate[15];
                }
                if (play | playrandom)
                {
                    arraylabel10[0] = arrayplay[8];
                    arraylabel10[1] = arrayplay[9];
                    arraylabel10[2] = arrayplay[10];
                    arraylabel10[3] = arrayplay[11];
                    arraylabel10[4] = arrayplay[12];
                    arraylabel10[5] = arrayplay[13];
                    arraylabel10[6] = arrayplay[14];
                    arraylabel10[7] = arrayplay[15];
                }
                countlabel10 = 0;
                foreach (int values in arraylabel10)
                {
                    if (values == 1)
                        countlabel10++;
                    else
                    {
                        countarraylabel10.Add(countlabel10);
                        countlabel10 = 0;
                    }
                }
                countarraylabel10.Add(countlabel10);
                label10.Text = string.Join(" ", Array.ConvertAll(countarraylabel10.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel10.Clear();
                if (create)
                {
                    arraylabel11[0] = arraycreate[16];
                    arraylabel11[1] = arraycreate[17];
                    arraylabel11[2] = arraycreate[18];
                    arraylabel11[3] = arraycreate[19];
                    arraylabel11[4] = arraycreate[20];
                    arraylabel11[5] = arraycreate[21];
                    arraylabel11[6] = arraycreate[22];
                    arraylabel11[7] = arraycreate[23];
                }
                if (play | playrandom)
                {
                    arraylabel11[0] = arrayplay[16];
                    arraylabel11[1] = arrayplay[17];
                    arraylabel11[2] = arrayplay[18];
                    arraylabel11[3] = arrayplay[19];
                    arraylabel11[4] = arrayplay[20];
                    arraylabel11[5] = arrayplay[21];
                    arraylabel11[6] = arrayplay[22];
                    arraylabel11[7] = arrayplay[23];
                }
                countlabel11 = 0;
                foreach (int values in arraylabel11)
                {
                    if (values == 1)
                        countlabel11++;
                    else
                    {
                        countarraylabel11.Add(countlabel11);
                        countlabel11 = 0;
                    }
                }
                countarraylabel11.Add(countlabel11);
                label11.Text = string.Join(" ", Array.ConvertAll(countarraylabel11.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel11.Clear();
                if (create)
                {
                    arraylabel12[0] = arraycreate[24];
                    arraylabel12[1] = arraycreate[25];
                    arraylabel12[2] = arraycreate[26];
                    arraylabel12[3] = arraycreate[27];
                    arraylabel12[4] = arraycreate[28];
                    arraylabel12[5] = arraycreate[29];
                    arraylabel12[6] = arraycreate[30];
                    arraylabel12[7] = arraycreate[31];
                }
                if (play | playrandom)
                {
                    arraylabel12[0] = arrayplay[24];
                    arraylabel12[1] = arrayplay[25];
                    arraylabel12[2] = arrayplay[26];
                    arraylabel12[3] = arrayplay[27];
                    arraylabel12[4] = arrayplay[28];
                    arraylabel12[5] = arrayplay[29];
                    arraylabel12[6] = arrayplay[30];
                    arraylabel12[7] = arrayplay[31];
                }
                countlabel12 = 0;
                foreach (int values in arraylabel12)
                {
                    if (values == 1)
                        countlabel12++;
                    else
                    {
                        countarraylabel12.Add(countlabel12);
                        countlabel12 = 0;
                    }
                }
                countarraylabel12.Add(countlabel12);
                label12.Text = string.Join(" ", Array.ConvertAll(countarraylabel12.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel12.Clear();
                if (create)
                {
                    arraylabel13[0] = arraycreate[32];
                    arraylabel13[1] = arraycreate[33];
                    arraylabel13[2] = arraycreate[34];
                    arraylabel13[3] = arraycreate[35];
                    arraylabel13[4] = arraycreate[36];
                    arraylabel13[5] = arraycreate[37];
                    arraylabel13[6] = arraycreate[38];
                    arraylabel13[7] = arraycreate[39];
                }
                if (play | playrandom)
                {
                    arraylabel13[0] = arrayplay[32];
                    arraylabel13[1] = arrayplay[33];
                    arraylabel13[2] = arrayplay[34];
                    arraylabel13[3] = arrayplay[35];
                    arraylabel13[4] = arrayplay[36];
                    arraylabel13[5] = arrayplay[37];
                    arraylabel13[6] = arrayplay[38];
                    arraylabel13[7] = arrayplay[39];
                }
                countlabel13 = 0;
                foreach (int values in arraylabel13)
                {
                    if (values == 1)
                        countlabel13++;
                    else
                    {
                        countarraylabel13.Add(countlabel13);
                        countlabel13 = 0;
                    }
                }
                countarraylabel13.Add(countlabel13);
                label13.Text = string.Join(" ", Array.ConvertAll(countarraylabel13.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel13.Clear();
                if (create)
                {
                    arraylabel14[0] = arraycreate[40];
                    arraylabel14[1] = arraycreate[41];
                    arraylabel14[2] = arraycreate[42];
                    arraylabel14[3] = arraycreate[43];
                    arraylabel14[4] = arraycreate[44];
                    arraylabel14[5] = arraycreate[45];
                    arraylabel14[6] = arraycreate[46];
                    arraylabel14[7] = arraycreate[47];
                }
                if (play | playrandom)
                {
                    arraylabel14[0] = arrayplay[40];
                    arraylabel14[1] = arrayplay[41];
                    arraylabel14[2] = arrayplay[42];
                    arraylabel14[3] = arrayplay[43];
                    arraylabel14[4] = arrayplay[44];
                    arraylabel14[5] = arrayplay[45];
                    arraylabel14[6] = arrayplay[46];
                    arraylabel14[7] = arrayplay[47];
                }
                countlabel14 = 0;
                foreach (int values in arraylabel14)
                {
                    if (values == 1)
                        countlabel14++;
                    else
                    {
                        countarraylabel14.Add(countlabel14);
                        countlabel14 = 0;
                    }
                }
                countarraylabel14.Add(countlabel14);
                label14.Text = string.Join(" ", Array.ConvertAll(countarraylabel14.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel14.Clear();
                if (create)
                {
                    arraylabel15[0] = arraycreate[48];
                    arraylabel15[1] = arraycreate[49];
                    arraylabel15[2] = arraycreate[50];
                    arraylabel15[3] = arraycreate[51];
                    arraylabel15[4] = arraycreate[52];
                    arraylabel15[5] = arraycreate[53];
                    arraylabel15[6] = arraycreate[54];
                    arraylabel15[7] = arraycreate[55];
                }
                if (play | playrandom)
                {
                    arraylabel15[0] = arrayplay[48];
                    arraylabel15[1] = arrayplay[49];
                    arraylabel15[2] = arrayplay[50];
                    arraylabel15[3] = arrayplay[51];
                    arraylabel15[4] = arrayplay[52];
                    arraylabel15[5] = arrayplay[53];
                    arraylabel15[6] = arrayplay[54];
                    arraylabel15[7] = arrayplay[55];
                }
                countlabel15 = 0;
                foreach (int values in arraylabel15)
                {
                    if (values == 1)
                        countlabel15++;
                    else
                    {
                        countarraylabel15.Add(countlabel15);
                        countlabel15 = 0;
                    }
                }
                countarraylabel15.Add(countlabel15);
                label15.Text = string.Join(" ", Array.ConvertAll(countarraylabel15.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel15.Clear();
                if (create)
                {
                    arraylabel16[0] = arraycreate[56];
                    arraylabel16[1] = arraycreate[57];
                    arraylabel16[2] = arraycreate[58];
                    arraylabel16[3] = arraycreate[59];
                    arraylabel16[4] = arraycreate[60];
                    arraylabel16[5] = arraycreate[61];
                    arraylabel16[6] = arraycreate[62];
                    arraylabel16[7] = arraycreate[63];
                }
                if (play | playrandom)
                {
                    arraylabel16[0] = arrayplay[56];
                    arraylabel16[1] = arrayplay[57];
                    arraylabel16[2] = arrayplay[58];
                    arraylabel16[3] = arrayplay[59];
                    arraylabel16[4] = arrayplay[60];
                    arraylabel16[5] = arrayplay[61];
                    arraylabel16[6] = arrayplay[62];
                    arraylabel16[7] = arrayplay[63];
                }
                countlabel16 = 0;
                foreach (int values in arraylabel16)
                {
                    if (values == 1)
                        countlabel16++;
                    else
                    {
                        countarraylabel16.Add(countlabel16);
                        countlabel16 = 0;
                    }
                }
                countarraylabel16.Add(countlabel16);
                label16.Text = string.Join(" ", Array.ConvertAll(countarraylabel16.Where(i => i != 0).ToArray(), i => i.ToString()));
                countarraylabel16.Clear();
                if ((play | playrandom) & arraycreate.SequenceEqual(arrayplay) & !showbravo)
                {
                    showbravo = true;
                    const string message = "Congratulation";
                    const string caption = "You finished it";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        private void button65_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                play = true;
                stopwatch = new Stopwatch();
                stopwatch.Start();
                button65.BackColor = Color.Azure;
                playrandom = false;
                button66.BackColor = SystemColors.Control;
                create = false;
                button67.BackColor = SystemColors.Control;
                textBox1.Hide();
                label18.Hide();
                showbravo = false;
            }
            else
            {
                stopwatch.Stop();
                play = false;
                button65.BackColor = SystemColors.Control;
            }
        }
        private void button66_Click(object sender, EventArgs e)
        {
            if (!playrandom)
            {
                playrandom = true;
                stopwatch = new Stopwatch();
                stopwatch.Start();
                button66.BackColor = Color.Azure;
                play = false;
                button65.BackColor = SystemColors.Control;
                create = false;
                button67.BackColor = SystemColors.Control;
                textBox1.Hide();
                label18.Hide();
                Random rnd = new Random();
                int rndtofound;
                int i = 0;
                System.Windows.Forms.FolderBrowserDialog browse = new System.Windows.Forms.FolderBrowserDialog();
                using (var output = System.IO.File.Create("random"))
                {
                    rndtofound = 1 + rnd.Next(System.IO.Directory.GetFiles(@browse.SelectedPath, "*").Count() - 1);
                    foreach (var file in System.IO.Directory.GetFiles(@browse.SelectedPath, "*"))
                    {
                        using (var input = System.IO.File.OpenRead(file))
                        {
                            i++;
                            if (i == rndtofound)
                            {
                                input.CopyTo(output);
                                break;
                            }
                        }
                    }
                }
                System.IO.StreamReader randomfile = new System.IO.StreamReader("random");
                arrayplayfromstring = randomfile.ReadLine();
                arraycreatefromstring = randomfile.ReadLine();
                randomfile.Close();
                arrayplay = Array.ConvertAll<string, int>(arrayplayfromstring.Split(','), Convert.ToInt32);
                arraycreate = Array.ConvertAll<string, int>(arraycreatefromstring.Split(','), Convert.ToInt32);
                constructNanogram(arraycreate);
                showbravo = false;
            }
            else
            {
                stopwatch.Stop();
                playrandom = false;
                button66.BackColor = SystemColors.Control;
            }
        }
        private void button67_Click(object sender, EventArgs e)
        {
            if (!create)
            {
                create = true;
                stopwatch = new Stopwatch();
                stopwatch.Start();
                button67.BackColor = Color.Azure;
                play = false;
                button65.BackColor = SystemColors.Control;
                playrandom = false;
                button66.BackColor = SystemColors.Control;
                textBox1.Show();
                label18.Show();
                showbravo = false;
            }
            else
            {
                stopwatch.Stop();
                create = false;
                button67.BackColor = SystemColors.Control;
            }
        }
        private void button68_Click(object sender, EventArgs e)
        {
            String charstore;
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                charstore = saveFileDialog1.FileName;
                System.IO.StreamWriter file = new System.IO.StreamWriter(charstore);
                if (create)
                {
                    file.WriteLine(string.Join(",", Array.ConvertAll(arraycreate, i => i.ToString())));
                    arrayplay = new int[64] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    file.WriteLine(string.Join(",", Array.ConvertAll(arrayplay, i => i.ToString())));
                }
                if (play | playrandom)
                {
                    file.WriteLine(string.Join(",", Array.ConvertAll(arrayplay, i => i.ToString())));
                    file.WriteLine(string.Join(",", Array.ConvertAll(arraycreate, i => i.ToString())));
                }
                file.Close();
            }
        }
        private void button69_Click(object sender, EventArgs e)
        {
            if (create | play)
            {
                String myRead;
                System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myRead = openFileDialog1.FileName;
                    System.IO.StreamReader file = new System.IO.StreamReader(myRead);
                    arrayplayfromstring = file.ReadLine();
                    arraycreatefromstring = file.ReadLine();
                    file.Close();
                }
                arrayplay = Array.ConvertAll<string, int>(arrayplayfromstring.Split(','), Convert.ToInt32);
                arraycreate = Array.ConvertAll<string, int>(arraycreatefromstring.Split(','), Convert.ToInt32);
                if (create)
                {
                    arraycreate = arrayplay;
                    constructNanogram(arrayplay);
                }
                if (play)
                {
                    constructNanogram(arraycreate);
                }
            }
        }
        private void constructNanogram(int[] array)
        {
            if (array[0] == 1)
            {
                button1.BackColor = Color.Black;
                b1 = 1;
            }
            else
            {
                if (array[0] == 2)
                {
                    button1.BackColor = Color.White;
                    b1 = 2;
                }
                else
                {
                    if (array[0] == 0)
                    {
                        button1.BackColor = Color.Gray;
                        b1 = 0;
                    }
                }
            }
            if (array[1] == 1)
            {
                button2.BackColor = Color.Black;
                b2 = 1;
            }
            else
            {
                if (array[1] == 2)
                {
                    button2.BackColor = Color.White;
                    b2 = 2;
                }
                else
                {
                    if (array[1] == 0)
                    {
                        button2.BackColor = Color.Gray;
                        b2 = 0;
                    }
                }
            }
            if (array[2] == 1)
            {
                button3.BackColor = Color.Black;
                b3 = 1;
            }
            else
            {
                if (array[2] == 2)
                {
                    button3.BackColor = Color.White;
                    b3 = 2;
                }
                else
                {
                    if (array[2] == 0)
                    {
                        button3.BackColor = Color.Gray;
                        b3 = 0;
                    }
                }
            }
            if (array[3] == 1)
            {
                button4.BackColor = Color.Black;
                b4 = 1;
            }
            else
            {
                if (array[3] == 2)
                {
                    button4.BackColor = Color.White;
                    b4 = 2;
                }
                else
                {
                    if (array[3] == 0)
                    {
                        button4.BackColor = Color.Gray;
                        b4 = 0;
                    }
                }
            }
            if (array[4] == 1)
            {
                button5.BackColor = Color.Black;
                b5 = 1;
            }
            else
            {
                if (array[4] == 2)
                {
                    button5.BackColor = Color.White;
                    b5 = 2;
                }
                else
                {
                    if (array[4] == 0)
                    {
                        button5.BackColor = Color.Gray;
                        b5 = 0;
                    }
                }
            }
            if (array[5] == 1)
            {
                button6.BackColor = Color.Black;
                b6 = 1;
            }
            else
            {
                if (array[5] == 2)
                {
                    button6.BackColor = Color.White;
                    b6 = 2;
                }
                else
                {
                    if (array[5] == 0)
                    {
                        button6.BackColor = Color.Gray;
                        b6 = 0;
                    }
                }
            }
            if (array[6] == 1)
            {
                button7.BackColor = Color.Black;
                b7 = 1;
            }
            else
            {
                if (array[6] == 2)
                {
                    button7.BackColor = Color.White;
                    b7 = 2;
                }
                else
                {
                    if (array[6] == 0)
                    {
                        button7.BackColor = Color.Gray;
                        b7 = 0;
                    }
                }
            }
            if (array[7] == 1)
            {
                button8.BackColor = Color.Black;
                b8 = 1;
            }
            else
            {
                if (array[7] == 2)
                {
                    button8.BackColor = Color.White;
                    b8 = 2;
                }
                else
                {
                    if (array[7] == 0)
                    {
                        button8.BackColor = Color.Gray;
                        b8 = 0;
                    }
                }
            }
            if (array[8] == 1)
            {
                button9.BackColor = Color.Black;
                b9 = 1;
            }
            else
            {
                if (array[8] == 2)
                {
                    button9.BackColor = Color.White;
                    b9 = 2;
                }
                else
                {
                    if (array[8] == 0)
                    {
                        button9.BackColor = Color.Gray;
                        b9 = 0;
                    }
                }
            }
            if (array[9] == 1)
            {
                button10.BackColor = Color.Black;
                b10 = 1;
            }
            else
            {
                if (array[9] == 2)
                {
                    button10.BackColor = Color.White;
                    b10 = 2;
                }
                else
                {
                    if (array[9] == 0)
                    {
                        button10.BackColor = Color.Gray;
                        b10 = 0;
                    }
                }
            }
            if (array[10] == 1)
            {
                button11.BackColor = Color.Black;
                b11 = 1;
            }
            else
            {
                if (array[10] == 2)
                {
                    button11.BackColor = Color.White;
                    b11 = 2;
                }
                else
                {
                    if (array[10] == 0)
                    {
                        button11.BackColor = Color.Gray;
                        b11 = 0;
                    }
                }
            }
            if (array[11] == 1)
            {
                button12.BackColor = Color.Black;
                b12 = 1;
            }
            else
            {
                if (array[11] == 2)
                {
                    button12.BackColor = Color.White;
                    b12 = 2;
                }
                else
                {
                    if (array[11] == 0)
                    {
                        button12.BackColor = Color.Gray;
                        b12 = 0;
                    }
                }
            }
            if (array[12] == 1)
            {
                button13.BackColor = Color.Black;
                b13 = 1;
            }
            else
            {
                if (array[12] == 2)
                {
                    button13.BackColor = Color.White;
                    b13 = 2;
                }
                else
                {
                    if (array[12] == 0)
                    {
                        button13.BackColor = Color.Gray;
                        b13 = 0;
                    }
                }
            }
            if (array[13] == 1)
            {
                button14.BackColor = Color.Black;
                b14 = 1;
            }
            else
            {
                if (array[13] == 2)
                {
                    button14.BackColor = Color.White;
                    b14 = 2;
                }
                else
                {
                    if (array[13] == 0)
                    {
                        button14.BackColor = Color.Gray;
                        b14 = 0;
                    }
                }
            }
            if (array[14] == 1)
            {
                button15.BackColor = Color.Black;
                b15 = 1;
            }
            else
            {
                if (array[14] == 2)
                {
                    button15.BackColor = Color.White;
                    b15 = 2;
                }
                else
                {
                    if (array[14] == 0)
                    {
                        button15.BackColor = Color.Gray;
                        b15 = 0;
                    }
                }
            }
            if (array[15] == 1)
            {
                button16.BackColor = Color.Black;
                b16 = 1;
            }
            else
            {
                if (array[15] == 2)
                {
                    button16.BackColor = Color.White;
                    b16 = 2;
                }
                else
                {
                    if (array[15] == 0)
                    {
                        button16.BackColor = Color.Gray;
                        b16 = 0;
                    }
                }
            }
            if (array[16] == 1)
            {
                button17.BackColor = Color.Black;
                b17 = 1;
            }
            else
            {
                if (array[16] == 2)
                {
                    button17.BackColor = Color.White;
                    b17 = 2;
                }
                else
                {
                    if (array[16] == 0)
                    {
                        button17.BackColor = Color.Gray;
                        b17 = 0;
                    }
                }
            }
            if (array[17] == 1)
            {
                button18.BackColor = Color.Black;
                b18 = 1;
            }
            else
            {
                if (array[17] == 2)
                {
                    button18.BackColor = Color.White;
                    b18 = 2;
                }
                else
                {
                    if (array[17] == 0)
                    {
                        button18.BackColor = Color.Gray;
                        b18 = 0;
                    }
                }
            }
            if (array[18] == 1)
            {
                button19.BackColor = Color.Black;
                b19 = 1;
            }
            else
            {
                if (array[18] == 2)
                {
                    button19.BackColor = Color.White;
                    b19 = 2;
                }
                else
                {
                    if (array[18] == 0)
                    {
                        button19.BackColor = Color.Gray;
                        b19 = 0;
                    }
                }
            }
            if (array[19] == 1)
            {
                button20.BackColor = Color.Black;
                b20 = 1;
            }
            else
            {
                if (array[19] == 2)
                {
                    button20.BackColor = Color.White;
                    b20 = 2;
                }
                else
                {
                    if (array[19] == 0)
                    {
                        button20.BackColor = Color.Gray;
                        b20 = 0;
                    }
                }
            }
            if (array[20] == 1)
            {
                button21.BackColor = Color.Black;
                b21 = 1;
            }
            else
            {
                if (array[20] == 2)
                {
                    button21.BackColor = Color.White;
                    b21 = 2;
                }
                else
                {
                    if (array[20] == 0)
                    {
                        button21.BackColor = Color.Gray;
                        b21 = 0;
                    }
                }
            }
            if (array[21] == 1)
            {
                button22.BackColor = Color.Black;
                b22 = 1;
            }
            else
            {
                if (array[21] == 2)
                {
                    button22.BackColor = Color.White;
                    b22 = 2;
                }
                else
                {
                    if (array[21] == 0)
                    {
                        button22.BackColor = Color.Gray;
                        b22 = 0;
                    }
                }
            }
            if (array[22] == 1)
            {
                button23.BackColor = Color.Black;
                b23 = 1;
            }
            else
            {
                if (array[22] == 2)
                {
                    button23.BackColor = Color.White;
                    b23 = 2;
                }
                else
                {
                    if (array[22] == 0)
                    {
                        button23.BackColor = Color.Gray;
                        b23 = 0;
                    }
                }
            }
            if (array[23] == 1)
            {
                button24.BackColor = Color.Black;
                b24 = 1;
            }
            else
            {
                if (array[23] == 2)
                {
                    button24.BackColor = Color.White;
                    b24 = 2;
                }
                else
                {
                    if (array[23] == 0)
                    {
                        button24.BackColor = Color.Gray;
                        b24 = 0;
                    }
                }
            }
            if (array[24] == 1)
            {
                button25.BackColor = Color.Black;
                b25 = 1;
            }
            else
            {
                if (array[24] == 2)
                {
                    button25.BackColor = Color.White;
                    b25 = 2;
                }
                else
                {
                    if (array[24] == 0)
                    {
                        button25.BackColor = Color.Gray;
                        b25 = 0;
                    }
                }
            }
            if (array[25] == 1)
            {
                button26.BackColor = Color.Black;
                b26 = 1;
            }
            else
            {
                if (array[25] == 2)
                {
                    button26.BackColor = Color.White;
                    b26 = 2;
                }
                else
                {
                    if (array[25] == 0)
                    {
                        button26.BackColor = Color.Gray;
                        b26 = 0;
                    }
                }
            }
            if (array[26] == 1)
            {
                button27.BackColor = Color.Black;
                b27 = 1;
            }
            else
            {
                if (array[26] == 2)
                {
                    button27.BackColor = Color.White;
                    b27 = 2;
                }
                else
                {
                    if (array[26] == 0)
                    {
                        button27.BackColor = Color.Gray;
                        b27 = 0;
                    }
                }
            }
            if (array[27] == 1)
            {
                button28.BackColor = Color.Black;
                b28 = 1;
            }
            else
            {
                if (array[27] == 2)
                {
                    button28.BackColor = Color.White;
                    b28 = 2;
                }
                else
                {
                    if (array[27] == 0)
                    {
                        button28.BackColor = Color.Gray;
                        b28 = 0;
                    }
                }
            }
            if (array[28] == 1)
            {
                button29.BackColor = Color.Black;
                b29 = 1;
            }
            else
            {
                if (array[28] == 2)
                {
                    button29.BackColor = Color.White;
                    b29 = 2;
                }
                else
                {
                    if (array[28] == 0)
                    {
                        button29.BackColor = Color.Gray;
                        b29 = 0;
                    }
                }
            }
            if (array[29] == 1)
            {
                button30.BackColor = Color.Black;
                b30 = 1;
            }
            else
            {
                if (array[29] == 2)
                {
                    button30.BackColor = Color.White;
                    b30 = 2;
                }
                else
                {
                    if (array[29] == 0)
                    {
                        button30.BackColor = Color.Gray;
                        b30 = 0;
                    }
                }
            }
            if (array[30] == 1)
            {
                button31.BackColor = Color.Black;
                b31 = 1;
            }
            else
            {
                if (array[30] == 2)
                {
                    button31.BackColor = Color.White;
                    b31 = 2;
                }
                else
                {
                    if (array[30] == 0)
                    {
                        button31.BackColor = Color.Gray;
                        b31 = 0;
                    }
                }
            }
            if (array[31] == 1)
            {
                button32.BackColor = Color.Black;
                b32 = 1;
            }
            else
            {
                if (array[31] == 2)
                {
                    button32.BackColor = Color.White;
                    b32 = 2;
                }
                else
                {
                    if (array[31] == 0)
                    {
                        button32.BackColor = Color.Gray;
                        b32 = 0;
                    }
                }
            }
            if (array[32] == 1)
            {
                button33.BackColor = Color.Black;
                b33 = 1;
            }
            else
            {
                if (array[32] == 2)
                {
                    button33.BackColor = Color.White;
                    b33 = 2;
                }
                else
                {
                    if (array[32] == 0)
                    {
                        button33.BackColor = Color.Gray;
                        b33 = 0;
                    }
                }
            }
            if (array[33] == 1)
            {
                button34.BackColor = Color.Black;
                b34 = 1;
            }
            else
            {
                if (array[33] == 2)
                {
                    button34.BackColor = Color.White;
                    b34 = 2;
                }
                else
                {
                    if (array[33] == 0)
                    {
                        button34.BackColor = Color.Gray;
                        b34 = 0;
                    }
                }
            }
            if (array[34] == 1)
            {
                button35.BackColor = Color.Black;
                b35 = 1;
            }
            else
            {
                if (array[34] == 2)
                {
                    button35.BackColor = Color.White;
                    b35 = 2;
                }
                else
                {
                    if (array[34] == 0)
                    {
                        button35.BackColor = Color.Gray;
                        b35 = 0;
                    }
                }
            }
            if (array[35] == 1)
            {
                button36.BackColor = Color.Black;
                b36 = 1;
            }
            else
            {
                if (array[35] == 2)
                {
                    button36.BackColor = Color.White;
                    b36 = 2;
                }
                else
                {
                    if (array[35] == 0)
                    {
                        button36.BackColor = Color.Gray;
                        b36 = 0;
                    }
                }
            }
            if (array[36] == 1)
            {
                button37.BackColor = Color.Black;
                b37 = 1;
            }
            else
            {
                if (array[36] == 2)
                {
                    button37.BackColor = Color.White;
                    b37 = 2;
                }
                else
                {
                    if (array[36] == 0)
                    {
                        button37.BackColor = Color.Gray;
                        b37 = 0;
                    }
                }
            }
            if (array[37] == 1)
            {
                button38.BackColor = Color.Black;
                b38 = 1;
            }
            else
            {
                if (array[37] == 2)
                {
                    button38.BackColor = Color.White;
                    b38 = 2;
                }
                else
                {
                    if (array[37] == 0)
                    {
                        button38.BackColor = Color.Gray;
                        b38 = 0;
                    }
                }
            }
            if (array[38] == 1)
            {
                button39.BackColor = Color.Black;
                b39 = 1;
            }
            else
            {
                if (array[38] == 2)
                {
                    button39.BackColor = Color.White;
                    b39 = 2;
                }
                else
                {
                    if (array[38] == 0)
                    {
                        button39.BackColor = Color.Gray;
                        b39 = 0;
                    }
                }
            }
            if (array[39] == 1)
            {
                button40.BackColor = Color.Black;
                b40 = 1;
            }
            else
            {
                if (array[39] == 2)
                {
                    button40.BackColor = Color.White;
                    b40 = 2;
                }
                else
                {
                    if (array[39] == 0)
                    {
                        button40.BackColor = Color.Gray;
                        b40 = 0;
                    }
                }
            }
            if (array[40] == 1)
            {
                button41.BackColor = Color.Black;
                b41 = 1;
            }
            else
            {
                if (array[40] == 2)
                {
                    button41.BackColor = Color.White;
                    b41 = 2;
                }
                else
                {
                    if (array[40] == 0)
                    {
                        button41.BackColor = Color.Gray;
                        b41 = 0;
                    }
                }
            }
            if (array[41] == 1)
            {
                button42.BackColor = Color.Black;
                b42 = 1;
            }
            else
            {
                if (array[41] == 2)
                {
                    button42.BackColor = Color.White;
                    b42 = 2;
                }
                else
                {
                    if (array[41] == 0)
                    {
                        button42.BackColor = Color.Gray;
                        b42 = 0;
                    }
                }
            }
            if (array[42] == 1)
            {
                button43.BackColor = Color.Black;
                b43 = 1;
            }
            else
            {
                if (array[42] == 2)
                {
                    button43.BackColor = Color.White;
                    b43 = 2;
                }
                else
                {
                    if (array[42] == 0)
                    {
                        button43.BackColor = Color.Gray;
                        b43 = 0;
                    }
                }
            }
            if (array[43] == 1)
            {
                button44.BackColor = Color.Black;
                b44 = 1;
            }
            else
            {
                if (array[43] == 2)
                {
                    button44.BackColor = Color.White;
                    b44 = 2;
                }
                else
                {
                    if (array[43] == 0)
                    {
                        button44.BackColor = Color.Gray;
                        b44 = 0;
                    }
                }
            }
            if (array[44] == 1)
            {
                button45.BackColor = Color.Black;
                b45 = 1;
            }
            else
            {
                if (array[44] == 2)
                {
                    button45.BackColor = Color.White;
                    b45 = 2;
                }
                else
                {
                    if (array[44] == 0)
                    {
                        button45.BackColor = Color.Gray;
                        b45 = 0;
                    }
                }
            }
            if (array[45] == 1)
            {
                button46.BackColor = Color.Black;
                b46 = 1;
            }
            else
            {
                if (array[45] == 2)
                {
                    button46.BackColor = Color.White;
                    b46 = 2;
                }
                else
                {
                    if (array[45] == 0)
                    {
                        button46.BackColor = Color.Gray;
                        b46 = 0;
                    }
                }
            }
            if (array[46] == 1)
            {
                button47.BackColor = Color.Black;
                b47 = 1;
            }
            else
            {
                if (array[46] == 2)
                {
                    button47.BackColor = Color.White;
                    b47 = 2;
                }
                else
                {
                    if (array[46] == 0)
                    {
                        button47.BackColor = Color.Gray;
                        b47 = 0;
                    }
                }
            }
            if (array[47] == 1)
            {
                button48.BackColor = Color.Black;
                b48 = 1;
            }
            else
            {
                if (array[47] == 2)
                {
                    button48.BackColor = Color.White;
                    b48 = 2;
                }
                else
                {
                    if (array[47] == 0)
                    {
                        button48.BackColor = Color.Gray;
                        b48 = 0;
                    }
                }
            }
            if (array[48] == 1)
            {
                button49.BackColor = Color.Black;
                b49 = 1;
            }
            else
            {
                if (array[48] == 2)
                {
                    button49.BackColor = Color.White;
                    b49 = 2;
                }
                else
                {
                    if (array[48] == 0)
                    {
                        button49.BackColor = Color.Gray;
                        b49 = 0;
                    }
                }
            }
            if (array[49] == 1)
            {
                button50.BackColor = Color.Black;
                b50 = 1;
            }
            else
            {
                if (array[49] == 2)
                {
                    button50.BackColor = Color.White;
                    b50 = 2;
                }
                else
                {
                    if (array[49] == 0)
                    {
                        button50.BackColor = Color.Gray;
                        b50 = 0;
                    }
                }
            }
            if (array[50] == 1)
            {
                button51.BackColor = Color.Black;
                b51 = 1;
            }
            else
            {
                if (array[50] == 2)
                {
                    button51.BackColor = Color.White;
                    b51 = 2;
                }
                else
                {
                    if (array[50] == 0)
                    {
                        button51.BackColor = Color.Gray;
                        b51 = 0;
                    }
                }
            }
            if (array[51] == 1)
            {
                button52.BackColor = Color.Black;
                b52 = 1;
            }
            else
            {
                if (array[51] == 2)
                {
                    button52.BackColor = Color.White;
                    b52 = 2;
                }
                else
                {
                    if (array[51] == 0)
                    {
                        button52.BackColor = Color.Gray;
                        b52 = 0;
                    }
                }
            }
            if (array[52] == 1)
            {
                button53.BackColor = Color.Black;
                b53 = 1;
            }
            else
            {
                if (array[52] == 2)
                {
                    button53.BackColor = Color.White;
                    b53 = 2;
                }
                else
                {
                    if (array[52] == 0)
                    {
                        button53.BackColor = Color.Gray;
                        b53 = 0;
                    }
                }
            }
            if (array[53] == 1)
            {
                button54.BackColor = Color.Black;
                b54 = 1;
            }
            else
            {
                if (array[53] == 2)
                {
                    button54.BackColor = Color.White;
                    b54 = 2;
                }
                else
                {
                    if (array[53] == 0)
                    {
                        button54.BackColor = Color.Gray;
                        b54 = 0;
                    }
                }
            }
            if (array[54] == 1)
            {
                button55.BackColor = Color.Black;
                b55 = 1;
            }
            else
            {
                if (array[54] == 2)
                {
                    button55.BackColor = Color.White;
                    b55 = 2;
                }
                else
                {
                    if (array[54] == 0)
                    {
                        button55.BackColor = Color.Gray;
                        b55 = 0;
                    }
                }
            }
            if (array[55] == 1)
            {
                button56.BackColor = Color.Black;
                b56 = 1;
            }
            else
            {
                if (array[55] == 2)
                {
                    button56.BackColor = Color.White;
                    b56 = 2;
                }
                else
                {
                    if (array[55] == 0)
                    {
                        button56.BackColor = Color.Gray;
                        b56 = 0;
                    }
                }
            }
            if (array[56] == 1)
            {
                button57.BackColor = Color.Black;
                b57 = 1;
            }
            else
            {
                if (array[56] == 2)
                {
                    button57.BackColor = Color.White;
                    b57 = 2;
                }
                else
                {
                    if (array[56] == 0)
                    {
                        button57.BackColor = Color.Gray;
                        b57 = 0;
                    }
                }
            }
            if (array[57] == 1)
            {
                button58.BackColor = Color.Black;
                b58 = 1;
            }
            else
            {
                if (array[57] == 2)
                {
                    button58.BackColor = Color.White;
                    b58 = 2;
                }
                else
                {
                    if (array[57] == 0)
                    {
                        button58.BackColor = Color.Gray;
                        b58 = 0;
                    }
                }
            }
            if (array[58] == 1)
            {
                button59.BackColor = Color.Black;
                b59 = 1;
            }
            else
            {
                if (array[58] == 2)
                {
                    button59.BackColor = Color.White;
                    b59 = 2;
                }
                else
                {
                    if (array[58] == 0)
                    {
                        button59.BackColor = Color.Gray;
                        b59 = 0;
                    }
                }
            }
            if (array[59] == 1)
            {
                button60.BackColor = Color.Black;
                b60 = 1;
            }
            else
            {
                if (array[59] == 2)
                {
                    button60.BackColor = Color.White;
                    b60 = 2;
                }
                else
                {
                    if (array[59] == 0)
                    {
                        button60.BackColor = Color.Gray;
                        b60 = 0;
                    }
                }
            }
            if (array[60] == 1)
            {
                button61.BackColor = Color.Black;
                b61 = 1;
            }
            else
            {
                if (array[60] == 2)
                {
                    button61.BackColor = Color.White;
                    b61 = 2;
                }
                else
                {
                    if (array[60] == 0)
                    {
                        button61.BackColor = Color.Gray;
                        b61 = 0;
                    }
                }
            }
            if (array[61] == 1)
            {
                button62.BackColor = Color.Black;
                b62 = 1;
            }
            else
            {
                if (array[61] == 2)
                {
                    button62.BackColor = Color.White;
                    b62 = 2;
                }
                else
                {
                    if (array[61] == 0)
                    {
                        button62.BackColor = Color.Gray;
                        b62 = 0;
                    }
                }
            }
            if (array[62] == 1)
            {
                button63.BackColor = Color.Black;
                b63 = 1;
            }
            else
            {
                if (array[62] == 2)
                {
                    button63.BackColor = Color.White;
                    b63 = 2;
                }
                else
                {
                    if (array[62] == 0)
                    {
                        button63.BackColor = Color.Gray;
                        b63 = 0;
                    }
                }
            }
            if (array[63] == 1)
            {
                button64.BackColor = Color.Black;
                b64 = 1;
            }
            else
            {
                if (array[63] == 2)
                {
                    button64.BackColor = Color.White;
                    b64 = 2;
                }
                else
                {
                    if (array[63] == 0)
                    {
                        button64.BackColor = Color.Gray;
                        b64 = 0;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (b1 == 0)
            {
                arraycreate[0] = 1;
                button1.BackColor = Color.Black;
                b1 = 1;
            }
            else
            {
                if (b1 == 1)
                {
                    arraycreate[0] = 2;
                    button1.BackColor = Color.White;
                    b1 = 2;
                }
                else
                {
                    if (b1 == 2)
                    {
                        arraycreate[0] = 0;
                        button1.BackColor = Color.Gray;
                        b1 = 0;
                    }
                }
            } 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (b2 == 0)
            {
                arraycreate[1] = 1;
                button2.BackColor = Color.Black;
                b2 = 1;
            }
            else
            {
                if (b2 == 1)
                {
                    arraycreate[1] = 2;
                    button2.BackColor = Color.White;
                    b2 = 2;
                }
                else
                {
                    if (b2 == 2)
                    {
                        arraycreate[1] = 0;
                        button2.BackColor = Color.Gray;
                        b2 = 0;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (b3 == 0)
            {
                arraycreate[2] = 1;
                button3.BackColor = Color.Black;
                b3 = 1;
            }
            else
            {
                if (b3 == 1)
                {
                    arraycreate[2] = 2;
                    button3.BackColor = Color.White;
                    b3 = 2;
                }
                else
                {
                    if (b3 == 2)
                    {
                        arraycreate[2] = 0;
                        button3.BackColor = Color.Gray;
                        b3 = 0;
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (b4 == 0)
            {
                arraycreate[3] = 1;
                button4.BackColor = Color.Black;
                b4 = 1;
            }
            else
            {
                if (b4 == 1)
                {
                    arraycreate[3] = 2;
                    button4.BackColor = Color.White;
                    b4 = 2;
                }
                else
                {
                    if (b4 == 2)
                    {
                        arraycreate[3] = 0;
                        button4.BackColor = Color.Gray;
                        b4 = 0;
                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (b5 == 0)
            {
                arraycreate[4] = 1;
                button5.BackColor = Color.Black;
                b5 = 1;
            }
            else
            {
                if (b5 == 1)
                {
                    arraycreate[4] = 2;
                    button5.BackColor = Color.White;
                    b5 = 2;
                }
                else
                {
                    if (b5 == 2)
                    {
                        arraycreate[4] = 0;
                        button5.BackColor = Color.Gray;
                        b5 = 0;
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (b6 == 0)
            {
                arraycreate[5] = 1;
                button6.BackColor = Color.Black;
                b6 = 1;
            }
            else
            {
                if (b6 == 1)
                {
                    arraycreate[5] = 2;
                    button6.BackColor = Color.White;
                    b6 = 2;
                }
                else
                {
                    if (b6 == 2)
                    {
                        arraycreate[5] = 0;
                        button6.BackColor = Color.Gray;
                        b6 = 0;
                    }
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (b7 == 0)
            {
                arraycreate[6] = 1;
                button7.BackColor = Color.Black;
                b7 = 1;
            }
            else
            {
                if (b7 == 1)
                {
                    arraycreate[6] = 2;
                    button7.BackColor = Color.White;
                    b7 = 2;
                }
                else
                {
                    if (b7 == 2)
                    {
                        arraycreate[6] = 0;
                        button7.BackColor = Color.Gray;
                        b7 = 0;
                    }
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (b8 == 0)
            {
                arraycreate[7] = 1;
                button8.BackColor = Color.Black;
                b8 = 1;
            }
            else
            {
                if (b8 == 1)
                {
                    arraycreate[7] = 2;
                    button8.BackColor = Color.White;
                    b8 = 2;
                }
                else
                {
                    if (b8 == 2)
                    {
                        arraycreate[7] = 0;
                        button8.BackColor = Color.Gray;
                        b8 = 0;
                    }
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (b9 == 0)
            {
                arraycreate[8] = 1;
                button9.BackColor = Color.Black;
                b9 = 1;
            }
            else
            {
                if (b9 == 1)
                {
                    arraycreate[8] = 2;
                    button9.BackColor = Color.White;
                    b9 = 2;
                }
                else
                {
                    if (b9 == 2)
                    {
                        arraycreate[8] = 0;
                        button9.BackColor = Color.Gray;
                        b9 = 0;
                    }
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (b10 == 0)
            {
                arraycreate[9] = 1;
                button10.BackColor = Color.Black;
                b10 = 1;
            }
            else
            {
                if (b10 == 1)
                {
                    arraycreate[9] = 2;
                    button10.BackColor = Color.White;
                    b10 = 2;
                }
                else
                {
                    if (b10 == 2)
                    {
                        arraycreate[9] = 0;
                        button10.BackColor = Color.Gray;
                        b10 = 0;
                    }
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (b11 == 0)
            {
                arraycreate[10] = 1;
                button11.BackColor = Color.Black;
                b11 = 1;
            }
            else
            {
                if (b11 == 1)
                {
                    arraycreate[10] = 2;
                    button11.BackColor = Color.White;
                    b11 = 2;
                }
                else
                {
                    if (b11 == 2)
                    {
                        arraycreate[10] = 0;
                        button11.BackColor = Color.Gray;
                        b11 = 0;
                    }
                }
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (b12 == 0)
            {
                arraycreate[11] = 1;
                button12.BackColor = Color.Black;
                b12 = 1;
            }
            else
            {
                if (b12 == 1)
                {
                    arraycreate[11] = 2;
                    button12.BackColor = Color.White;
                    b12 = 2;
                }
                else
                {
                    if (b12 == 2)
                    {
                        arraycreate[11] = 0;
                        button12.BackColor = Color.Gray;
                        b12 = 0;
                    }
                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (b13 == 0)
            {
                arraycreate[12] = 1;
                button13.BackColor = Color.Black;
                b13 = 1;
            }
            else
            {
                if (b13 == 1)
                {
                    arraycreate[12] = 2;
                    button13.BackColor = Color.White;
                    b13 = 2;
                }
                else
                {
                    if (b13 == 2)
                    {
                        arraycreate[12] = 0;
                        button13.BackColor = Color.Gray;
                        b13 = 0;
                    }
                }
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (b14 == 0)
            {
                arraycreate[13] = 1;
                button14.BackColor = Color.Black;
                b14 = 1;
            }
            else
            {
                if (b14 == 1)
                {
                    arraycreate[13] = 2;
                    button14.BackColor = Color.White;
                    b14 = 2;
                }
                else
                {
                    if (b14 == 2)
                    {
                        arraycreate[13] = 0;
                        button14.BackColor = Color.Gray;
                        b14 = 0;
                    }
                }
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (b15 == 0)
            {
                arraycreate[14] = 1;
                button15.BackColor = Color.Black;
                b15 = 1;
            }
            else
            {
                if (b15 == 1)
                {
                    arraycreate[14] = 2;
                    button15.BackColor = Color.White;
                    b15 = 2;
                }
                else
                {
                    if (b15 == 2)
                    {
                        arraycreate[14] = 0;
                        button15.BackColor = Color.Gray;
                        b15 = 0;
                    }
                }
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (b16 == 0)
            {
                arraycreate[15] = 1;
                button16.BackColor = Color.Black;
                b16 = 1;
            }
            else
            {
                if (b16 == 1)
                {
                    arraycreate[15] = 2;
                    button16.BackColor = Color.White;
                    b16 = 2;
                }
                else
                {
                    if (b16 == 2)
                    {
                        arraycreate[15] = 0;
                        button16.BackColor = Color.Gray;
                        b16 = 0;
                    }
                }
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (b17 == 0)
            {
                arraycreate[16] = 1;
                button17.BackColor = Color.Black;
                b17 = 1;
            }
            else
            {
                if (b17 == 1)
                {
                    arraycreate[16] = 2;
                    button17.BackColor = Color.White;
                    b17 = 2;
                }
                else
                {
                    if (b17 == 2)
                    {
                        arraycreate[16] = 0;
                        button17.BackColor = Color.Gray;
                        b17 = 0;
                    }
                }
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (b18 == 0)
            {
                arraycreate[17] = 1;
                button18.BackColor = Color.Black;
                b18 = 1;
            }
            else
            {
                if (b18 == 1)
                {
                    arraycreate[17] = 2;
                    button18.BackColor = Color.White;
                    b18 = 2;
                }
                else
                {
                    if (b18 == 2)
                    {
                        arraycreate[17] = 0;
                        button18.BackColor = Color.Gray;
                        b18 = 0;
                    }
                }
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (b19 == 0)
            {
                arraycreate[18] = 1;
                button19.BackColor = Color.Black;
                b19 = 1;
            }
            else
            {
                if (b19 == 1)
                {
                    arraycreate[18] = 2;
                    button19.BackColor = Color.White;
                    b19 = 2;
                }
                else
                {
                    if (b19 == 2)
                    {
                        arraycreate[18] = 0;
                        button19.BackColor = Color.Gray;
                        b19 = 0;
                    }
                }
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (b20 == 0)
            {
                arraycreate[19] = 1;
                button20.BackColor = Color.Black;
                b20 = 1;
            }
            else
            {
                if (b20 == 1)
                {
                    arraycreate[19] = 2;
                    button20.BackColor = Color.White;
                    b20 = 2;
                }
                else
                {
                    if (b20 == 2)
                    {
                        arraycreate[19] = 0;
                        button20.BackColor = Color.Gray;
                        b20 = 0;
                    }
                }
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (b21 == 0)
            {
                arraycreate[20] = 1;
                button21.BackColor = Color.Black;
                b21 = 1;
            }
            else
            {
                if (b21 == 1)
                {
                    arraycreate[20] = 2;
                    button21.BackColor = Color.White;
                    b21 = 2;
                }
                else
                {
                    if (b21 == 2)
                    {
                        arraycreate[20] = 0;
                        button21.BackColor = Color.Gray;
                        b21 = 0;
                    }
                }
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (b22 == 0)
            {
                arraycreate[21] = 1;
                button22.BackColor = Color.Black;
                b22 = 1;
            }
            else
            {
                if (b22 == 1)
                {
                    arraycreate[21] = 2;
                    button22.BackColor = Color.White;
                    b22 = 2;
                }
                else
                {
                    if (b22 == 2)
                    {
                        arraycreate[21] = 0;
                        button22.BackColor = Color.Gray;
                        b22 = 0;
                    }
                }
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (b23 == 0)
            {
                arraycreate[22] = 1;
                button23.BackColor = Color.Black;
                b23 = 1;
            }
            else
            {
                if (b23 == 1)
                {
                    arraycreate[22] = 2;
                    button23.BackColor = Color.White;
                    b23 = 2;
                }
                else
                {
                    if (b23 == 2)
                    {
                        arraycreate[22] = 0;
                        button23.BackColor = Color.Gray;
                        b23 = 0;
                    }
                }
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (b24 == 0)
            {
                arraycreate[23] = 1;
                button24.BackColor = Color.Black;
                b24 = 1;
            }
            else
            {
                if (b24 == 1)
                {
                    arraycreate[23] = 2;
                    button24.BackColor = Color.White;
                    b24 = 2;
                }
                else
                {
                    if (b24 == 2)
                    {
                        arraycreate[23] = 0;
                        button24.BackColor = Color.Gray;
                        b24 = 0;
                    }
                }
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (b25 == 0)
            {
                arraycreate[24] = 1;
                button25.BackColor = Color.Black;
                b25 = 1;
            }
            else
            {
                if (b25 == 1)
                {
                    arraycreate[24] = 2;
                    button25.BackColor = Color.White;
                    b25 = 2;
                }
                else
                {
                    if (b25 == 2)
                    {
                        arraycreate[24] = 0;
                        button25.BackColor = Color.Gray;
                        b25 = 0;
                    }
                }
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (b26 == 0)
            {
                arraycreate[25] = 1;
                button26.BackColor = Color.Black;
                b26 = 1;
            }
            else
            {
                if (b26 == 1)
                {
                    arraycreate[25] = 2;
                    button26.BackColor = Color.White;
                    b26 = 2;
                }
                else
                {
                    if (b26 == 2)
                    {
                        arraycreate[25] = 0;
                        button26.BackColor = Color.Gray;
                        b26 = 0;
                    }
                }
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            if (b27 == 0)
            {
                arraycreate[26] = 1;
                button27.BackColor = Color.Black;
                b27 = 1;
            }
            else
            {
                if (b27 == 1)
                {
                    arraycreate[26] = 2;
                    button27.BackColor = Color.White;
                    b27 = 2;
                }
                else
                {
                    if (b27 == 2)
                    {
                        arraycreate[26] = 0;
                        button27.BackColor = Color.Gray;
                        b27 = 0;
                    }
                }
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (b28 == 0)
            {
                arraycreate[27] = 1;
                button28.BackColor = Color.Black;
                b28 = 1;
            }
            else
            {
                if (b28 == 1)
                {
                    arraycreate[27] = 2;
                    button28.BackColor = Color.White;
                    b28 = 2;
                }
                else
                {
                    if (b28 == 2)
                    {
                        arraycreate[27] = 0;
                        button28.BackColor = Color.Gray;
                        b28 = 0;
                    }
                }
            }
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if (b29 == 0)
            {
                arraycreate[28] = 1;
                button29.BackColor = Color.Black;
                b29 = 1;
            }
            else
            {
                if (b29 == 1)
                {
                    arraycreate[28] = 2;
                    button29.BackColor = Color.White;
                    b29 = 2;
                }
                else
                {
                    if (b29 == 2)
                    {
                        arraycreate[28] = 0;
                        button29.BackColor = Color.Gray;
                        b29 = 0;
                    }
                }
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (b30 == 0)
            {
                arraycreate[29] = 1;
                button30.BackColor = Color.Black;
                b30 = 1;
            }
            else
            {
                if (b30 == 1)
                {
                    arraycreate[29] = 2;
                    button30.BackColor = Color.White;
                    b30 = 2;
                }
                else
                {
                    if (b30 == 2)
                    {
                        arraycreate[29] = 0;
                        button30.BackColor = Color.Gray;
                        b30 = 0;
                    }
                }
            }
        }
        private void button31_Click(object sender, EventArgs e)
        {
            if (b31 == 0)
            {
                arraycreate[30] = 1;
                button31.BackColor = Color.Black;
                b31 = 1;
            }
            else
            {
                if (b31 == 1)
                {
                    arraycreate[30] = 2;
                    button31.BackColor = Color.White;
                    b31 = 2;
                }
                else
                {
                    if (b31 == 2)
                    {
                        arraycreate[30] = 0;
                        button31.BackColor = Color.Gray;
                        b31 = 0;
                    }
                }
            }
        }
        private void button32_Click(object sender, EventArgs e)
        {
            if (b32 == 0)
            {
                arraycreate[31] = 1;
                button32.BackColor = Color.Black;
                b32 = 1;
            }
            else
            {
                if (b32 == 1)
                {
                    arraycreate[31] = 2;
                    button32.BackColor = Color.White;
                    b32 = 2;
                }
                else
                {
                    if (b32 == 2)
                    {
                        arraycreate[31] = 0;
                        button32.BackColor = Color.Gray;
                        b32 = 0;
                    }
                }
            }
        }
        private void button33_Click(object sender, EventArgs e)
        {
            if (b33 == 0)
            {
                arraycreate[32] = 1;
                button33.BackColor = Color.Black;
                b33 = 1;
            }
            else
            {
                if (b33 == 1)
                {
                    arraycreate[32] = 2;
                    button33.BackColor = Color.White;
                    b33 = 2;
                }
                else
                {
                    if (b33 == 2)
                    {
                        arraycreate[32] = 0;
                        button33.BackColor = Color.Gray;
                        b33 = 0;
                    }
                }
            }
        }
        private void button34_Click(object sender, EventArgs e)
        {
            if (b34 == 0)
            {
                arraycreate[33] = 1;
                button34.BackColor = Color.Black;
                b34 = 1;
            }
            else
            {
                if (b34 == 1)
                {
                    arraycreate[33] = 2;
                    button34.BackColor = Color.White;
                    b34 = 2;
                }
                else
                {
                    if (b34 == 2)
                    {
                        arraycreate[33] = 0;
                        button34.BackColor = Color.Gray;
                        b34 = 0;
                    }
                }
            }
        }
        private void button35_Click(object sender, EventArgs e)
        {
            if (b35 == 0)
            {
                arraycreate[34] = 1;
                button35.BackColor = Color.Black;
                b35 = 1;
            }
            else
            {
                if (b35 == 1)
                {
                    arraycreate[34] = 2;
                    button35.BackColor = Color.White;
                    b35 = 2;
                }
                else
                {
                    if (b35 == 2)
                    {
                        arraycreate[34] = 0;
                        button35.BackColor = Color.Gray;
                        b35 = 0;
                    }
                }
            }
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (b36 == 0)
            {
                arraycreate[35] = 1;
                button36.BackColor = Color.Black;
                b36 = 1;
            }
            else
            {
                if (b36 == 1)
                {
                    arraycreate[35] = 2;
                    button36.BackColor = Color.White;
                    b36 = 2;
                }
                else
                {
                    if (b36 == 2)
                    {
                        arraycreate[35] = 0;
                        button36.BackColor = Color.Gray;
                        b36 = 0;
                    }
                }
            }
        }
        private void button37_Click(object sender, EventArgs e)
        {
            if (b37 == 0)
            {
                arraycreate[36] = 1;
                button37.BackColor = Color.Black;
                b37 = 1;
            }
            else
            {
                if (b37 == 1)
                {
                    arraycreate[36] = 2;
                    button37.BackColor = Color.White;
                    b37 = 2;
                }
                else
                {
                    if (b37 == 2)
                    {
                        arraycreate[36] = 0;
                        button37.BackColor = Color.Gray;
                        b37 = 0;
                    }
                }
            }
        }
        private void button38_Click(object sender, EventArgs e)
        {
            if (b38 == 0)
            {
                arraycreate[37] = 1;
                button38.BackColor = Color.Black;
                b38 = 1;
            }
            else
            {
                if (b38 == 1)
                {
                    arraycreate[37] = 2;
                    button38.BackColor = Color.White;
                    b38 = 2;
                }
                else
                {
                    if (b38 == 2)
                    {
                        arraycreate[37] = 0;
                        button38.BackColor = Color.Gray;
                        b38 = 0;
                    }
                }
            }
        }
        private void button39_Click(object sender, EventArgs e)
        {
            if (b39 == 0)
            {
                arraycreate[38] = 1;
                button39.BackColor = Color.Black;
                b39 = 1;
            }
            else
            {
                if (b39 == 1)
                {
                    arraycreate[38] = 2;
                    button39.BackColor = Color.White;
                    b39 = 2;
                }
                else
                {
                    if (b39 == 2)
                    {
                        arraycreate[38] = 0;
                        button39.BackColor = Color.Gray;
                        b39 = 0;
                    }
                }
            }
        }
        private void button40_Click(object sender, EventArgs e)
        {
            if (b40 == 0)
            {
                arraycreate[39] = 1;
                button40.BackColor = Color.Black;
                b40 = 1;
            }
            else
            {
                if (b40 == 1)
                {
                    arraycreate[39] = 2;
                    button40.BackColor = Color.White;
                    b40 = 2;
                }
                else
                {
                    if (b40 == 2)
                    {
                        arraycreate[39] = 0;
                        button40.BackColor = Color.Gray;
                        b40 = 0;
                    }
                }
            }
        }
        private void button41_Click(object sender, EventArgs e)
        {
            if (b41 == 0)
            {
                arraycreate[40] = 1;
                button41.BackColor = Color.Black;
                b41 = 1;
            }
            else
            {
                if (b41 == 1)
                {
                    arraycreate[40] = 2;
                    button41.BackColor = Color.White;
                    b41 = 2;
                }
                else
                {
                    if (b41 == 2)
                    {
                        arraycreate[40] = 0;
                        button41.BackColor = Color.Gray;
                        b41 = 0;
                    }
                }
            }
        }
        private void button42_Click(object sender, EventArgs e)
        {
            if (b42 == 0)
            {
                arraycreate[41] = 1;
                button42.BackColor = Color.Black;
                b42 = 1;
            }
            else
            {
                if (b42 == 1)
                {
                    arraycreate[41] = 2;
                    button42.BackColor = Color.White;
                    b42 = 2;
                }
                else
                {
                    if (b42 == 2)
                    {
                        arraycreate[41] = 0;
                        button42.BackColor = Color.Gray;
                        b42 = 0;
                    }
                }
            }
        }
        private void button43_Click(object sender, EventArgs e)
        {
            if (b43 == 0)
            {
                arraycreate[42] = 1;
                button43.BackColor = Color.Black;
                b43 = 1;
            }
            else
            {
                if (b43 == 1)
                {
                    arraycreate[42] = 2;
                    button43.BackColor = Color.White;
                    b43 = 2;
                }
                else
                {
                    if (b43 == 2)
                    {
                        arraycreate[42] = 0;
                        button43.BackColor = Color.Gray;
                        b43 = 0;
                    }
                }
            }
        }
        private void button44_Click(object sender, EventArgs e)
        {
            if (b44 == 0)
            {
                arraycreate[43] = 1;
                button44.BackColor = Color.Black;
                b44 = 1;
            }
            else
            {
                if (b44 == 1)
                {
                    arraycreate[43] = 2;
                    button44.BackColor = Color.White;
                    b44 = 2;
                }
                else
                {
                    if (b44 == 2)
                    {
                        arraycreate[43] = 0;
                        button44.BackColor = Color.Gray;
                        b44 = 0;
                    }
                }
            }
        }
        private void button45_Click(object sender, EventArgs e)
        {
            if (b45 == 0)
            {
                arraycreate[44] = 1;
                button45.BackColor = Color.Black;
                b45 = 1;
            }
            else
            {
                if (b45 == 1)
                {
                    arraycreate[44] = 2;
                    button45.BackColor = Color.White;
                    b45 = 2;
                }
                else
                {
                    if (b45 == 2)
                    {
                        arraycreate[44] = 0;
                        button45.BackColor = Color.Gray;
                        b45 = 0;
                    }
                }
            }
        }
        private void button46_Click(object sender, EventArgs e)
        {
            if (b46 == 0)
            {
                arraycreate[45] = 1;
                button46.BackColor = Color.Black;
                b46 = 1;
            }
            else
            {
                if (b46 == 1)
                {
                    arraycreate[45] = 2;
                    button46.BackColor = Color.White;
                    b46 = 2;
                }
                else
                {
                    if (b46 == 2)
                    {
                        arraycreate[45] = 0;
                        button46.BackColor = Color.Gray;
                        b46 = 0;
                    }
                }
            }
        }
        private void button47_Click(object sender, EventArgs e)
        {
            if (b47 == 0)
            {
                arraycreate[46] = 1;
                button47.BackColor = Color.Black;
                b47 = 1;
            }
            else
            {
                if (b47 == 1)
                {
                    arraycreate[46] = 2;
                    button47.BackColor = Color.White;
                    b47 = 2;
                }
                else
                {
                    if (b47 == 2)
                    {
                        arraycreate[46] = 0;
                        button47.BackColor = Color.Gray;
                        b47 = 0;
                    }
                }
            }
        }
        private void button48_Click(object sender, EventArgs e)
        {
            if (b48 == 0)
            {
                arraycreate[47] = 1;
                button48.BackColor = Color.Black;
                b48 = 1;
            }
            else
            {
                if (b48 == 1)
                {
                    arraycreate[47] = 2;
                    button48.BackColor = Color.White;
                    b48 = 2;
                }
                else
                {
                    if (b48 == 2)
                    {
                        arraycreate[47] = 0;
                        button48.BackColor = Color.Gray;
                        b48 = 0;
                    }
                }
            }
        }
        private void button49_Click(object sender, EventArgs e)
        {
            if (b49 == 0)
            {
                arraycreate[48] = 1;
                button49.BackColor = Color.Black;
                b49 = 1;
            }
            else
            {
                if (b49 == 1)
                {
                    arraycreate[48] = 2;
                    button49.BackColor = Color.White;
                    b49 = 2;
                }
                else
                {
                    if (b49 == 2)
                    {
                        arraycreate[48] = 0;
                        button49.BackColor = Color.Gray;
                        b49 = 0;
                    }
                }
            }
        }
        private void button50_Click(object sender, EventArgs e)
        {
            if (b50 == 0)
            {
                arraycreate[49] = 1;
                button50.BackColor = Color.Black;
                b50 = 1;
            }
            else
            {
                if (b50 == 1)
                {
                    arraycreate[49] = 2;
                    button50.BackColor = Color.White;
                    b50 = 2;
                }
                else
                {
                    if (b50 == 2)
                    {
                        arraycreate[49] = 0;
                        button50.BackColor = Color.Gray;
                        b50 = 0;
                    }
                }
            }
        }
        private void button51_Click(object sender, EventArgs e)
        {
            if (b51 == 0)
            {
                arraycreate[50] = 1;
                button51.BackColor = Color.Black;
                b51 = 1;
            }
            else
            {
                if (b51 == 1)
                {
                    arraycreate[50] = 2;
                    button51.BackColor = Color.White;
                    b51 = 2;
                }
                else
                {
                    if (b51 == 2)
                    {
                        arraycreate[50] = 0;
                        button51.BackColor = Color.Gray;
                        b51 = 0;
                    }
                }
            }
        }
        private void button52_Click(object sender, EventArgs e)
        {
            if (b52 == 0)
            {
                arraycreate[51] = 1;
                button52.BackColor = Color.Black;
                b52 = 1;
            }
            else
            {
                if (b52 == 1)
                {
                    arraycreate[51] = 2;
                    button52.BackColor = Color.White;
                    b52 = 2;
                }
                else
                {
                    if (b52 == 2)
                    {
                        arraycreate[51] = 0;
                        button52.BackColor = Color.Gray;
                        b52 = 0;
                    }
                }
            }
        }
        private void button53_Click(object sender, EventArgs e)
        {
            if (b53 == 0)
            {
                arraycreate[52] = 1;
                button53.BackColor = Color.Black;
                b53 = 1;
            }
            else
            {
                if (b53 == 1)
                {
                    arraycreate[52] = 2;
                    button53.BackColor = Color.White;
                    b53 = 2;
                }
                else
                {
                    if (b53 == 2)
                    {
                        arraycreate[52] = 0;
                        button53.BackColor = Color.Gray;
                        b53 = 0;
                    }
                }
            }
        }
        private void button54_Click(object sender, EventArgs e)
        {
            if (b54 == 0)
            {
                arraycreate[53] = 1;
                button54.BackColor = Color.Black;
                b54 = 1;
            }
            else
            {
                if (b54 == 1)
                {
                    arraycreate[53] = 2;
                    button54.BackColor = Color.White;
                    b54 = 2;
                }
                else
                {
                    if (b54 == 2)
                    {
                        arraycreate[53] = 0;
                        button54.BackColor = Color.Gray;
                        b54 = 0;
                    }
                }
            }
        }
        private void button55_Click(object sender, EventArgs e)
        {
            if (b55 == 0)
            {
                arraycreate[54] = 1;
                button55.BackColor = Color.Black;
                b55 = 1;
            }
            else
            {
                if (b55 == 1)
                {
                    arraycreate[54] = 2;
                    button55.BackColor = Color.White;
                    b55 = 2;
                }
                else
                {
                    if (b55 == 2)
                    {
                        arraycreate[54] = 0;
                        button55.BackColor = Color.Gray;
                        b55 = 0;
                    }
                }
            }
        }
        private void button56_Click(object sender, EventArgs e)
        {
            if (b56 == 0)
            {
                arraycreate[55] = 1;
                button56.BackColor = Color.Black;
                b56 = 1;
            }
            else
            {
                if (b56 == 1)
                {
                    arraycreate[55] = 2;
                    button56.BackColor = Color.White;
                    b56 = 2;
                }
                else
                {
                    if (b56 == 2)
                    {
                        arraycreate[55] = 0;
                        button56.BackColor = Color.Gray;
                        b56 = 0;
                    }
                }
            }
        }
        private void button57_Click(object sender, EventArgs e)
        {
            if (b57 == 0)
            {
                arraycreate[56] = 1;
                button57.BackColor = Color.Black;
                b57 = 1;
            }
            else
            {
                if (b57 == 1)
                {
                    arraycreate[56] = 2;
                    button57.BackColor = Color.White;
                    b57 = 2;
                }
                else
                {
                    if (b57 == 2)
                    {
                        arraycreate[56] = 0;
                        button57.BackColor = Color.Gray;
                        b57 = 0;
                    }
                }
            }
        }
        private void button58_Click(object sender, EventArgs e)
        {
            if (b58 == 0)
            {
                arraycreate[57] = 1;
                button58.BackColor = Color.Black;
                b58 = 1;
            }
            else
            {
                if (b58 == 1)
                {
                    arraycreate[57] = 2;
                    button58.BackColor = Color.White;
                    b58 = 2;
                }
                else
                {
                    if (b58 == 2)
                    {
                        arraycreate[57] = 0;
                        button58.BackColor = Color.Gray;
                        b58 = 0;
                    }
                }
            }
        }
        private void button59_Click(object sender, EventArgs e)
        {
            if (b59 == 0)
            {
                arraycreate[58] = 1;
                button59.BackColor = Color.Black;
                b59 = 1;
            }
            else
            {
                if (b59 == 1)
                {
                    arraycreate[58] = 2;
                    button59.BackColor = Color.White;
                    b59 = 2;
                }
                else
                {
                    if (b59 == 2)
                    {
                        arraycreate[58] = 0;
                        button59.BackColor = Color.Gray;
                        b59 = 0;
                    }
                }
            }
        }
        private void button60_Click(object sender, EventArgs e)
        {
            if (b60 == 0)
            {
                arraycreate[59] = 1;
                button60.BackColor = Color.Black;
                b60 = 1;
            }
            else
            {
                if (b60 == 1)
                {
                    arraycreate[59] = 2;
                    button60.BackColor = Color.White;
                    b60 = 2;
                }
                else
                {
                    if (b60 == 2)
                    {
                        arraycreate[59] = 0;
                        button60.BackColor = Color.Gray;
                        b60 = 0;
                    }
                }
            }
        }
        private void button61_Click(object sender, EventArgs e)
        {
            if (b61 == 0)
            {
                arraycreate[60] = 1;
                button61.BackColor = Color.Black;
                b61 = 1;
            }
            else
            {
                if (b61 == 1)
                {
                    arraycreate[60] = 2;
                    button61.BackColor = Color.White;
                    b61 = 2;
                }
                else
                {
                    if (b61 == 2)
                    {
                        arraycreate[60] = 0;
                        button61.BackColor = Color.Gray;
                        b61 = 0;
                    }
                }
            }
        }
        private void button62_Click(object sender, EventArgs e)
        {
            if (b62 == 0)
            {
                arraycreate[61] = 1;
                button62.BackColor = Color.Black;
                b62 = 1;
            }
            else
            {
                if (b62 == 1)
                {
                    arraycreate[61] = 2;
                    button62.BackColor = Color.White;
                    b62 = 2;
                }
                else
                {
                    if (b62 == 2)
                    {
                        arraycreate[61] = 0;
                        button62.BackColor = Color.Gray;
                        b62 = 0;
                    }
                }
            }
        }
        private void button63_Click(object sender, EventArgs e)
        {
            if (b63 == 0)
            {
                arraycreate[62] = 1;
                button63.BackColor = Color.Black;
                b63 = 1;
            }
            else
            {
                if (b63 == 1)
                {
                    arraycreate[62] = 2;
                    button63.BackColor = Color.White;
                    b63 = 2;
                }
                else
                {
                    if (b63 == 2)
                    {
                        arraycreate[62] = 0;
                        button63.BackColor = Color.Gray;
                        b63 = 0;
                    }
                }
            }
        }
        private void button64_Click(object sender, EventArgs e)
        {
            if (b64 == 0)
            {
                arraycreate[63] = 1;
                button64.BackColor = Color.Black;
                b64 = 1;
            }
            else
            {
                if (b64 == 1)
                {
                    arraycreate[63] = 2;
                    button64.BackColor = Color.White;
                    b64 = 2;
                }
                else
                {
                    if (b64 == 2)
                    {
                        arraycreate[63] = 0;
                        button64.BackColor = Color.Gray;
                        b64 = 0;
                    }
                }
            }
        }
    }
}