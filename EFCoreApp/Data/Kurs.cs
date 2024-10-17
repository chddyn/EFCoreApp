using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Kurs
    {
        [Key]
        public int Id { get; set; }

        public string? Baslik { get; set; }

        public int ogretmenId { get; set; }
        //bir kursun bir öğretmeni olabilir
        public Ogretmen Ogretmen { get; set; } = null!;

        // bu şekilde kurs kayıtlara erişiriz orda ki join işlemleri sayesinde ilişkiler kurarız
        //bir kursa bir çok kayıt olabilir
        public ICollection<KursKayit> kursKayitlari { get; set; } = new List<KursKayit>();

    }
}
