using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public abstract class Card
    {
        //attributes
        private string cardNumber;
        private string cardHolder;
        private string accountNumber;
        private int prefix;
        private double balance;
        private double maxWithdraw;
        private string cardType;
        
        //properties
        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public double MaxWithdraw
        {
            get { return maxWithdraw; }
            set { maxWithdraw = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public int Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string CardHolder
        {
            get { return cardHolder; }
            set { cardHolder = value; }
        }

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
       
        //constructor
        public Card(string cardHolder, string cardType)
        {
            this.cardHolder = cardHolder;
            this.cardType = cardType;
        }

        //set prefix and card number
        public void InitializeCard()
        {
            //generate random account number
            string account = "3520-";
            Random rand = new Random();

            //add random numbers to account
            for (int i = 0; i < 10; i++)
            {
                account += rand.Next(0, 10).ToString();
            }
            accountNumber = account;

            //set card number
            CardNumber = prefix.ToString() + " ";
            int length = 0;
            int seperator = 0;
            //set numbers of digits
            if (cardType != "Maestro")
            {
                length = 16 - prefix.ToString().Length;
                seperator = 3;
            }
            else
            {
                length = 19 - prefix.ToString().Length;
                seperator = 2;
            }

            
            //generate the card number
            for (int i = 0; i < length; i++)
            {
                CardNumber += rand.Next(0, 10).ToString();

                if (i % 5 == 0 )
                {
                    cardNumber += " ";
                    length++;
                }
            }



        }

        // generate card prefix
        public void SetPrefix(int[] prefixes)
        {
            Random rand = new Random();
            int randIndex = rand.Next(0, prefixes.Length);

            this.Prefix = prefixes[randIndex];
        }

    }
}
