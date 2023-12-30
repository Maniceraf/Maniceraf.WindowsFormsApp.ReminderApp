using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string currentTime = string.Empty;
        string messageTime = string.Empty;

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = DateTime.Now.ToString("hh:mm:ss tt");
            labelCurrentTime.Text = currentTime;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            messageTime = maskedTextBox.Text + " " + comboBox.Text;
            labelResult.Text = "Set reminders at: " + messageTime;
            if(currentTime == messageTime)
            {
                timer2.Stop();
                MessageBox.Show("The \"Reminder Application\" app wants to remind you that it's time: " + reminder.Text, "Reminder Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                startButton.Enabled = true;
                stopButton.Enabled = false;
                labelResult.Text = "None";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string note = reminder.Text;
            if (!string.IsNullOrEmpty(note))
            {
                timer2.Start();
                startButton.Enabled = false;
                stopButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            startButton.Enabled = true;
            stopButton.Enabled = false;
            labelResult.Text = "None";
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipText = "Reminder Application";
            notifyIcon.BalloonTipTitle = "Welcome back !!!";
            notifyIcon.Icon = SystemIcons.Application;
            this.Hide();
            notifyIcon.ShowBalloonTip(5000);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            maskedTextBox.Text = "00:00:00";
            comboBox.SelectedIndex = 0;
            labelResult.Text = "None";
            startButton.Enabled = true;
            stopButton.Enabled = false;
            reminder.Text = "";
        }
    }
}
