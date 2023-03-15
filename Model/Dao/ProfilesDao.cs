using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class ProfilesDao
    {
        P10DbContext db = new P10DbContext();

        //profiles
        public bool Delete(int id)
        {
            try
            {
                var profiles = db.Profiles.Find(id);
                db.Profiles.Remove(profiles);
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
