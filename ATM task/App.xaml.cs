using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ATM_task.DataAccess.Abstractions;
using ATM_task.DataAccess.Concrete;
using ATM_task.Entities;

namespace ATM_task
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ATMContext Database { get; set; }
        public static IUnitOfWork DB;

        public App()
        {
            DB = new UnitOfWork();
            Database = new ATMContext();

            if (DB.customerRepository.GetAll().Count == 0)
            {
                DB.customerRepository.AddData(new Customer { FullName = "Amin Atakishiyev" });
                DB.customerRepository.AddData(new Customer { FullName = "Eynal Baxshiyev" });
                DB.customerRepository.AddData(new Customer { FullName = "Murad Azizov" });
                DB.customerRepository.AddData(new Customer { FullName = "Vusal Haciyev" });
            }

            if (DB.cardRepository.GetAll().Count == 0)
            {
                DB.cardRepository.AddData(new Card { CardNumber = "1111111111111111", Balance = 1231274, CustomerId = 1 });
                DB.cardRepository.AddData(new Card { CardNumber = "2222222222222222", Balance = 199365, CustomerId = 2 });
                DB.cardRepository.AddData(new Card { CardNumber = "3333333333333333", Balance = 152467, CustomerId = 3 });
                DB.cardRepository.AddData(new Card { CardNumber = "4444444444444444", Balance = 823748, CustomerId = 4 });
            }
        }
    }
}
