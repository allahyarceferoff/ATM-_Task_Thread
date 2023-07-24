using ATM_task.Commands;
using ATM_task.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_task.Domain.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand TransferCommand { get; set; }

        public Card Card { get; set; }

        public Mutex Mutex { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; OnPropertyChanged(); }
        }

        private string cash;

        public string Cash
        {
            get { return cash; }
            set { cash = value; OnPropertyChanged(); }
        }

        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; OnPropertyChanged(); }
        }

        private string amount;

        public string Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }

        bool hasPressedTransferButton = false;

        public MainWindowViewModel()
        {
            string mutexName = "ATMMutex";
            Mutex = new Mutex(false, mutexName);

            LoadCommand = new RelayCommand((obj) =>
            {
                if (CardNumber.Trim().Length == 16)
                {
                    Thread t = new Thread(() =>
                    {
                        Card = App.Database.Cards.FirstOrDefault(c => c.CardNumber == this.CardNumber);
                        if (Card == null)
                        {
                            MessageBox.Show("No card");
                            return;
                        }
                        var customerID = Card.CustomerId;
                        var customer = App.Database.Customers.FirstOrDefault(c => c.Id == customerID);
                        Name = $"{customer.FullName}";
                        Balance = (int)Card.Balance;
                    });
                    t.Start();
                }
                else
                {
                    MessageBox.Show("Enter correct card number");
                }
            });

            TransferCommand = new RelayCommand((obj) =>
            {
                lock (this)
                {

                    Thread transferThread = new Thread(() =>
                    {

                        if (hasPressedTransferButton == false)
                        {
                            if (Amount.Trim() == String.Empty)
                            {
                                if (Card == null)
                                {
                                    MessageBox.Show("Enter card number first");
                                }
                                else
                                {
                                    MessageBox.Show("Enter money amount to transfer");
                                }
                                return;
                            }
                            if (Balance - decimal.Parse(Amount) >= 0)
                            {
                                Mutex.WaitOne();
                                hasPressedTransferButton = true;
                                decimal value = decimal.Parse(Amount) / 10;
                                Cash = "0 AZN";
                                var currentAmount = Amount;
                                for (int i = 1; i <= 10; i++)
                                {
                                    Thread.Sleep(200);
                                    Cash = ((int)(value * i)).ToString();
                                    Amount = (int.Parse(currentAmount) - int.Parse(Cash)).ToString();
                                }
                                var m = decimal.Parse(currentAmount.ToString());
                                Balance -= m;
                                Card.Balance -= m;
                                App.Database.SaveChanges();
                                MessageBox.Show($"{currentAmount} AZN was transferred successfully");
                                hasPressedTransferButton = false;
                                Mutex.ReleaseMutex();
                                CardNumber = string.Empty;
                                Name = string.Empty;
                                Amount = string.Empty;
                                Cash = string.Empty;
                                Balance = 0;
                            }

                            else
                            {
                                MessageBox.Show("Not enough money in balance");
                            }
                        }

                    });
                    transferThread.Start();
                }
            });
        }
    }
}