using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    class Expire : Card
    {
        private DateTime expireDate;

        //constructor
        public Expire(string _cardHolder, string _cardType) : base(_cardHolder, _cardType)
        {
            this.CardHolder = _cardHolder;
            this.CardType = _cardType;
        }

        //set property
        public DateTime ExpireDate
        {
            get { return expireDate; }
            set { expireDate = value; }
        }

        //set expiration date
        public void SetExpireDate()
        {
            //set expiration date to 5 years
            DateTime currentDate = DateTime.Now;
            if (CardType == "Visa" || CardType == "Visa Electron" || CardType == "Mastercard")
            {
                DateTime ExpireDate = currentDate.AddYears(5);
                this.ExpireDate = ExpireDate;
            }
            //set expiration date to 5 years and 8 months
            else if (CardType == "Maestro")
            {
                DateTime ExpireDate = currentDate.AddYears(5);
                ExpireDate = ExpireDate.AddMonths(8);
                this.ExpireDate = ExpireDate;
            }
        }

    }
}
