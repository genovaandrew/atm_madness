using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE_ATM_Prototype
{
    public class Bank
    {
        List<Account> accountList;
        //private String name;
        //private int balance;
        Account currentUser;


        public Bank()
        {
            accountList = new List<Account>();
            populateList();
        }


        public void populateList()
        {
            //This is developed for the demo. In practice the users will be generated differently, probably entered by a customer service rep
            Account acct1 = new Account("Alice", 514432234, 1114, 100.0);
            Account acct2 = new Account("Bob", 123456789, 1010, 100.0);
            Account acct3 = new Account("Carol", 154329876, 5430, 0.0);
            accountList.Add(acct1);
            accountList.Add(acct2);
            accountList.Add(acct3);
        }

        public void startSession(String name)
        {
            Boolean isTrue = true;
            for (int i = 0; i < accountList.Count-1 && isTrue; i++)
            {
                if (name == accountList.ElementAt(i).Name)
                {
                    currentUser = accountList.ElementAt(i);
                    isTrue = false;
                }
            }
        }

        public void withdraw(double money)
        {
            if (currentUser.Balance >= money)
            {
                currentUser.Balance -= money;
            }
            else
            {
                MessageBox.Show("Insufficient funds.");
            }
        }

        public double currentBalance()
        {
            return currentUser.Balance;
        }

        public void endSession()
        {
            currentUser = null;
            MessageBox.Show("Logged out.");
        }



    }
}
