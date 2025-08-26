using _10PC_Cqrs.CQRSPattern.Commands.MessageCommands;
using _10PC_Cqrs.CQRSPattern.Results.SliderResults;

namespace _10PC_Cqrs.Models
{
    public class HomePageViewModel
    {
        public List<GetSliderQueryResult> Sliders { get; set; }
        public CreateMessageCommand Message { get; set; }
        public SearchAvailableCarsViewModel CarSearch { get; set; }

        // Yeni alanlar
        public double? FuelPricePer100Km { get; set; } // TL cinsinden 100 km maliyeti
        public double? Distance { get; set; } // km
        public double? TotalFuelCost { get; set; } // TL
    }
}
