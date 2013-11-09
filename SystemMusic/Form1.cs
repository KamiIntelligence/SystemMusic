using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMusic
{
    public partial class Form1 : Form
    {
        private Mp3Player _mp3Player;

        public Form1()
        {
            InitializeComponent();
        }

        private void ImportStatusForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
            this.Show();
        }

        private void cleanRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Warning! Do not use clean RAM unless SystemMusic is lagging.", "Do you want to continue?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                MessageBox.Show("Cleam RAM has started the function.");
            else
                MessageBox.Show("Clean RAM was aborted.");
        }

        private void systemMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created and mantainted by Kami Mikusuki.", "About");
        }

        private void loadMusicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                dlgOpen.Filter = "Mp3 File|*mp3";
                dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _mp3Player = new Mp3Player(dlgOpen.FileName);
                    _mp3Player.Repeat = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
                _mp3Player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
                _mp3Player.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_mp3Player != null)
                _mp3Player.Stop();
        }
    }
}
