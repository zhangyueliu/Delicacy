using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DataTransfer
{
    public class TasteQuery : QueryBase
    {
        private int _tasteId;

        public int TasteId
        {
            get { return _tasteId; }
            set {
                SetChangedProperty("TasteId");
                _tasteId = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                SetChangedProperty("TasteId");
                _name = value; }
        }
    }
}
