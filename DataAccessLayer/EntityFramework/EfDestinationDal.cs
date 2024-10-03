using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        private readonly Context _context;

        public EfDestinationDal(Context context)
        {
            _context = context;
        }

        public Destination GetDestinationByIdWithGuide(int id)
        {
            return _context.Destinations.Include(x => x.Guide).SingleOrDefault(x => x.Id == id);
        }

        public List<Destination> GetLast4Destinations()
        {
            return _context.Destinations.OrderByDescending(x => x.Id).Take(4).ToList();
        }
    }
}
