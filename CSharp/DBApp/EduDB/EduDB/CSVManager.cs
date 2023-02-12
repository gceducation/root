using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EduDB
{
    public class CSVData
    {
        public List<List<String>> _llData;
        public int _jColumnMin = int.MaxValue;
        public int _jColumnMax = int.MinValue;
        public int _jCountEmptyLines = 0;
    }
    public class CSVManager
    {
        private const char __chINVALID = (char)0xFFFF;
        private const char __chDQ = '"';
        private const String __sDQ = "\"";
        private const String __sDQDQ = "\"\"";
        private const char __chCOMMA = ',';
        private const char __chLF = '\n';
        private const char __chCR = '\r';
        public String getCSVString(List<String> lstStr)
        {
            StringBuilder sb = new StringBuilder();
            int j;
            for (j = 0; j < lstStr.Count; j++)
            {
                if (j > 0)
                {
                    sb.Append(__chCOMMA);
                }
                String sTemp = lstStr[j];
                if (sTemp.Contains(__chDQ))
                {
                    sTemp = sTemp.Replace(__sDQ, __sDQDQ);
                }
                if (sTemp.Contains(__chCOMMA))
                {
                    sTemp = __sDQ + sTemp + sTemp;
                }
                sb.Append(sTemp);
            }
            return sb.ToString();
        }
        public CSVData Parse(String sData, bool fTrimWhitespace)
        {
            CSVData csvData = new CSVData();

            List<List<String>> llData = null;
            StringBuilder sb = new StringBuilder();
            if ((sData != null) && (sData.Length > 0))
            {
                llData = new List<List<String>>();
                int jchCur = 0;
                bool fDone = false;
                List<String> lsCurLine = new List<string>();
                while (!fDone)
                {


                    char chCur = sData.getCharAt(jchCur);
                    if (chCur == __chDQ)
                    {
                        int jchConsumed = GetQuotedString(sData, jchCur, sb);
                        jchCur += jchConsumed - 1;
                    }
                    else if (chCur == __chCOMMA)
                    {
                        String sTemp = sb.ToString();
                        if (fTrimWhitespace)
                        {
                            sTemp = sTemp.Trim();
                        }
                        lsCurLine.Add(sTemp);
                        sb.Clear();
                    }
                    else if (chCur == __chLF)
                    {
                        if (sb.Length > 0)
                        {
                            String sTemp = sb.ToString();
                            if (fTrimWhitespace)
                            {
                                sTemp = sTemp.Trim();
                            }
                            lsCurLine.Add(sTemp);
                            sb.Clear();
                            csvData._jColumnMin = Math.Min(csvData._jColumnMin, lsCurLine.Count);
                            csvData._jColumnMax = Math.Max(csvData._jColumnMin, lsCurLine.Count);
                        }
                        else
                        {
                            csvData._jCountEmptyLines++;
                        }

                        llData.Add(lsCurLine);
                        lsCurLine = new List<string>();
                    }
                    else
                    {
                        // Eat up CRs
                        if (chCur != __chCR)
                        {
                            sb.Append(chCur);
                        }
                    }

                    jchCur++;
                    if (jchCur == sData.Length)
                    {
                        fDone = true;
                    }
                }


            }
            csvData._llData = llData;
            return csvData;
        }

        private int GetQuotedString(string sData, int jchCur, StringBuilder sb)
        {
            int jchConsumed = 0;
            int jchCurOriginal = jchCur;
            bool fDone = false;
            char chCur = sData.getCharAt(jchCur);
            if (chCur != __chDQ)
            {
                throw new Exception("chCur != __chDQ");
            }

            do
            {
                chCur = getNextChar(sData, jchCur);
                jchCur++;
                if (chCur == __chDQ)
                {
                    char chNext = getNextChar(sData, jchCur);
                    if (chNext == __chDQ)
                    {
                        jchCur++;
                        sb.Append(__chDQ);
                    }
                    else
                    {
                        // End of String
                        jchConsumed = jchCur - jchCurOriginal + 1;
                        fDone = true;
                    }
                }
                else if (chCur == __chINVALID)
                {
                    jchConsumed = jchCur - jchCurOriginal;
                    fDone = true;
                }
                else
                {
                    sb.Append(chCur);
                }
            } while (!fDone);
            return jchConsumed;
        }

        private char getNextChar(String s, int jchCur)
        {
            char ch;
            jchCur++;
            if (jchCur < s.Length)
            {
                ch = s[jchCur];
            }
            else
            {
                ch = __chINVALID;
            }
            return ch;
        }
    }
}
