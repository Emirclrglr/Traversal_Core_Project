﻿using BusinessLayer.Abstract;
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
    public class Feature2Manager:IFeature2Service
    {
        IFeature2Dal _feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void TDelete(Feature2 entity)
        {
            _feature2Dal.Delete(entity);
        }

        public Feature2 TGetByID(int id)
        {
            return _feature2Dal.GetById(id);
        }

        public List<Feature2> TGetList()
        {
            return _feature2Dal.GetList();
        }

        public List<Feature2> TGetListByFilter(Expression<Func<Feature2, bool>> filter)
        {
            return _feature2Dal.GetListByFilter(filter);
        }

        public void TInsert(Feature2 entity)
        {
            _feature2Dal.Insert(entity);
        }

        public void TUpdate(Feature2 entity)
        {
            _feature2Dal.Update(entity);
        }
    }
}
