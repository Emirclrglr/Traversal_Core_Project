using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public async Task<Unit> InsertAsync(Guide guide)
        {
            using (var c = new Context())
            {
                await c.Guides.AddAsync(guide);
                await c.SaveChangesAsync();
                return Unit.Value;
            }
        }

        public void SetStatusActive(int id)
        {
            using var c = new Context();
            var value = c.Guides.Find(id);
            value.Status = true;
            c.SaveChanges();
        }

        public void SetStatusPassive(int id)
        {
            using var c = new Context();
            var value = c.Guides.Find(id);
            value.Status = false;
            c.SaveChanges();
        }
    }
}
