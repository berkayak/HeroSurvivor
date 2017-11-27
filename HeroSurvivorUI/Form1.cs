using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace HeroSurvivor
{
    public partial class Form1 : Form
    {
        private string readFile { get; set; }
        private string writeFile { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            ofdReader.Filter = "Text Files (*.txt) | *.txt;";
            ofdReader.ShowDialog();
        }

        private void ofdReader_FileOk(object sender, CancelEventArgs e)
        {
            if (ofdReader.CheckFileExists)
            {
                string DosyaYolu = ofdReader.FileName;
                readFilePath.Text = DosyaYolu;
            }
        }

        private void btnWriter_Click(object sender, EventArgs e)
        {
            ofdWriter.Filter = "Text Files (*.txt) | *.txt;";
            ofdWriter.ShowDialog();
        }

        private void ofdWriter_FileOk(object sender, CancelEventArgs e)
        {
            if (ofdWriter.CheckFileExists)
            {
                string DosyaYolu = ofdWriter.FileName;
                writeFilePath.Text = DosyaYolu;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ofdWriter.FileName) || string.IsNullOrEmpty(ofdReader.FileName))
            {
                MessageBox.Show("Please select the input and output files", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Game game = new Game();
            Inputs inputs = new Inputs(ofdReader.FileName);
            Outputs outputs = new Outputs(ofdWriter.FileName);
            game.inputLines = inputs.readFile();
            bool isOK = game.StartGame();
            outputs.writeToFile(game.outputLines);
            if(isOK)
                MessageBox.Show("Game Played! See the output file. \n" + ofdWriter.FileName, "Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Game could not Play! See the output file. \n" + ofdWriter.FileName, "Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
