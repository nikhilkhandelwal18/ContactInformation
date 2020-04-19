using Microsoft.EntityFrameworkCore;

namespace ContactInformationService.Models.EFCore
{
    public class MyMDBContext : DbContext
    {
        public MyMDBContext (DbContextOptions<MyMDBContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Contact>().HasData(
                new Contact() {Id=1, FirstName = "Mary", LastName = "Thomas", Email = "mary.t@test.com", PhoneNumber = "9826098260", Status = true },
                new Contact() {Id=2, FirstName = "John", LastName = "Kindom", Email = "john.k@test.com", PhoneNumber = "9826098260", Status = true },
                new Contact() {Id=3, FirstName = "Sam", LastName = "Willier", Email = "sam.w@test.com", PhoneNumber = "9826098260", Status = true }
                );


        }
    }
}
