using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.NET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB db = DB.CreateDB(@"C:\scratch\EDUDBROOT", "SOMEDB");

            DBTable dbTbl = new DBTable();
            dbTbl._sName = "TPerson";
            List<DBField> lstdbf = new List<DBField>();
            lstdbf.Add(new DBField()
            {
                _fAllowNull = false,
                _fIsIndexed = true,
                _sName = "UID",
                _eft = EFieldType.Guid
            });
            lstdbf.Add(new DBField()
            {
                _fAllowNull = false,
                _fIsIndexed = true,
                _sName = "Name",
                _eft = EFieldType.Text
            });
            lstdbf.Add(new DBField()
            {
                _fAllowNull = false,
                _fIsIndexed = true,
                _sName = "Birthdate",
                _eft = EFieldType.Datetime
            });
            lstdbf.Add(new DBField()
            {
                _fAllowNull = false,
                _fIsIndexed = true,
                _sName = "BloodGroup",
                _eft = EFieldType.Text
            });
            dbTbl._lstField = lstdbf;
           // db.AddTable(dbTbl);
            Object[] arrObjData = new Object[4];

            arrObjData[0] = Guid.NewGuid();
            arrObjData[1] = "Mary Doe";
            arrObjData[2] = new DateTime(1987, 6, 9);
            arrObjData[3] = "AB+";

            db.AddRow("TPerson", arrObjData);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
