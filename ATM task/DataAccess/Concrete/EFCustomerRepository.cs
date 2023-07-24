using ATM_task.DataAccess.Abstractions;
using ATM_task.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.DataAccess.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        ATMContext _context = new ATMContext();
        public void AddData(Customer data)
        {
            _context.Customers.Add(data);
            _context.SaveChanges(); 
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAll()
        {
            var result = from c in _context.Customers
                         select c;
            return new ObservableCollection<Customer>(result);
        }

        public Customer GetData(int id)
        {
            var result = from c in _context.Customers
                         select c;
            var customer = result.FirstOrDefault(c=>c.Id==id);
            return customer;
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
