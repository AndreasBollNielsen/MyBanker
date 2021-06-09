using System;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize array of cards
            Card[] cards = new Card[] { new Debit("Mikkel", "Debit"),
                new Maestro("Micheal", "Maestro"),
                new Visa_Electron("christian", "Visa Electron"),
                new Visa("Andreas", "Visa"),
                new Mastercard("Camilla", "Mastercard")};

          
            //GUI
            Console.WriteLine(("").PadRight(30, '-'));

            //loop through cards
            foreach (Card creditCard in cards)
            {
                //print out card info
                Console.WriteLine($"cardholder: {creditCard.CardHolder}" +
               $"\ncardNumber: {creditCard.CardNumber} " +
               $"\naccount: {creditCard.AccountNumber} " +
               $"\ncard type: {creditCard.CardType} ");

                //check if card inherits class
                if (creditCard is Expire)
                {
                    Console.WriteLine($"Expire Date: {((Expire)creditCard).ExpireDate.ToString("yy/MM")}");
                }

                Console.WriteLine("Card details:");
                Console.WriteLine(("").PadRight(15, '-'));

                //check if card implements interface
                if (creditCard is ICredit)
                {
                    //call interface method 
                    ((ICredit)creditCard).ShowCredit();
                }
                else
                {
                    ((IDebit)creditCard).CheckBalance();
                }

                Console.WriteLine(("").PadRight(30, '-'));
            }

        }
    }
}
