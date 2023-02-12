using EduDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduDB
{
    public interface IComparisonMaker<T>
    {
        int compare(T t1, T t2);
    }
    public class CompareTCustomerByName : IComparisonMaker<TCustomer>
    {
        public int compare(TCustomer t1, TCustomer t2)
        {
            return String.Compare(t1._sName, t2._sName);
        }
    }
    public class CompareTCustomerByMobile : IComparisonMaker<TCustomer>
    {
        public int compare(TCustomer t1, TCustomer t2)
        {
            return String.Compare(t1._sContactNoM, t2._sContactNoM);
        }
    }
    class Sorter 
    {

        public static int[] doIndexByBubbleSort(TCustomer[] arrtCust, bool fAscending, IComparisonMaker<TCustomer> ctcbn)
        {
            int[] arrIndex = new int[arrtCust.Length];
            for (int i = 0; i < arrIndex.Length; i++)
            {
                arrIndex[i] = i;
            }

            bool fSwapped = false;
            int nPass = 1;
            do
            {
                fSwapped = false;
                for (int j = 0; j < arrtCust.Length - nPass; j++)
                {

                    if (fAscending == (ctcbn.compare(arrtCust[arrIndex[j]], arrtCust[arrIndex[j + 1]]) > 0))
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
    }
}