using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountOwner { get; set; }
        public decimal Balance { get; set; }
    }
}
