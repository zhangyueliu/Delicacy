using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class PageInfo
    {
        private string pageQueryStringName = "page";

        public PageInfo()
        {
            if (System.Web.HttpContext.Current != null)
            {
                int p;
                if (int.TryParse(System.Web.HttpContext.Current.Request.QueryString[pageQueryStringName] ?? "1", out p))
                {
                    CurrentPage = p;
                }
            }
        }
        int _PageSize;      //每页条数
        int _CurrentPage;   //当前页码
        int _RowCount;    //总条数

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)RowCount / (double)PageSize);
            }
        }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize
        {
            get { return _PageSize < 1 ? 10 : _PageSize; }
            set { _PageSize = value; }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage
        {
            get { return _CurrentPage < 1 ? 1 : _CurrentPage; }
            set { _CurrentPage = value; }
        }

        /// <summary>
        /// 总条数
        /// </summary>
        public int RowCount
        {
            get { return _RowCount < 0 ? 0 : _RowCount; }
            set
            {
                _RowCount = value;
            }
        }
        public enum PageButtonType { 页码, 首页, 上页, 下页, 尾页 }
        public class PageUrl
        {
            public int Page { get; set; }
            public string Url { get; set; }

            public PageButtonType Type { get; set; }
        }

        /// <summary>
        /// 获取需要显示的页码，前后会各加上首页和末页的数据
        /// </summary>
        /// <param name="count">显示多少个数目</param>
        /// <returns></returns>
        public List<PageUrl> GetPageUrls(int count = 10)
        {

            if (RowCount == 0) return new List<PageUrl>();
            var url = "";
            if (System.Web.HttpContext.Current != null)
            { int p;
                if (int.TryParse(System.Web.HttpContext.Current.Request.QueryString[pageQueryStringName] ?? "1", out p))
                {
                    CurrentPage = p;
                }
                url = System.Web.HttpContext.Current.Request.Url.ToString();
            }
            url = System.Text.RegularExpressions.Regex.Replace(url, string.Format(@"[?&]{0}=\d*", pageQueryStringName), "");
            if (url.Contains("?"))
            {
                url = url + "&{0}={1}";
            }
            else
            {
                url = url + "?{0}={1}";
            }
            List<PageUrl> list = new List<PageUrl>();

            int start = CurrentPage - (int)(Math.Ceiling((double)count / (double)2) - 1);
            start = start > RowCount - count + 1 ? RowCount - count + 1 : start;
            start = start < 1 ? 1 : start;
            if (CurrentPage > 1)
            {
                list.Add(new PageUrl { Type = PageButtonType.首页, Page = 1, Url = string.Format(url, pageQueryStringName, 1) });
                list.Add(new PageUrl { Type = PageButtonType.上页, Page = CurrentPage - 1, Url = string.Format(url, pageQueryStringName, CurrentPage - 1) });
            }
            for (int p = start; p <= start + count - 1 && p <= PageCount; p++)
            {
                list.Add(new PageUrl { Type = PageButtonType.页码, Page = p, Url = string.Format(url, pageQueryStringName, p) });
            }
            if (CurrentPage < PageCount)
            {
                list.Add(new PageUrl { Type = PageButtonType.下页, Page = CurrentPage + 1, Url = string.Format(url, pageQueryStringName, CurrentPage + 1) });
                list.Add(new PageUrl { Type = PageButtonType.尾页, Page = PageCount, Url = string.Format(url, pageQueryStringName, PageCount) });
            }
            return list;
        }
    }
}
