using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using Service;
using DataTransfer;

namespace Manager
{
    public class CommentRecordManager
    {
        private CommentRecordService Service = ObjectContainer.GetInstance<CommentRecordService>();
        public OutputModel Add(CommentRecordTsfer comment)
        {
            if (comment == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Add(comment))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Update(CommentRecordTsfer comment)
        {
            if (comment == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
            if (Service.Update(comment))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        public OutputModel Delete(int id)
        {
            if (Service.Delete(id))
                return OutputHelper.GetOutputResponse(ResultCode.OK);
            return OutputHelper.GetOutputResponse(ResultCode.Error);
        }
        /// <summary>
        /// 获取子评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OutputModel Gets(int id)
        {
            List<CommentRecordTsfer> list = Service.Gets(id);
            if (list == null)
                return OutputHelper.GetOutputResponse(ResultCode.NoData);
            return OutputHelper.GetOutputResponse(ResultCode.OK, list);
        }
    }
}
