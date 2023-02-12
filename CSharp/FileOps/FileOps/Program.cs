using System;
using System.IO;

namespace FileOps
{
    class Program
    {
        static void Main(string[] args)
        {
            String sFilenameIn = "C:\\scratch\\somedata.txt";
            String[] arrstrData = File.ReadAllLines(sFilenameIn);

            Console.WriteLine("reading");
            // 0 or n times
            int jLine;
            for (jLine = 0; jLine < arrstrData.Length; jLine++)
            {
                Console.WriteLine(arrstrData[jLine]);
            }

            String sFilenameOut = "C:\\scratch\\somedatarev.txt";
            Console.WriteLine("writing");
            for (jLine = 0; jLine < arrstrData.Length; jLine++)
            {
                String sTemp = ReverseString(arrstrData[jLine]);
                if (jLine == 0)
                {
                    File.WriteAllText(sFilenameOut, sTemp + "\r\n");
                }
                else
                {
                    File.AppendAllText(sFilenameOut, sTemp + "\r\n");
                }
            }
        }
        static String ReverseString(String sIn)
        {
            String sRet = null;
            char[] ach = new char[sIn.Length];
            int j;
            for (j = 0; j < ach.Length; j++)
            {
                ach[j] = sIn[sIn.Length - j - 1];
            }
            sRet = new string(ach);
            return sRet;
        }
    }
}
