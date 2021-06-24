using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sorts
{
    public class RandomDataGenerator
    {
        private static bool __fInitialized = false;
        private static String[] __arrsUSCities = null;
        private static String[] __arrsFirstNamesM = null;
        private static String[] __arrsFirstNamesF = null;
        private static String[] __arrsLastNames = null;
        public Random _random;

        public RandomDataGenerator(int jRandomNumberSeed)
        {
            if (!__fInitialized)
            {
                String sFilename_USCities = "c:/scratch/RandomSeedData/USCities.txt";
                String sFilename_FirstNamesM = "c:/scratch/RandomSeedData/FirstNamesM.txt";
                String sFilename_FirstNamesF = "c:/scratch/RandomSeedData/FirstNamesF.txt";
                String sFilename_LastNames = "c:/scratch/RandomSeedData/LastNames.txt";
                __arrsUSCities = initializeFromTxtFile(sFilename_USCities, true);
                __arrsFirstNamesM = initializeFromTxtFile(sFilename_FirstNamesM, false);
                __arrsFirstNamesF = initializeFromTxtFile(sFilename_FirstNamesF, false);
                __arrsLastNames = initializeFromTxtFile(sFilename_LastNames, false);
                __fInitialized = true;
            }
            _random = new Random(jRandomNumberSeed);
        }

        private String[] initializeFromTxtFile(String sFilename, bool fReplaceTabWithComma)
        {

            String[] arrsRet = null;

            String[] arrTemp = File.ReadAllLines(sFilename);
            // Convert TAB to comma
            arrsRet = new String[arrTemp.Length];
            for (int j = 0; j < arrTemp.Length; j++)
            {
                String s = arrTemp[j];
                s = s.Trim();
                if (fReplaceTabWithComma)
                {
                    s = s.Replace('\t', ',');
                }
                arrsRet[j] = s;
            }

            return arrsRet;
        }

        private String getRandomStringFromArray(String[] arr)
        {
            int j = _random.Next(arr.Length);
            return arr[j];
        }

        public String getRandomPersonName()
        {
            int jRLN = _random.Next(__arrsLastNames.Length);
            String sLN = getRandomStringFromArray(__arrsLastNames);
            String sFN = "";
            int jGender = _random.Next(2);
            String[] arrFN;
            if (jGender == 0)
            {
                arrFN = __arrsFirstNamesM;
            }
            else
            {
                arrFN = __arrsFirstNamesF;
            }
            sFN = getRandomStringFromArray(arrFN);
            String sMN1 = "";
            String sMN2 = " ";

            int jRFN = _random.Next(__arrsLastNames.Length);

            // 0,1 LN FN MN1
            // 2 LN FN MN1 MN2
            // 3 LN FN
            int jRandom = _random.Next(4);

            if (jRandom < 3)
            {
                sMN1 = getRandomStringFromArray(arrFN);
            }
            if (jRandom == 2)
            {
                sMN2 = getRandomStringFromArray(arrFN);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(sLN);
            sb.Append(", ");
            sb.Append(sFN);
            if (jRandom < 3)
            {
                sb.Append(" ");
                sb.Append(sMN1);
                if (jRandom == 2)
                {
                    sb.Append(" ");
                    sb.Append(sMN2);
                }
            }
            String sRet = sb.ToString();
            return sRet;

        }

    }
}
