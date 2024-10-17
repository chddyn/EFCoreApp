using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }

        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }

        public string AdSoyad
        {

            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyad;
            }

        }

        public string? Eposta { get; set; }
        public string? Telefon { get; set; }


        public ICollection<KursKayit> kursKayitlari { get; set; } = new List<KursKayit>();

    }
}
