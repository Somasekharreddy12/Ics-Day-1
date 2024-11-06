using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmet_3
{
    class Accounts
    {
        private int accountNo;
        private string Customername;
        private string accounttype;
        private string transactiontype;
        private int amount;
        private int balance;
        
        public Accounts (int accno, string Custname, string accttype, int initialbalance)
        {
            accountNo = accno;
            Customername = Custname;
            accounttype = accttype;
            balance = initialbalance;
        }
        public void updateBalance(string transtype,int amt)
        {
            transactiontype = transtype.ToLower();
            amount = amt;
            if(transactiontype == "s")
            {
                credit(amount);
            }
            else if(transactiontype == "o")
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("invalid transaction");
            }

        }
        private void credit(int amount)
        {
            balance += amount;
            Console.WriteLine($"{amount} has been credited to your account.");
        }
         private void Debit(int amount)
        {
            if(amount > balance)
            {
                Console.WriteLine("insufficient balance.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"{amount} has been Debited to your account.");
            }
        }
        public void showdata()
        {
            Console.WriteLine("account datails:");
            Console.WriteLine($"Account No:{accountNo}");
            Console.WriteLine($"Customer name:{Customername}");
            Console.WriteLine($"Account type:{accounttype}");
            Console.WriteLine($"Transaction Type:{(transactiontype == "d"? "deposit":"withdrawal")}");
            Console.WriteLine($"transaction amount:{amount}");
            Console.WriteLine($"Customer balance:{balance}");
        }
        
    }
    class program
    {
        static void Main()
        {
            Accounts account = new Accounts(517126, "somu", "salary", 30000);
            Console.Write("enter transaction type(  for deposit,  for withdrawal):");
            string transtype = Console.ReadLine();
            Console.Write("enter ammount: ");
            int amt = int.Parse(Console.ReadLine());

            account. updateBalance(transtype, amt);

            account.showdata();
            Console.Read();



        }
    }
}
