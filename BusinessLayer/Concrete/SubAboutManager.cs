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
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void TDelete(SubAbout entity)
        {
            _subAboutDal.Delete(entity);
        }

        public SubAbout TGetByID(int id)
        {
            return _subAboutDal.GetById(id);
        }

        public List<SubAbout> TGetList()
        {
            return _subAboutDal.GetList();
        }

        public List<SubAbout> TGetListByFilter(Expression<Func<SubAbout, bool>> filter)
        {
            return _subAboutDal.GetListByFilter(filter);
        }

        public void TInsert(SubAbout entity)
        {
            _subAboutDal.Insert(entity);
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }
    }
}
