using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int Id { get; set; }

        public string? ogretmenAd { get; set; }
        public string? ogretmenSoyd { get; set; }

        public string ogretmenAdSoyad
        {
            get


            {
                return this.ogretmenAd + " " + this.ogretmenSoyd;
            }
        }

        public string? ogretmenMail { get; set; }
        public string? ogretmenTel { get; set; }

        //bir öğretmenin bir çok kursu olabilir
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
        [DataType(DataType.Date)] //sadece tarih saat yok
        public DateTime BaslamaTarihi { get; set; }


    }
}
