using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.NET
{
    public class DB
    {
        private static String __sTblExt = ".TSV";
        private DB(String sRootDir, String sDBName)
        {
            _sRootDir = sRootDir;
            _sDBName = sDBName;
        }
        public static DB CreateDB(String sRootDir, String sDBName)
        {
            if (!sRootDir.EndsWith("\\"))
            {
                sRootDir += '\\';
            }
            Directory.CreateDirectory(sRootDir + sDBName);
            DB dbRet = new DB(sRootDir, sDBName);
            return dbRet;
        }
        public DB OpenDB(String sRootDir, String sDBName)
        {
            DB dbRet = null;
            if (!sRootDir.EndsWith("\\"))
            {
                sRootDir += '\\';
            }
            if (Directory.Exists(sRootDir + sDBName))
            {
                dbRet = new DB(sRootDir, sDBName);
            }
            return dbRet;
        }
        private String _sRootDir;
        private String _sDBName;

        private List<DBTable> _lstDbTbl = new List<DBTable>();

        public void AddTable(DBTable dbtbl)
        {
            int j;
            for (j = 0; j < _lstDbTbl.Count; j++)
            {
                if (String.Compare(_lstDbTbl[j]._sName, dbtbl._sName, true) == 0)
                {
                    break;
                }
            }
            if (j < _lstDbTbl.Count)
            {
                throw new Exception("Table already Exists");
            }

            String sFileTbl = _sRootDir + _sDBName + '\\' + dbtbl._sName + __sTblExt;
            if (File.Exists(sFileTbl))
            {
                throw new Exception("TBL File already Exists");
            }
            List<String> lstStr;

            String[] arrStrHeader = new String[2];
            List<String> lstStrFN = new List<String>();
            List<String> lstStrFT = new List<String>();
            for (j = 0; j < dbtbl._lstField.Count; j++)
            {
                lstStrFN.Add(dbtbl._lstField[j]._sName);
                lstStrFT.Add(dbtbl._lstField[j]._eft.ToString());
            }
            arrStrHeader[0] = Util.Concat(lstStrFN);
            arrStrHeader[1] = Util.Concat(lstStrFT);
            File.WriteAllLines(sFileTbl, arrStrHeader);
            _lstDbTbl.Add(dbtbl);
        }
        public void AddRow(String sNameTbl, IEnumerable<Object> lstData)
        {
            DBTable dbtbl = null;
            int j;
            for (j = 0; j < _lstDbTbl.Count; j++)
            {
                if (String.Compare(_lstDbTbl[j]._sName, sNameTbl, true) == 0)
                {
                    dbtbl = _lstDbTbl[j];
                    break;
                }
            }
            AddRow(dbtbl, lstData);
        }
        public void AddRow(DBTable dbtbl, IEnumerable<Object> lstData)
        {
            String sFileTbl = _sRootDir + _sDBName + '\\' + dbtbl._sName + __sTblExt;
            String[] arrStr = new String[dbtbl._lstField.Count];
            int j;
            for (j = 0; j < dbtbl._lstField.Count; j++)
            {
                arrStr[j] = lstData.ElementAt(j).ToString();
            }
            
            String sOut = Util.Concat(arrStr);
            String[] arrsOut = new string [] { sOut };
            File.AppendAllLines(sFileTbl, arrsOut);
        }
    }
    public enum EFieldType
    {
        Integer,
        Decimal,
        Text,
        Boolean,
        Datetime,
        Guid
    }

    public class DBField
    {
        public String _sName;
        public EFieldType _eft;
        public Boolean _fAllowNull;
        public Boolean _fIsIndexed;
    }
    public class DBTable
    {
        public String _sName;
        public List<DBField> _lstField;
    }
}
