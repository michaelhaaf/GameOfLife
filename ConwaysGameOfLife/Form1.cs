// andrewjivoin
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        #region Vars

        private ColorTheme DEFAULT = new ColorTheme(Color.Cyan, Color.FromArgb(34, 34, 34));
        private ColorTheme DARK = new ColorTheme(Color.FromArgb(186, 186, 186), Color.FromArgb(10, 10, 10));
        private ColorTheme LIGHT = new ColorTheme(Color.Cyan, Color.White);
        private ColorTheme TERMINAL = new ColorTheme(Color.FromArgb(0, 225, 0), Color.Black);
        private ColorTheme colorTheme;

        private Game game;
        private Brush CELL_COLOR = Brushes.Cyan;

        private const int ROWS = 100;
        private const int COLUMNS = 100;
        private const int CELL_WIDTH = 6;

        public int generationCounter = 0;
        private bool pauseStatus = false;
        private List<bool[,]> grids = new List<bool[,]>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Introduction introForm = new Introduction();
            introForm.ShowDialog();
            colorTheme = DEFAULT;
            pb.BackColor = colorTheme.GetBackground();
            
            game = new Game(new SolidBrush(colorTheme.GetForeground()), ROWS, COLUMNS, CELL_WIDTH);
            game.InitialGeneration();
            generationTimer.Start();
        }

        private void generationTimer_Tick(object sender, EventArgs e)
        {
            grids.Add((bool[,])game.GetGrid().Clone());
            game.NewGeneration();

            generationCounter++;
            lblGen.Text = generationCounter.ToString();
            Refresh();   
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Paint(e.Graphics);
        }

        private void restartButton_Click(object sender, EventArgs e)
        { 
            Restart();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void verySlow2xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 2;
        }

        private void slow4xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 4;
        }

        private void normal8xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 8;
        }

        private void fast12xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 12;
        }

        private void veryFast32xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 32;
        }

        private void superSpeed64xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generationTimer.Interval = 1000 / 64;
        }

        private void Restart()
        {
            game = new Game(new SolidBrush(colorTheme.GetForeground()), ROWS, COLUMNS, CELL_WIDTH);
            game.InitialGeneration();

            grids = new List<bool[,]>();
            generationCounter = 0;
            pauseButton.Text = "Pause";
            pauseStatus = false;
            generationTimer.Start();
            Refresh();
        }

        private void Pause()
        {
            pauseStatus = !pauseStatus;

            if (pauseStatus)
            {
                generationTimer.Stop();
                pauseButton.Text = "Play";
            }
            else
            {
                generationTimer.Start();
                pauseButton.Text = "Pause";
            }
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorTheme = DARK;
            ChangeTheme();
            Refresh();
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorTheme = LIGHT;
            ChangeTheme();
            Refresh();
        }

        private void ChangeTheme()
        {
            game.SetCellColor(colorTheme.GetForeground());
            pb.BackColor = colorTheme.GetBackground();
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorTheme = TERMINAL;
            ChangeTheme();
            Refresh();
        }
    }
}
