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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutService;

        public AboutManager(IAboutDal aboutService)
        {
            _aboutService = aboutService;
        }

        public void TDelete(About entity)
        {
           _aboutService.Delete(entity);
        }

        public About TGetByID(int id)
        {
            return _aboutService.GetById(id);
        }

        public List<About> TGetList()
        {
            return _aboutService.GetList();
        }

        public List<About> TGetListByFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutService.GetListByFilter(filter);
        }

        public void TInsert(About entity)
        {
            _aboutService.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutService.Update(entity);
        }
    }
}
