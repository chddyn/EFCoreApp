using EFCoreApp.Data;
using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Models
{
    public class KursViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Baslik { get; set; }

        public int ogretmenId { get; set; }


        public ICollection<KursKayit> kursKayitlari { get; set; } = new List<KursKayit>();

        // buradaki amaç post edilirken modeldeki istemediğimiz alanları postta isvalid olmasın diye sadeleştirmek
        //daha sonra posta model olarak göndermek



    }
}
