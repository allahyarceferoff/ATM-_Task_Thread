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
    public class EFCardRepository : ICardRepository
    {
        ATMContext _context=new ATMContext();       
        public void AddData(Card data)
        {
            _context.Cards.Add(data);   
            _context.SaveChanges();
        }

        public void DeleteData(Card data)
        {
            throw new NotImplementedException();
        }

        public Card GetData(int id)
        {
            var result = from c in _context.Cards
                         select c;
            var card = result.FirstOrDefault(c=>c.Id==id);
            return card;
        }

        public ObservableCollection<Card> GetAll()
        {
            var result = from c in _context.Cards
                         select c;
            return new ObservableCollection<Card>(result);
        }

        public void UpdateData(Card data)
        {
            throw new NotImplementedException();
        }
    }
}
