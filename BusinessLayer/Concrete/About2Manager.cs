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
    public class About2Manager : IAbout2Service
    {
        IAbout2Dal _about2Dal;

        public About2Manager(IAbout2Dal about2Dal)
        {
            _about2Dal = about2Dal;
        }

        public void TDelete(About2 entity)
        {
            _about2Dal.Delete(entity);
        }

        public About2 TGetByID(int id)
        {
            return _about2Dal.GetById(id);
        }

        public List<About2> TGetList()
        {
            return _about2Dal.GetList();
        }

        public List<About2> TGetListByFilter(Expression<Func<About2, bool>> filter)
        {
            return _about2Dal.GetListByFilter(filter);
        }

        public void TInsert(About2 entity)
        {
            _about2Dal.Insert(entity);
        }

        public void TUpdate(About2 entity)
        {
            _about2Dal.Update(entity);
        }
    }
}
