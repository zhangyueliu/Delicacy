using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DataTransfer
{
    public class UserInfoQuery:QueryBase
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set {
                SetChangedProperty("UserId");
                _userId = value; }
        }
        private string _loginId;

        public string LoginId
        {
            get { return _loginId; }
            set {
                SetChangedProperty("LoginId");
                _loginId = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                SetChangedProperty("Name");
                _name = value; }
        }
        private System.DateTime _registerDate;

        public System.DateTime RegisterDate
        {
            get { return _registerDate; }
            set {
                SetChangedProperty("RegisterDate");
                _registerDate = value; }
        }
    }
}
