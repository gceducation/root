using EduDB.DBModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EduDB
{
    public class TSVManager
    {
        public EduDB.DBModel.TCustomer[] _arrtCust = null;
        public String _sHeaderCustomer = "ID\tName\tIdentifications\tCurrent Address Line 1\tCurrent Address Line 2\tCity\tProvince\tState\tPostCode\tCountry\tContact No M\tContact No L\tEmail\tExtra Info";

        public List<TCustomer> getCustomersByName(string sNameText)
        {
            List<TCustomer> lstRet = new List<TCustomer>();
            int j;
            for (j = 0; j < _arrtCust.Length; j++)
            {
                TCustomer tcustCur = _arrtCust[j];
                if (tcustCur._sName.Contains(sNameText, StringComparison.OrdinalIgnoreCase))
                {
                    lstRet.Add(tcustCur);
                }
            }
            return lstRet;
        }

        public int _jFieldCountCustomer = 14;
        public String _sHeaderBankAccount = "ACNO\tBalance\tDateTime\tBrachCode\tCheckbook\tDebitCard\tOperationMode\tRestrictions\tCustIDs";
        public String _sDBRoot;
        public String _sFilenameCustomer;
        public String _sFilenameBankAccount;

        public void Initialize()
        {
            _sDBRoot = "C:\\SCRATCH\\EDUDBDATA\\";
            _sFilenameCustomer = _sDBRoot + "TblCustomer.tsv";
            _sFilenameBankAccount = _sDBRoot + "TblBankAccount.tsv";
            _arrtCust = ReadCustomers();

        }

        private TCustomer[] ReadCustomers()
        {
            TCustomer[] arrtCust = null;
            if (File.Exists(_sFilenameCustomer))
            {
                String[] asData = File.ReadAllLines(_sFilenameCustomer);
                arrtCust = new TCustomer[asData.Length - 1];
                if (String.CompareOrdinal(_sHeaderCustomer, asData[0]) != 0)
                {
                    throw new Exception("Data Corruption");
                }
                for (int j = 1; j < asData.Length; j++)
                {
                    String s = asData[j];
                    String[] asParts = s.Split("\t");
                    if (asParts.Length != _jFieldCountCustomer)
                    {
                        throw new Exception("Data Corruption");
                    }
                    TCustomer tCust = new TCustomer();
                    int jPart = 0;
                    tCust._sID = asParts[jPart];
                    jPart++;
                    tCust._sName = asParts[jPart];
                    jPart++;
                    tCust._sIdentifications = asParts[jPart];
                    jPart++;
                    tCust._sCurrentAddressLine1 = asParts[jPart];
                    jPart++;
                    tCust._sCurrentAddressLine2 = asParts[jPart];
                    jPart++;
                    tCust._sCity = asParts[jPart];
                    jPart++;
                    tCust._sProvince = asParts[jPart];
                    jPart++;
                    tCust._sState = asParts[jPart];
                    jPart++;
                    tCust._sPostCode = asParts[jPart];
                    jPart++;
                    tCust._sCountry = asParts[jPart];
                    jPart++;
                    tCust._sContactNoM = asParts[jPart];
                    jPart++;
                    tCust._sContactNoL = asParts[jPart];
                    jPart++;
                    tCust._sEmail = asParts[jPart];
                    jPart++;
                    tCust._sExtraInfo = asParts[jPart];
                    jPart++;
                    arrtCust[j - 1] = tCust;
                }
            }
            return arrtCust;
        }

        public void WriteToFile(EduDB.DBModel.TCustomer[] arrtCust)
        {
            _arrtCust = arrtCust;
            String s = _sHeaderCustomer;
            File.WriteAllText(_sFilenameCustomer, s + "\r\n");
            int j = 0;
            for (j = 0; j < arrtCust.Length; j++)
            {
                EduDB.DBModel.TCustomer tCust = arrtCust[j];
                StringBuilder sb = new StringBuilder();
                sb.Append(tCust._sID);
                sb.Append('\t');
                sb.Append(tCust._sName);
                sb.Append('\t');
                sb.Append(tCust._sIdentifications);
                sb.Append('\t');
                sb.Append(tCust._sCurrentAddressLine1);
                sb.Append('\t');
                sb.Append(tCust._sCurrentAddressLine2);
                sb.Append('\t');
                sb.Append(tCust._sCity);
                sb.Append('\t');
                sb.Append(tCust._sProvince);
                sb.Append('\t');
                sb.Append(tCust._sState);
                sb.Append('\t');
                sb.Append(tCust._sPostCode);
                sb.Append('\t');
                sb.Append(tCust._sCountry);
                sb.Append('\t');
                sb.Append(tCust._sContactNoM);
                sb.Append('\t');
                sb.Append(tCust._sContactNoL);
                sb.Append('\t');
                sb.Append(tCust._sEmail);
                sb.Append('\t');
                sb.Append(tCust._sExtraInfo);
                sb.Append("\r\n");
                s = sb.ToString();
                File.AppendAllText(_sFilenameCustomer, s);

             

            }

            IComparisonMaker<TCustomer> ctcbn = new CompareTCustomerByName();
            int[] arrIndexByName = Sorter.doIndexByBubbleSort(arrtCust, true, ctcbn);
            IComparisonMaker<TCustomer> ctcbm = new CompareTCustomerByMobile();
            int[] arrIndexByMobile = Sorter.doIndexByBubbleSort(arrtCust, true, ctcbm);
        }
        public void WriteToFile(EduDB.DBModel.TBankAccount tacc)
        {

            String s = _sHeaderBankAccount;
            File.WriteAllText(_sFilenameBankAccount, s + "\r\n");
            StringBuilder sb = new StringBuilder();
            sb.Append(tacc._sACNO);
            sb.Append('\t');
            sb.Append(tacc._qBalance);
            sb.Append('\t');
            sb.Append(tacc._dtStamp.ToString("yyyy-MM-dd:HH:mm:ss"));
            sb.Append('\t');
            sb.Append(tacc._sBrachCode);
            sb.Append('\t');
            sb.Append(tacc._fCheckbook);
            sb.Append('\t');
            sb.Append(tacc._fDebitCard);
            sb.Append('\t');
            sb.Append(tacc._eOperationMode);
            sb.Append('\t');
            sb.Append(tacc._sRestrictions);
            sb.Append('\t');
            for (int j = 0; j < tacc._arrsID_Customer_fk.Length; j++)
            {
                if (!FEnsureCustomer(tacc._arrsID_Customer_fk[j]))
                {
                    throw new Exception("Unknown Customer ID = " + tacc._arrsID_Customer_fk[j]);
                }
                if (j > 0)
                {
                    sb.Append('\t');
                }
                sb.Append(tacc._arrsID_Customer_fk[j]);
            }

            sb.Append("\r\n");
            s = sb.ToString();
            File.AppendAllText(_sFilenameBankAccount, s);
        }

        private bool FEnsureCustomer(String sID)
        {

            int j;
            for (j = 0; j < _arrtCust.Length; j++)
            {
                if (String.Compare(_arrtCust[j]._sID, sID) == 0)
                {
                    break;
                }
            }
            return (j < _arrtCust.Length);
        }
    }
}
