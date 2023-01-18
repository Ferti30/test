using Biuro;

var agency = new Agency();
var random = new Random();
var distinctCountriess = agency.Trips.Select(t => t.Country).Distinct().ToList();
var distinctCategories = agency.Trips.Select(t => t.Category).Distinct().ToList();
int allInclusiveCount = 0;
var departureDate = new DateTime(2022, 06, 15);

List<int> numbers = new List<int>();
numbers.Add(7);
numbers.Add(10);
numbers.Add(14);

List<Trip> selectedTrips;
TripSelection tripSelection = new TripSelection();
selectedTrips = tripSelection.SelectRandomUniqueTrips(agency);

Console.WriteLine("DZISIEJSZE PROMOWANE OFERTY");
Console.WriteLine("--------------------------------");

selectedTrips = selectedTrips.OrderBy(x => x.Price).ToList();
foreach (Trip trip in selectedTrips)
{
    Console.WriteLine("NUMER: " + (selectedTrips.IndexOf(trip) + 1));
    Console.WriteLine("KRAJ: " + trip.Country);
    Console.WriteLine("TERMIN: " + departureDate.ToShortDateString() + " - " + departureDate.AddDays(numbers.ElementAt(selectedTrips.IndexOf(trip))).ToShortDateString() + " (" + numbers.ElementAt(selectedTrips.IndexOf(trip)) + ")");
    Console.WriteLine("HOTEL: " + trip.Hotel_Name + " (" + trip.Category + ")");
    Console.WriteLine("WYŻYWIENIE: " + trip.Food);
    Console.WriteLine("CENA: " + trip.Price);
    Console.WriteLine("--------------------------------");
}

int selectedId;
int selectedLength;
int adultNumber;
int childNumber;

while (true)
{
    Console.WriteLine("PROSZĘ PODAĆ NUMER WYBRANEJ OFERTY:");
    string offerInput = Console.ReadLine();
    if (int.TryParse(offerInput, out int offerNumber) && (offerNumber >= 1 && offerNumber <= 3))
    {
        selectedLength = numbers.ElementAt(offerNumber - 1);
        selectedId = selectedTrips[offerNumber - 1].Id;
        Console.Clear();
        break;
    }
    else
    {
        Console.WriteLine("NIEPOPRAWNY NUMER, SPRÓBUJ JESZCZE RAZ");
    }
}

while (true)
{
    Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ OSÓB DOROSŁYCH:");
    string adultInput = Console.ReadLine();
    if (int.TryParse(adultInput, out adultNumber) && adultNumber > 0)
    {
        Console.Clear();
        break;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("NIEPOPRAWNA ILOŚĆ, SPRÓBUJ JESZCZE RAZ");
    }
}

while (true)
{
    Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ DZIECI:");
    string childInput = Console.ReadLine();
    if (int.TryParse(childInput, out childNumber))
    {
        Console.Clear();
        break;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("NIEPOPRAWNA ILOŚĆ, SPRÓBUJ JESZCZE RAZ");
    }
}

var selectedTrip = agency.Trips.FirstOrDefault(x => x.Id == selectedId);


TotalPrice calculator = new TotalPrice();
decimal totalPrice = calculator.CalculateTotalPrice(selectedTrip, selectedLength, adultNumber, childNumber);
Console.WriteLine("CAŁKOWITA CENA WAKACJI WYNOSI: " + totalPrice + " PLN");
string end = Console.ReadLine();
