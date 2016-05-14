using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
   public static  class CheckParameter
    {
       public static bool IsNullOrEmpty(params string[] param)
       {
           for (int i = 0; i < param.Length; i++)
           {
               if (string.IsNullOrEmpty(param[i]))
                   return true;
           }
           return false;
       }

       public static bool IsNullOrWhiteSpace(params string [] param)
       {
           for (int i = 0; i < param.Length; i++)
           {
               if (string.IsNullOrWhiteSpace(param[i]))
                   return true;
           }
           return false;
       }

       public static void PageCheck(string pageIndex, out int pageindex)
       {
           if(!int.TryParse(pageIndex, out pageindex))
           {
               pageindex=1;
           }
       }

       public static void PageCheck(string pageIndex,string pageSize, out int index,out int size)
       {
           if (!int.TryParse(pageIndex, out index))
           {
               index = 1;
           }
           if (!int.TryParse(pageSize, out size))
               size = 9;
       }
    }
}
