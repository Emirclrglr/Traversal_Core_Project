using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGuideService : IGenericService<Guide>
    {
        void TSetStatusActive(int id);
        void TSetStatusPassive(int id);
        Task<Unit> InsertAsync(Guide guide);

    }
}
