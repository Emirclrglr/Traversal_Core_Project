﻿using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal:IGenericDal<Guide>
    {
        void SetStatusActive(int id);
        void SetStatusPassive(int id);
        Task<Unit> InsertAsync(Guide guide);
    }
}
