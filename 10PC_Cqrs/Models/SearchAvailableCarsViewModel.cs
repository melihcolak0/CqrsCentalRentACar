using _10PC_Cqrs.CQRSPattern.Results.CarResults;

namespace _10PC_Cqrs.Models
{
    public class SearchAvailableCarsViewModel
    {
        public int SelectedCarId { get; set; }
        public string CarModel { get; set; }          // opsiyonel filtre
        public string PickUpLocation { get; set; }    // havalimanı ya da şehir
        public string DropOffLocation { get; set; }   // havalimanı ya da şehir
        public DateTime StartDate { get; set; }       // kiralama başlangıç
        public DateTime EndDate { get; set; }         // kiralama bitiş

        // Uygun arabalar listelenecek
        public List<GetCarQueryResult> AvailableCars { get; set; } = new List<GetCarQueryResult>();
    }
}
