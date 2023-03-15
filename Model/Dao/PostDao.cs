using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class PostDao
    {
        P10DbContext db = new P10DbContext();
            public bool Delete(int id)
            {
                try
                {
                    var post = db.Posts.Find(id);
                    db.Posts.Remove(post);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }


        }
}
