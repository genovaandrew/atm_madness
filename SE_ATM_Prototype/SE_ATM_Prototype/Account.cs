using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE_ATM_Prototype
{
    public class Account
    {
        private String name;
        private int acctno;
        private int pinno;
        private double balance;

        public Account(String name, int acctno, int pinno, double balance)
        {
            this.name = name;
            this.acctno = acctno;
            this.pinno = pinno;
            this.balance = balance;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Acctno
        {
            get { return acctno; }
            set { acctno = value; }
        }

        public int Pinno
        {
            get { return pinno; }
            set { pinno = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}
