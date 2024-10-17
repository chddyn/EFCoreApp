using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Kurs> Kurslar { get; set; } = null!;
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>(); // yukardaki notnull ile aynı görevi görür
        public DbSet<KursKayit> KursKayitlari { get; set; } = null!;
        public DbSet<Ogretmen> Ogretmenler { get; set; } = null!;

    }
}
