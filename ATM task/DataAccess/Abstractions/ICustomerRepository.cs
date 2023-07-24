using ATM_task.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.DataAccess.Abstractions
{
    public interface ICustomerRepository:IRepository<Customer>
    {
    }
}
