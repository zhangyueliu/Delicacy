<<<<<<< HEAD
﻿using System;
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
    }
}
=======
﻿using System;
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
    }
}
>>>>>>> bc713627a7c0049a3fb5b10ca0918402f23cbbd2
