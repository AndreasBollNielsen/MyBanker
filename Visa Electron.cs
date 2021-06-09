using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class Visa_Electron: Expire, IDebit
    {
        private int[] prefixes;

        //properties
        public int[] Prefixes
        {
            get { return prefixes; }
            set { prefixes = value; }
        }

        //constructor for the class
        public Visa_Electron(string _cardholder, string _cardType) : base(_cardholder, _cardType)
        {
            this.CardHolder = _cardholder;
            this.CardType = _cardType;
            this.SetExpireDate();
            this.InitializePrefix();
            this.InitializeCard();


        }

        //show the credit on the card 
        public void ShowCardinfo()
        {
            MaxWithdraw = 10000;
            Balance = 8000;
            Console.WriteLine($"this debit card can be used online or internationally.\n using this card the user can only spend up to {this.MaxWithdraw} kr each month");
            Console.WriteLine($"balance is: {Balance} kr");
            Console.WriteLine($"max withdraw is: {MaxWithdraw}");
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
