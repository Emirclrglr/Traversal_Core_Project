using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TDelete(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
        }

        public void TDeleteMessage(int id)
        {
            _contactUsDal.DeleteMessage(id);
        }

        public ContactUs TGetByID(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListByFilter(Expression<Func<ContactUs, bool>> filter)
        {
            return _contactUsDal.GetListByFilter(filter);
        }

        public void TInsert(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void TUpdate(ContactUs entity)
        {
            _contactUsDal.Update(entity);
        }
    }
}
