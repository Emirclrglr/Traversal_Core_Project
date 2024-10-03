using BusinessLayer.Abstract.AbstractUoW;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUoW
{
    public class BankAccountManager : IBankAccountService
    {
        private readonly IBankAccountDal _bankAccountDal;
        private readonly IUoWDal _uoWDal;

        public BankAccountManager(IBankAccountDal bankAccountDal, IUoWDal uoWDal)
        {
            _bankAccountDal = bankAccountDal;
            _uoWDal = uoWDal;
        }

        public BankAccount TGetById(int id)
        {
            return _bankAccountDal.GetById(id);
        }

        public void TInsert(BankAccount entity)
        {
            _bankAccountDal.Insert(entity);
            _uoWDal.Save();
        }

        public void TMultiUpdate(List<BankAccount> entity)
        {
            _bankAccountDal.MultiUpdate(entity);
            _uoWDal.Save();
        }

        public void TUpdate(BankAccount entity)
        {
            _bankAccountDal.Update(entity);
            _uoWDal.Save();
        }
    }
}
