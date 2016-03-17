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
      public OutputModel AddCookBook(int userId, string taste, string foodSort, string name, string description, string tips, string finalImg, string processImgDes, string foodMaterial, string status)
      {
          int iTaste, iFoodSort,iStatus;
          if(!int.TryParse(taste,out iTaste)||!int.TryParse(foodSort,out iFoodSort)||!int.TryParse(status,out iStatus))
          {
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter);
          }
          //插入式菜谱的状态只能是0待审核  2存草稿
          if (iStatus != 0 && iStatus != 2)
              return OutputHelper.GetOutputResponse(ResultCode.Error);
          if (CheckParameter.IsNullOrEmpty(name, finalImg, processImgDes,foodMaterial))
              return OutputHelper.GetOutputResponse(ResultCode.NoParameter);
          //检查过程图  listProcess中的CookBookId还没有赋值
          List<CookProcessTsfer> listProcess = GetListProcess(processImgDes);
          if (listProcess.Count == 0)
              return OutputHelper.GetOutputResponse(ResultCode.ConditionNotSatisfied, "请插入菜谱过程");
          //食材  
          
          //判断口味 类别
          TasteService tService = ObjectContainer.GetInstance<TasteService>();
          if (!tService.IsExist(iTaste))
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "口味选择错误");
          FoodSortService foodService = ObjectContainer.GetInstance<FoodSortService>();
          if (!foodService.IsExist(iFoodSort))
              return OutputHelper.GetOutputResponse(ResultCode.ErrorParameter, "类别选择错误");
          //进行插入
          CookBookTsfer bookTsfer = new CookBookTsfer() {
          Description=description,
          FoodSortId=iFoodSort,
          ImgUrl=finalImg,
          Name=name,
          Status = iStatus,
          TasteId=iTaste,
          Tips=tips,
         

          };

         // if(string.IsNullOrEmpty(name)||string.isn)
          return null;
      }


      private List<CookProcessTsfer> GetListProcess(string processImgDes)
      {
          List<CookProcessTsfer> listProcess = new List<CookProcessTsfer>();
          string[] arryProcess = processImgDes.Split(new[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
          //判断图片格式
          foreach (string  item in arryProcess)
          {
              string[] arrImgDesc = item.Split(new[] { "::"}, StringSplitOptions.RemoveEmptyEntries);
              if (arrImgDesc.Length < 2)
                  return new List<CookProcessTsfer>();
              if (RegExVerify.CheckImgExtension(arrImgDesc[0]))
              {
                  CookProcessTsfer cpTsfer = new CookProcessTsfer()
                  {
                      ImgUrl = arrImgDesc[0],
                      Description = arrImgDesc[1]
                  };
                  listProcess.Add(cpTsfer);
              }
              else
                  return new List<CookProcessTsfer>();
          }
          return listProcess;
      }
    }
}
