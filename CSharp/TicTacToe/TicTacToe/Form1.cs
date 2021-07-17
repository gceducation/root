using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        int _jNumOfCells = 3;
        int _jCellSize = 100;
        byte _bCurMove = Game._bBitsCross;
        Game _game = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Pen pen = Pens.Black;
            Graphics g = e.Graphics;
            for (int j = 0; j < _jNumOfCells + 1; j++)
            {
                int jX1 = j * _jCellSize;
                int jY1 = 0;
                int jX2 = jX1;
                int jY2 = _jNumOfCells * _jCellSize;
                g.DrawLine(pen, jX1, jY1, jX2, jY2);
                jX1 = 0;
                jY1 = j * _jCellSize;
                jX2 = _jNumOfCells * _jCellSize;
                jY2 = jY1;
                g.DrawLine(pen, jX1, jY1, jX2, jY2);
            }

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouea = e as MouseEventArgs;
            Game.XY xy = FindCellFromXY(mouea.X, mouea.Y);
            if (_game.BGetMark(xy._jx, xy._jy) == Game._bBitsEmpty)
            {
                DrawInBox(xy._jx, xy._jy);
                int jVal = _game.ComputeNextMove(out xy);
                if (xy != null)
                {
                    DrawInBox(xy._jx, xy._jy);
                }
                int nEmpty;
                Game.EGAMESTATE ega = _game.GetGameState(out nEmpty);
                String sMsg = null;
                switch (ega)
                {
                    case Game.EGAMESTATE.eDraw:
                        sMsg = "It is a tie!\r\nPlay Again?";
                        break;
                    case Game.EGAMESTATE.eWinnerNought:
                        sMsg = "Computer wins!\r\nPlay Again?";
                        break;
                    case Game.EGAMESTATE.eWinnerCross:
                        throw new Exception("Computer cannot lose");
                }
                if (sMsg != null)
                {
                    DialogResult dlgres = MessageBox.Show(sMsg, "Game Over", MessageBoxButtons.YesNo);
                    if (dlgres == DialogResult.Yes)
                    {
                        _game = new Game();
                        _bCurMove = Game._bBitsCross;
                        this.Refresh();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("Already Filled");
            }
        }

        private void DrawInBox(int jx, int jy)
        {
            Graphics g = panel1.CreateGraphics();

            if (_bCurMove == Game._bBitsCross)
            {
                g.DrawLine(Pens.Blue, jx * _jCellSize + _jCellSize / 10, jy * _jCellSize + _jCellSize / 10, (jx + 1) * _jCellSize - _jCellSize / 10, (jy + 1) * _jCellSize - _jCellSize / 10);
                g.DrawLine(Pens.Blue, jx * _jCellSize + _jCellSize / 10, (jy + 1) * _jCellSize - _jCellSize / 10, (jx + 1) * _jCellSize - _jCellSize / 10, jy * _jCellSize + _jCellSize / 10);
            }
            else
            {
                g.DrawEllipse(Pens.Green, jx * _jCellSize + _jCellSize / 10, jy * _jCellSize + _jCellSize / 10,
                    _jCellSize - _jCellSize / 5, _jCellSize - _jCellSize / 5);
            }
            _game.SetMark(jx, jy, _bCurMove);
            int nEmpty;
            Game.EGAMESTATE egs = _game.GetGameState(out nEmpty);
            _bCurMove = (byte)((Game._bBitsCross | Game._bBitsNought) ^ _bCurMove);
            g.Dispose();

        }

        private Game.XY FindCellFromXY(int jx, int jy)
        {
            Game.XY xyRet = new Game.XY();
            xyRet._jx = jx / _jCellSize;
            xyRet._jy = jy / _jCellSize;
            return xyRet;
        }
    }
}
