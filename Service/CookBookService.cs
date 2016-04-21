<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class CookBookService : BaseService<CookBook>
    {
        public bool Add(CookBookTsfer cookBook)
        {
            //这里增加菜过程的插入
            base.Add(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            base.Add<CookProcess>(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookBook.ListProcess));
            base.Add<CookMaterial>(TransferObject.ConvertObjectByEntity<CookMaterialTsfer, CookMaterial>(cookBook.ListMaterial));
            return Save() > 0;
        }
        public bool Update(CookBookTsfer cookBook)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public CookBookTsfer Get(string  cookBookId)
        {
            return TransferObject.ConvertObjectByEntity<CookBook,CookBookTsfer>(base.Select(o=>o.CookBookId==cookBookId).FirstOrDefault());
        }

        public List<CookBookTsfer> GetList(int userId,int status)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(Select(o => o.UserId == userId&&o.Status==status).OrderByDescending(o => o.DateTime).ToList());
        }

    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using DataTransfer;
using Tool;

namespace Service
{
    public class CookBookService : BaseService<CookBook>
    {
        public bool Add(CookBookTsfer cookBook)
        {
            //这里增加菜过程的插入
            base.Add(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            base.Add<CookProcess>(TransferObject.ConvertObjectByEntity<CookProcessTsfer, CookProcess>(cookBook.ListProcess));
            base.Add<CookMaterial>(TransferObject.ConvertObjectByEntity<CookMaterialTsfer, CookMaterial>(cookBook.ListMaterial));
            return Save() > 0;
        }
        public bool Update(CookBookTsfer cookBook)
        {
            base.Update(TransferObject.ConvertObjectByEntity<CookBookTsfer, CookBook>(cookBook));
            return Save() > 0;
        }
        public bool Delete(int id)
        {
            base.Delete(id);
            return Save() > 0;
        }
        public CookBookTsfer Get(string  cookBookId)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(base.Select(o => o.CookBookId == cookBookId).FirstOrDefault());
        }

        public List<CookBookTsfer> GetList(int userId,int status)
        {
            return TransferObject.ConvertObjectByEntity<CookBook, CookBookTsfer>(Select(o => o.UserId == userId&&o.Status==status).OrderByDescending(o => o.DateTime).ToList());
        }

    }
}
>>>>>>> b203b63077616f3d5067d0a19d132b6f64d0d53c
