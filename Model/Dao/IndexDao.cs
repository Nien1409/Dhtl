using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using PagedList.Mvc;

namespace Model.Dao
{
    public class IndexDao
    {
        P10DbContext db = null;
        public IndexDao()
        {
            db = new P10DbContext();
        }
        public IEnumerable<Posts> ListAllPaging(int page, int pageSize)
        {
            return db.Posts.OrderByDescending(x=>x.PostsID).ToPagedList(page, pageSize);
        }



      
    }
}
