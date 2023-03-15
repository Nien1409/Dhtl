using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao

{
    public class UserDao
    {
        P10DbContext db = null;
        public UserDao()
        {
            db = new P10DbContext();
        }
        public long Insert(Users entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UsersID;
        }
        public bool Update(Users entity)
        {
            try
            {
                var user = db.Users.Find(entity.UsersID);
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Phone = entity.Phone;

                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }

                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public IEnumerable<Users> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.UsersID).ToPagedList(page, pageSize);
        }

   
        
        //user


        public Users GetbyId(string Name)
        {
            return db.Users.SingleOrDefault(x => x.Name == Name);
        }
        public Users ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        //Post
        public bool DeletePost(int id)
        {
            try
            {
                var xxx = db.Posts.Find(id);
                db.Posts.Remove(xxx);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //login
        public int Login(string Name, string Password)
        {
            var result = db.Users.SingleOrDefault(x => x.Name == Name);
            if (result == null)
            {
                return 0; //"Tài khoản không tồn tại"
            }
            else
            {
                if (result.Status == false)
                {
                    return -1; //"Tài khoản chưa được kích hoạt"
                }
                else
                {
                    if (result.Password == Password)
                    {
                        return 1; //Password dung
                    }
                    else
                    {
                        return -2; //Password sai 
                    }
                }
            }
        }
    }
}
