using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void DeleteMessage(int id)
        {
            using(var context = new Context())
            {
                var value = context.ContactUsTbl.Find(id);
                if (value != null)
                {
                    value.Status = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
