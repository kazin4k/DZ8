using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tumakov.Classes
{
    internal class Program
    {
        private static BankAccount account1;
        private static BankAccount account2;
        private static BankAccount account3;

        static void Main(string[] args)
        {
            InitializeAccounts();
            Task1();
            Task2();
            Task3();
            Task4();
        }

        static void InitializeAccounts()
        {
            account1 = new BankAccount(5000, TypeAccount.Check);
            account2 = new BankAccount(3000, TypeAccount.Save);
            account3 = new BankAccount(TypeAccount.Credit);
        }

        static void Task1()
        {
            Console.WriteLine("Информация о счетах:");
            account1.DisplayInfo();
            account2.DisplayInfo();
            account3.DisplayInfo();
        }

        static void Task2()
        {
            Console.WriteLine("Выполнение операций:");
            account1.Refill(200);
            account2.Refill(300);

            account1.Withdraw(150);
            account2.Withdraw(100);

            account1.Transfer(account2, 200);
            account2.Transfer(account3, 50);
            account3.Transfer(account1, 100);

            Console.WriteLine("Транзакции для каждого счета:");
            account1.DisplayTransactions();
            account2.DisplayTransactions();
            account3.DisplayTransactions();
        }

        static void Task3()
        {
            account1.Dispose();
            account2.Dispose();
            account3.Dispose();
        }

        static void Task4()
        {
            Song mySong = new Song();
            mySong.SetName("Imagine");
            mySong.SetAuthor("John Lennon");
            mySong.PrintInfo();

            Song anotherSong = new Song("Bohemian Rhapsody", "Queen");
            anotherSong.PrintInfo();

            Song previousSong = new Song("Hey Jude", "The Beatles");
            Song linkedSong = new Song("Yesterday", "The Beatles", previousSong);
            linkedSong.PrintInfo();
            Console.WriteLine($"\n\rПредыдущая песня: {linkedSong.Title()}");
        }
    }
}
