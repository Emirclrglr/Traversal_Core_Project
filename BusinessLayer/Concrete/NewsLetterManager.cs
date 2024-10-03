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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void TDelete(NewsLetter entity)
        {
            _newsLetterDal.Delete(entity);
        }

        public NewsLetter TGetByID(int id)
        {
            return _newsLetterDal.GetById(id);
        }

        public List<NewsLetter> TGetList()
        {
            return _newsLetterDal.GetList();
        }

        public List<NewsLetter> TGetListByFilter(Expression<Func<NewsLetter, bool>> filter)
        {
            return _newsLetterDal.GetListByFilter(filter);
        }

        public void TInsert(NewsLetter entity)
        {
            _newsLetterDal.Insert(entity);
        }

        public void TUpdate(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }
    }
}
