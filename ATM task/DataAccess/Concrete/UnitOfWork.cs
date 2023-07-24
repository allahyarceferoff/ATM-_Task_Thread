using ATM_task.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICardRepository cardRepository => new EFCardRepository();    
        public ICustomerRepository customerRepository => new EFCustomerRepository();            
    }
}
