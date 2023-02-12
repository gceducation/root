using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EduDB.DBModel;
namespace EduDB
{
    class EduDBMain
    {

        public void Initialize()
        {
            RandomDataGenerator rdg = new RandomDataGenerator(99);
            TSVManager tsvMgr = new TSVManager();
            tsvMgr.Initialize();

            // List<TCustomer> lsttCustFound = tsvMgr.getCustomersByName("Gadre");

            TCustomer[] arrtCust = new TCustomer[12];
            for (int j = 0; j < arrtCust.Length; j++)
            {
                TCustomer tcust = new TCustomer();
                tcust._sCity = "Pune";
                tcust._sContactNoL = rdg.getStringByPattern("``````````");
                tcust._sContactNoM = rdg.getStringByPattern("``````````");
                tcust._sCountry = "India";
                tcust._sCurrentAddressLine1 = rdg.getStringByPattern("H.No. ``` Street No. ```");
                tcust._sCurrentAddressLine2 = rdg.getStringByPattern("Sector ``");
                tcust._sEmail = rdg.getStringByPattern("~~~~~~~~~~~~@~~~~~~.com");
                tcust._sExtraInfo = "";
                tcust._sID = Guid.NewGuid().ToString();
                tcust._sIdentifications = rdg.getStringByPattern("PAN:~~~~~```~");
                tcust._sName = rdg.getRandomPersonName();
                tcust._sPostCode = rdg.getStringByPattern("``````");
                tcust._sProvince = "-";
                tcust._sState = "MH";
                arrtCust[j] = tcust;
            }
            tsvMgr.WriteToFile(arrtCust);

            TBankAccount tbacc = new TBankAccount();
            tbacc._fCheckbook = true;
            tbacc._fDebitCard = false;
            tbacc._eOperationMode = OperationMode.Single;
            tbacc._qBalance = 0;
            tbacc._sACNO = "AAA1123";
            tbacc._sBrachCode = "PQRST12345";
            tbacc._dtStamp = DateTime.Now;
            tbacc._sRestrictions = "none";
            tbacc._arrsID_Customer_fk = new String[] { "3c1c6028-be5f-49fa-819d-22094fa4c8f5", "c434603c-36ae-4c59-a068-d974f4990d86" };

            tsvMgr.WriteToFile(tbacc);
        }
        public static void Initialize_unused()
        {
            CSVManager csvMgr = new CSVManager();
            String str = File.ReadAllText("c:/scratch/data.csv");

            CSVData csvData = csvMgr.Parse(str, true);
            for (int j = 0; j < csvData._llData.Count; j++)
            {
                String sTemp = csvMgr.getCSVString(csvData._llData[j]);
            }

        }
    }
}
