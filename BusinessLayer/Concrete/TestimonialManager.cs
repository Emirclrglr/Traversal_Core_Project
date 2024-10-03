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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonalDal;

        public TestimonialManager(ITestimonialDal testimonalDal)
        {
            _testimonalDal = testimonalDal;
        }

        public void TDelete(Testimonial entity)
        {
            _testimonalDal.Delete(entity);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonalDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonalDal.GetList();
        }

        public List<Testimonial> TGetListByFilter(Expression<Func<Testimonial, bool>> filter)
        {
            return _testimonalDal.GetListByFilter(filter);
        }

        public void TInsert(Testimonial entity)
        {
            _testimonalDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonalDal.Update(entity);
        }
    }
}
