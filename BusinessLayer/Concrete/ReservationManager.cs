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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TDelete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> TGetListByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.GetListByFilter(filter);
        }

        public List<Reservation> TGetListWithDestination()
        {
            return _reservationDal.GetListWithDestination();
        }

        public List<Reservation> TGetListWithDestinationByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.GetListWithDestinationByFilter(filter);
        }

        public void TInsert(Reservation entity)
        {
            _reservationDal.Insert(entity);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
