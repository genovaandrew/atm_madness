using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE_ATM_Prototype
{
    /*
     * 
     * This bank class essentially just acts as a back end of the ATM machine itself. In our demo we use it
     * for the bank, but if this were to be implemented in reality, the bank class would really just send
     * instructions to a router to send things to the actual bank for verification. Adding this change would
     * be fairly minor. 
     * 
     * Encryption algorithm would go in this class to send the requests off. 
     * 
     */
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

        public Account CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
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

        public Boolean startSession(String name, int pin)
        {
            Boolean isTrue = true; // value that is true if name is not in list of accounts
            for (int i = 0; i < accountList.Count && isTrue; i++)
            {
                if (name == accountList.ElementAt(i).Name)
                {
                    currentUser = accountList.ElementAt(i);
                    isTrue = false;
                }
            }

            if (isTrue) //If the name is not in list of accounts, return false
            {
                return false;
            }
            else if (currentUser.Pinno == pin) //Otherwise, if name is in list, check if the given pin works, if so return true
            {
                return true;
            }
            else // if the given pin doesnt work, don't start a session and return false
            {
                currentUser = null;
                return false;
            }
            
        }

        public Boolean withdraw(double money)
        {
            if (currentUser.Balance >= money)
            {
                currentUser.Balance -= money;
                return true;
            }
            else
            {
                MessageBox.Show("Insufficient funds.");
                return false;
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

        /*
         * This method is used to perform OTP encryption on a string before sending it over the network
         * 
         * 
         */
        public String encryptOTP(String input)
        {
            byte[] originalBytes;
            byte[] keyBytes;
            byte[] outBytes;
            String plaintext = input;
            String ciphertext = plaintext;
            originalBytes = new byte[input.Length* sizeof(char)];
            System.Buffer.BlockCopy(plaintext.ToCharArray(), 0, originalBytes, 0, originalBytes.Length);
            keyBytes = new byte[originalBytes.Length];
            outBytes = new byte[originalBytes.Length];
            Random random = new Random();
            random.NextBytes(keyBytes);
            for (int i = 0; i < originalBytes.Length; i++)
            {
                outBytes[i] = (byte)(originalBytes[i] ^ keyBytes[i]);
            }

            char[] chars = new char[outBytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(outBytes, 0, chars, 0, outBytes.Length);
            ciphertext = outBytes.ToString();
            return ciphertext;
        }



    }
}
