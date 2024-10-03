using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        Context context = new();
        public List<Reservation> GetListWithDestination()
            => context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).ToList();


        public List<Reservation> GetListWithDestinationByFilter(Expression<Func<Reservation, bool>> filter)
            => context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Where(filter).ToList();

    }
}
