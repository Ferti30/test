using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Biuro
{
    public class Agency
    {
        public List<Trip> Trips { get; set; }
        public Trip CurrentQuestion { get; set; }

        public Agency()
        {
            CreateAllTrips();
        }
        public void CreateAllTrips()
        {
            var path = Directory.GetCurrentDirectory() + "\\trips_list.json";
            var text = File.ReadAllText(path);
            Trips = JsonConvert.DeserializeObject<List<Trip>>(text);
        }
        
    }

    public class Trip
    {
        public int Id { get; set; }
        public string Hotel_Name { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string Category { get; set; }
        public string Food { get; set; }
        public decimal Price { get; set; }
    }


}
