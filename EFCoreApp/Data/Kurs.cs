using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Kurs
    {
        [Key]
        public int Id { get; set; }

        public string? Baslik { get; set; }
    }
}
