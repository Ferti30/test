using System;
using System.Collections.Generic;
using System.Linq;

namespace Biuro
{
    public class TripSelection
    {
        public List<Trip> SelectRandomUniqueTrips(Agency agency)
        {
            Random random = new Random();
            var distinctCountries = agency.Trips.Select(t => t.Country).Distinct().ToList();
            var distinctCategories = agency.Trips.Select(t => t.Category).Distinct().ToList();
            int allInclusiveCount = 0;
            var departureDate = new DateTime(2022, 06, 15);

            var randomUniqueTrips = new List<Trip>();
            while (randomUniqueTrips.Count < 3)
            {
                var randomCountry = distinctCountries[random.Next(distinctCountries.Count)];
                var randomCategory = distinctCategories[random.Next(distinctCategories.Count)];
                var trip = agency.Trips.FirstOrDefault();
                if (allInclusiveCount <= 1)
                {
                    trip = agency.Trips.FirstOrDefault(t => t.Country == randomCountry && t.Category == randomCategory && t.Food == "All Inclusive");
                }
                else
                {
                    trip = agency.Trips.FirstOrDefault(t => t.Country == randomCountry && t.Category == randomCategory);
                }
                if (trip != null)
                {
                    randomUniqueTrips.Add(trip);
                    distinctCountries.Remove(randomCountry);
                    distinctCategories.Remove(randomCategory);
                    allInclusiveCount++;
                }
            }
            return randomUniqueTrips;
        }
    }
}