using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class SupportScanRecordService : BaseService<SupportScanRecord>
    {
        public bool Add(SupportScanRecordTsfer support)
        {
            base.Add(TransferObject.ConvertObjectByEntity<SupportScanRecordTsfer, SupportScanRecord>(support));
            return Save() > 0;
        }
        public bool Update(SupportScanRecordTsfer support)
        {
            base.Update(TransferObject.ConvertObjectByEntity<SupportScanRecordTsfer, SupportScanRecord>(support));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public SupportScanRecordTsfer Select(int id)
        {
            return TransferObject.ConvertObjectByEntity<SupportScanRecord, SupportScanRecordTsfer>(base.Select(id));
        }
    }
}
