using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Tool;
using DataTransfer;
namespace Manager
{
  public  class CookBookManager
    {
      private CookBookService cookService = ObjectContainer.GetInstance<CookBookService>();
      public OutputModel AddCookBook(string taste, string foodSort, string name, string description, string tips, string finalImg, string processImgDes, string foodMaterial, string status)
      {
          int iTaste, iFoodSort,iStatus;
          if(!int.TryParse(taste,out iTaste)||!int.TryParse(foodSort,out iFoodSort)||!int.TryParse(status,out iStatus))
          {
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
          }
          if (CheckParameter.IsNullOrEmpty(name, finalImg, processImgDes,foodMaterial))
              return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
          //检查过程图跟食材
          List<CookProcessTsfer> listProcess = GetListProcess(processImgDes);





          //判断口味 类别
          TasteService tService = ObjectContainer.GetInstance<TasteService>();
          if (!tService.IsExist(iTaste))
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "口味选择错误");
          FoodSortService foodService = ObjectContainer.GetInstance<FoodSortService>();
          if (!foodService.IsExist(iFoodSort))
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "类别选择错误");

         // if(string.IsNullOrEmpty(name)||string.isn)
          return null;
      }


      private List<CookProcessTsfer> GetListProcess(string processImgDes)
      {
          List<CookProcessTsfer> listProcess = new List<CookProcessTsfer>();
          string[] arryProcess = processImgDes.Split(new[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

          return listProcess;
      }
    }
}
