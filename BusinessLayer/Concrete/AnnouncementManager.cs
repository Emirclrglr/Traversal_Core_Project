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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void TDelete(Announcement entity)
        {
            _announcementDal.Delete(entity);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public List<Announcement> TGetListByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDal.GetListByFilter(filter);
        }

        public void TInsert(Announcement entity)
        {
            _announcementDal.Insert(entity);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}
