using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace PC_Crasher
{
    public partial class Form1 : Form
    {

        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        // This is the Init componet of the script, this is called when the form appears
        public Form1()
        {
            InitializeComponent();
            timer2.Start();

            if (progressBar5.Value < progressBar5.Maximum)
            {
                prepbsodmsg();
            }

        }
        // IF you want a constantly updating system, you need to use a timer, and every time it ticks it will check the conditions: 

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
            {
                timer1.Start();
                label1.Visible = true;
                button1.Visible = true;
                label4.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                button2.Visible = false;
            }
        }

        async void prepbsodmsg()
        {
            label1.Text = "Preparing to crash your PC";
            await Task.Delay(1000);
            label1.Text = "Preparing to crash your PC.";
            await Task.Delay(1000);
            label1.Text = "Preparing to crash your PC..";
            await Task.Delay(1000);
            label1.Text = "Preparing to crash your PC...";
            await Task.Delay(1000);
            prepbsodmsg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 box1 = new AboutBox1();
            box1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 10;
            }
            else
            {
                ModifyProgressBarColor.SetState(progressBar1, 1);

                timer1.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {


            if (progressBar2.Value < progressBar2.Maximum)
            {
                progressBar2.Value += 10;
            }
            else
            {
                ModifyProgressBarColor.SetState(progressBar2, 1);

                timer3.Stop();
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (progressBar3.Value < progressBar3.Maximum)
            {
                progressBar3.Value += 10;
            }
            else
            {
                ModifyProgressBarColor.SetState(progressBar3, 3);

                timer4.Stop();
                timer5.Start();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (progressBar4.Value < progressBar4.Maximum)
            {
                progressBar4.Value += 10;
            }
            else
            {
                ModifyProgressBarColor.SetState(progressBar4, 3);

                timer5.Stop();
                timer6.Start();
            }
        }

        private async void timer6_Tick(object sender, EventArgs e)
        {
            if (progressBar5.Value < progressBar5.Maximum)
            {
                progressBar5.Value += 10;
            }
            else
            {
                ModifyProgressBarColor.SetState(progressBar5, 2);

                timer6.Stop();
                label6.Visible = true;
                label1.Dispose();
            }

            if (progressBar5.Value == progressBar5.Maximum)
            {
                RIPmsg();

                await Task.Delay(1000);

                ModifyProgressBarColor.SetState(progressBar1, 2);
                ModifyProgressBarColor.SetState(progressBar2, 2);
                ModifyProgressBarColor.SetState(progressBar3, 2);
                ModifyProgressBarColor.SetState(progressBar4, 2);
                ModifyProgressBarColor.SetState(progressBar5, 2);

                await Task.Delay(5000);

                Boolean t1;
                uint t2;
                RtlAdjustPrivilege(19, true, false, out t1);
                NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
            }

            async void RIPmsg()
            {
                label6.Text = "Invoking BSOD";
                await Task.Delay(1000);
                label6.Text = "Invoking BSOD.";
                await Task.Delay(1000);
                label6.Text = "Invoking BSOD..";
                await Task.Delay(1000);
                label6.Text = "Invoking BSOD...";
                await Task.Delay(1000);
            }
        }

    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}