using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class Visa : Expire, ICredit
    {
        private int[] prefixes;

        //properties
        public int[] Prefixes
        {
            get { return prefixes; }
            set { prefixes = value; }
        }

        //constructor for the class
        public Visa(string _cardholder, string _cardType) : base(_cardholder, _cardType)
        {
            this.CardHolder = _cardholder;
            this.CardType = _cardType;
            SetExpireDate();
            InitializePrefix();
            InitializeCard();
        }

        //show the credit on the card 
        public void ShowCredit()
        {
            this.MaxWithdraw = 20000;
            this.Balance = 15000;
            Console.WriteLine("this credit card overdraft is 25.000 kr");
            Console.WriteLine($"balance is: {this.Balance} kr");
            Console.WriteLine($"max withdraw is: {this.MaxWithdraw}");
        }

        //initialize prefix
        void InitializePrefix()
        {
            if (CardType == "Visa Electron")
            {
                prefixes = new int[] { 4026, 417500, 4508, 4844, 4913, 4917 };
            }
            else if (CardType == "Visa")
            {
                prefixes = new int[] { 4 };
            }
            else if (CardType == "Mastercard")
            {
                prefixes = new int[] { 51, 52, 53, 54, 55 };
            }
            else if (CardType == "Maestro")
            {
                prefixes = new int[] { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 };
            }
            else if (CardType == "Debit")
            {
                prefixes = new int[] { 2400 };
            }

            this.SetPrefix(prefixes);
        }

    }
}
