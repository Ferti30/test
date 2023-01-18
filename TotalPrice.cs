using Biuro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biuro
{
    public class TotalPrice
    {
        public decimal CalculateTotalPrice(Trip selectedTrip, int selectedLength, int adultNumber, int childNumber)
        {
            decimal allInclusivePrice = 0;
            if (selectedTrip.Food == "All Inclusive")
            {
                allInclusivePrice = 1200;
            }

            decimal continentPrice = 0;
            switch (selectedTrip.Continent)
            {
                case "Azja":
                    continentPrice = 2000;
                    break;
                case "Europa":
                    continentPrice = 1000;
                    break;
                case "Ameryka":
                    continentPrice = 2500;
                    break;
                case "Afryka":
                    continentPrice = 1500;
                    break;
            }
            decimal adultHotelPrice = (selectedTrip.Price * selectedLength + allInclusivePrice + continentPrice) * adultNumber;
            decimal childHotelPrice = (selectedTrip.Price * selectedLength + allInclusivePrice + continentPrice) * childNumber / 2;
            decimal totalPrice = adultHotelPrice + childHotelPrice;
            return totalPrice;
        }
    }
}
