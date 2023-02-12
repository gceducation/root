using System;
using System.Collections.Generic;
using System.Text;

namespace EduDB.DBModel
{
    public enum OperationMode
    {
        Single,
        All,
        AOrS,
    }
    public class TCustomer
    {
        public String _sID;
        public String _sName;
        public String _sIdentifications;
        public String _sCurrentAddressLine1;
        public String _sCurrentAddressLine2;
        public String _sCity;
        public String _sProvince;
        public String _sState;
        public String _sPostCode;
        public String _sCountry;
        public String _sContactNoM;
        public String _sContactNoL;
        public String _sEmail;
        public String _sExtraInfo;
    }


    public class TBankAccount
    {
        public String _sACNO;
        public double _qBalance;
        public DateTime _dtStamp;
        public String _sBrachCode;
        public bool _fCheckbook;
        public bool _fDebitCard;
        public OperationMode _eOperationMode;
        public String _sRestrictions;
        public String [] _arrsID_Customer_fk;
    }
    public class TCreditcard
    {
        public String _sACNO;
        public double _qBalance;
        public double _qLimit;
        public String _sDTStamp;
        public String _sRestrictions;
        public String _sID_Customer_fk;
    }
    public class TTransaction
    {
        public DateTime _sDateTime;
        public double _qAmount;
        public String _sACNO_BACC_fk;
        public String _sFacility;
        public String _sDetails;
        public String _sParty;
    }
}
