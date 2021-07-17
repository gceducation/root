using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        // for a board of 3x3 we need 18 bits.
        byte[] _abBoard = new byte[3];

        public static byte _bBitsEmpty = 0;
        public static byte _bBitsCross = 1;
        public static byte _bBitsNought = 2;



        // two bits for each cell per row
        public enum EGAMESTATE
        {
            eIncomplete,
            eDraw,
            eWinnerCross,
            eWinnerNought
        }
        public Game()
        {
            int nEmpty;
            GetGameState(out nEmpty);
        }
        public EGAMESTATE GetGameState(out int nEmpty)
        {
            EGAMESTATE estate = EGAMESTATE.eIncomplete;
            nEmpty = 0;
            int jx;
            int jy;
            byte bMark = _bBitsEmpty;
            for (jx = 0; jx < 3; jx++)
            {
                for (jy = 0; jy < 3; jy++)
                {
                    if (BGetMark(jx, jy) == _bBitsEmpty)
                    {
                        nEmpty++;
                    }
                }
            }

            // Check Rows
            for (jx = 0; jx < 3; jx++)
            {
                bMark = (byte)(Game._bBitsCross | Game._bBitsNought);
                for (jy = 0; jy < 3; jy++)
                {
                    bMark &= BGetMark(jx, jy);

                }
                if (bMark == Game._bBitsCross)
                {
                    estate = EGAMESTATE.eWinnerCross;
                    break;

                }
                else if (bMark == Game._bBitsNought)
                {
                    estate = EGAMESTATE.eWinnerNought;
                    break;
                }

            }
            if (estate == EGAMESTATE.eIncomplete)
            {
                // Check Columns
                if (estate == EGAMESTATE.eIncomplete)
                {
                    for (jy = 0; jy < 3; jy++)
                    {
                        bMark = (byte)(Game._bBitsCross | Game._bBitsNought);
                        for (jx = 0; jx < 3; jx++)
                        {
                            bMark &= BGetMark(jx, jy);

                        }
                        if (bMark == Game._bBitsCross)
                        {
                            estate = EGAMESTATE.eWinnerCross;
                            break;

                        }
                        else if (bMark == Game._bBitsNought)
                        {
                            estate = EGAMESTATE.eWinnerNought;
                            break;
                        }
                    }

                }
                // Check Diagonal 1
                if (estate == EGAMESTATE.eIncomplete)
                {
                    bMark = (byte)(Game._bBitsCross | Game._bBitsNought);
                    for (jx = 0; jx < 3; jx++)
                    {

                        bMark &= BGetMark(jx, jx);
                    }
                    if (bMark == Game._bBitsCross)
                    {
                        estate = EGAMESTATE.eWinnerCross;
                    }
                    else if (bMark == Game._bBitsNought)
                    {
                        estate = EGAMESTATE.eWinnerNought;
                    }
                }
                // Check Diagonal 2
                if (estate == EGAMESTATE.eIncomplete)
                {
                    bMark = (byte)(Game._bBitsCross | Game._bBitsNought);
                    for (jx = 0; jx < 3; jx++)
                    {

                        bMark &= BGetMark(jx, 2 - jx);
                    }
                    if (bMark == Game._bBitsCross)
                    {
                        estate = EGAMESTATE.eWinnerCross;
                    }
                    else if (bMark == Game._bBitsNought)
                    {
                        estate = EGAMESTATE.eWinnerNought;
                    }
                }
            }
            if ((estate == EGAMESTATE.eIncomplete) && (nEmpty == 0))
            {
                estate = EGAMESTATE.eDraw;
            }
            return estate;
        }


        public byte BGetMark(int jx, int jy)
        {
            byte bRet = _bBitsEmpty;
            // Create a mask
            byte bMask = (byte)(0x3 << (jx * 2));
            bRet = (byte)(_abBoard[jy] & bMask);
            bRet >>= (jx * 2);
            return bRet;
        }
        public void SetMark(int jx, int jy, byte bMark)
        {
            byte bVal;
            // Create a mask
            byte bMask = (byte)(0x3 << (jx * 2));
            bVal = _abBoard[jy];
            // Zero Out the bits
            bVal &= (byte)(~(bMask));
            bMask = (byte)(bMark << (jx * 2));
            bVal |= bMask;
            _abBoard[jy] = bVal;
        }

        public int ComputeNextMove(out XY xy)
        {

            return ComputeNextMoveInternal(null, out xy, _bBitsNought);
        }
        private const int _jGameWinValue = 333;
        private int ComputeNextMoveInternal(XY xyCur, out XY xy, byte bPlayer)
        {
            int jVal = 0;
            xy = xyCur;
            int nEmpty;
            EGAMESTATE egs = GetGameState(out nEmpty);
            switch (egs)
            {
                case EGAMESTATE.eIncomplete:
                    bool fFirstTime = true;
                    XY xyBest = null;
                    for (int jx = 0; jx < 3; jx++)
                    {
                        for (int jy = 0; jy < 3; jy++)
                        {
                            if (BGetMark(jx, jy) == _bBitsEmpty)
                            {
                                SetMark(jx, jy, bPlayer);
                                byte bPlayerNextMove = (byte)((Game._bBitsCross | Game._bBitsNought) ^ bPlayer);
                                XY xyTemp = new XY() { _jx = jx, _jy = jy };
                                int jValT = -ComputeNextMoveInternal(xyTemp, out xy, bPlayerNextMove);
                                if (fFirstTime || (jValT > jVal))
                                {
                                    jVal = jValT;
                                    xyBest = xyTemp;
                                    fFirstTime = false;
                                }
                                SetMark(jx, jy, _bBitsEmpty);
                            }
                        }
                    }
                    xy = xyBest;
                    break;
                case EGAMESTATE.eDraw:
                    break;
                case EGAMESTATE.eWinnerCross:
                    jVal = bPlayer == _bBitsCross ? _jGameWinValue : -_jGameWinValue;
                    break;
                case EGAMESTATE.eWinnerNought:
                    jVal = bPlayer == _bBitsNought ? _jGameWinValue : -_jGameWinValue;
                    break;
                default:
                    throw new Exception("unexpected EGAMESTATE");
            }



            return jVal;
        }
        public class XY
        {
            public int _jx;
            public int _jy;
        }
    }

}
