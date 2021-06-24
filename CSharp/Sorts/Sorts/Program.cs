using System;

namespace Sorts
{
    public class Person
    {
        public String _sName;
        public DateTime _dtLastPlayed;
        public int _nRank;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //RandomDataGenerator rdg = new RandomDataGenerator(999);
            //Person[] arrPerson = new Person[12];
            //int j;
            //for (j = 0; j < arrPerson.Length; j++)
            //{

            //    String s = rdg.getRandomPersonName();
            //    DateTime dt = DateTime.Today.AddDays(-rdg._random.Next(90));
            //    int nRank = rdg._random.Next(100);
            //    Person person = new Person
            //    {
            //        _dtLastPlayed = dt,
            //        _nRank = nRank,
            //        _sName = s
            //    };
            //    arrPerson[j] = person;
            String[] arrStr =
            {
                "WINDIES",
                "ZIM",
                "RSA",
                "AUS" ,
                "INDIA",
                "SRILANKA",
            };
            int[] arrIndex = doIndexByBubbleSort(arrStr, true);
            for (int j = 0; j < arrIndex.Length; j++)
            {
                Console.WriteLine(arrStr[arrIndex[j]]);
            }
        }
        public static int [] doIndexByBubbleSort(String[] arrStr, bool fAscending)
        {
            int[] arrIndex = new int[arrStr.Length];
            for (int i = 0; i < arrIndex.Length; i++)
            {
                arrIndex[i] = i;
            }

            bool fSwapped = false;
            int nPass = 1;
            do
            {
                fSwapped = false;
                for (int j = 0; j < arrStr.Length - nPass; j++)
                {

                    if (fAscending == (String.Compare(arrStr[arrIndex[j]], arrStr[arrIndex[j + 1]]) > 0))
                    {
                        int jTemp = arrIndex[j];
                        arrIndex[j] = arrIndex[j + 1];
                        arrIndex[j + 1] = jTemp;
                        fSwapped = true;
                    }
                }
                nPass++;
            } while (fSwapped);

            return arrIndex;
        }

        public static void doBubbleSort(String[] arrStr, bool fAscending)
        {
            bool fSwapped = false;
            int nPass = 1;
            do
            {
                fSwapped = false;
                for (int j = 0; j < arrStr.Length - nPass; j++)
                {

                    if (fAscending == (String.Compare(arrStr[j], arrStr[j + 1]) > 0))
                    {
                        String sTemp = arrStr[j];
                        arrStr[j] = arrStr[j + 1];
                        arrStr[j + 1] = sTemp;
                        fSwapped = true;
                    }
                }
                nPass++;
            } while (fSwapped);
        }

        private static void DoInsertionSort(int[] arrVal, Boolean fAscending)
        {
            // Start with the 0th element
            int nMoves = 0;
            int jCurEle = 0;
            int jCurVal = 0;
            for (jCurEle = 0; jCurEle < arrVal.Length; jCurEle++)
            {
                jCurVal = arrVal[jCurEle];
                // look in arrVal Upto jCurEle
                int j;
                for (j = 0; j < jCurEle; j++)
                {
                    if (jCurVal < arrVal[j] == fAscending)
                    {
                        // Move all elements after j to jCurEle and insert jCurVal
                        int jInner;
                        for (jInner = jCurEle; jInner > j; jInner--)
                        {
                            arrVal[jInner] = arrVal[jInner - 1];
                            nMoves++;
                        }
                        arrVal[jInner] = jCurVal;
                        break;
                    }
                }
            }
            Console.WriteLine("Done with {0} moves", nMoves);
        }
    }
}
