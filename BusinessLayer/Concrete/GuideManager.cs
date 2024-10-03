using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public async Task<Unit> InsertAsync(Guide guide)
        {
            await _guideDal.InsertAsync(guide);
            return Unit.Value;
        }

        public void TDelete(Guide entity)
        {
            _guideDal.Delete(entity);
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetById(id);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public List<Guide> TGetListByFilter(Expression<Func<Guide, bool>> filter)
        {
            return _guideDal.GetListByFilter(filter);
        }

        public void TInsert(Guide entity)
        {
            _guideDal.Insert(entity);
        }

        public void TSetStatusActive(int id)
        {
            _guideDal.SetStatusActive(id);
        }

        public void TSetStatusPassive(int id)
        {
            _guideDal.SetStatusPassive(id);
        }

        public void TUpdate(Guide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
