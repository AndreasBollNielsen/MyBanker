using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class Maestro: Expire, IDebit
    {
        private int[] prefixes;

        //properties
        public int[] Prefixes
        {
            get { return prefixes; }
            set { prefixes = value; }
        }

        //constructor for the class
        public Maestro(string _cardholder, string _cardType) : base(_cardholder, _cardType)
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
            this.Balance = 5000;
            Console.WriteLine("with this card, the user has to be 18 or over to qualify for this type of card.\n it can be used internationally or online");
            Console.WriteLine($"balance is: {this.Balance} kr");
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
