using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov.Classes
{
    public enum TypeAccount
    {
        Save,
        Check,
        Credit
    }
    public class BankAccount : IDisposable
    {
        private static int NumberCounter = 0;
        private string Number;
        private decimal balance;
        private TypeAccount typeAccount;
        private Queue<BankTransaction> transactions;
        private bool disposed = false;


        public BankAccount()
        {
            this.Number = GenerateNumber();
            this.balance = 0;
            this.typeAccount = TypeAccount.Check;
            this.transactions = new Queue<BankTransaction>();
        }

        public BankAccount(decimal beginningBalance)
        {
            this.Number = GenerateNumber();
            this.balance = beginningBalance;
            this.typeAccount = TypeAccount.Check;
            this.transactions = new Queue<BankTransaction>();
        }

        public BankAccount(TypeAccount typeAccount)
        {
            this.Number = GenerateNumber();
            this.balance = 0;
            this.typeAccount = typeAccount;
            this.transactions = new Queue<BankTransaction>();
        }

        public BankAccount(decimal beginningBalance, TypeAccount typeAccount)
        {
            this.Number = GenerateNumber();
            this.balance = beginningBalance;
            this.typeAccount = typeAccount;
            this.transactions   = new Queue<BankTransaction>();
        }

        public void Transfer(BankAccount destinationAccount, decimal sum)
        {
            if (destinationAccount == this)
            {
                Console.WriteLine("Нельзя переводить деньги на тот же счет\n");
                return;
            } 

            if (sum > 0 && sum <= balance)
            {
                balance -= sum;
                destinationAccount.balance += sum;
                transactions.Enqueue(new BankTransaction(-sum));
                destinationAccount.transactions.Enqueue(new BankTransaction(sum));
                Console.WriteLine($"Вы перевели со счета {Number} на счет {destinationAccount.Number} сумму {sum}. Текущий баланс: {balance}\n");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств или неккоректная сумма перевода\n");
            }
        }

        public void Refill(decimal sum)
        {
            if (sum > 0)
            {
                balance += sum;
                transactions.Enqueue(new BankTransaction(sum));
                Console.WriteLine($"Ваш счет пополнен на сумму {sum}. Текущий баланс: {balance}\n");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной\n");
            }
        }

        public void Withdraw(decimal sum)
        {
            if (sum > 0 && sum <= balance)
            {
                balance -= sum;
                transactions.Enqueue(new BankTransaction(-sum));
                Console.WriteLine($"Вы сняли со счета {sum}. Текущий баланс: {balance}\n");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств или некорректная сумма снятия\n");
            }
        }

        private string GenerateNumber()
        {
            NumberCounter++;
            return $"{NumberCounter:0000}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Номер счета: {Number}");
            Console.WriteLine($"Текущий баланс: {balance}");
            Console.WriteLine($"Тип счета: {typeAccount}\n");
        }
        public void DisplayTransactions()
        {
            Console.WriteLine($"Транзакции для счета {Number}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Сумма: {transaction.Amount}, Дата: {transaction.TransactionDate}");
            }
        }   

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    using (StreamWriter writer = new StreamWriter($"{Number}_transactions.txt"))
                    {
                        foreach (var transaction in transactions)
                        {
                            writer.WriteLine($"Сумма: {transaction.Amount}, Дата: {transaction.TransactionDate}");
                        }
                    }
                }
                disposed = true;
            }
        }

        ~BankAccount()
        {
            Dispose(false);
        }
    }
}