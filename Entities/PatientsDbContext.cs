
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.IdentityEntity;


namespace Entities
{
    public class PatientsDbContext: IdentityDbContext<User,Role,Guid>
    {
        public PatientsDbContext(DbContextOptions options) : base(options) 
        { 
        }



        public DbSet<Country> Countries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            
            string contriesJson = System.IO.File.ReadAllText("countries.json");
           List<Country>? countriesList = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(contriesJson);
            if (countriesList != null)
            {
                foreach (Country countrys in countriesList)
                {
                    modelBuilder.Entity<Country>().HasData(countrys);
                }
            }

            string patientJson = System.IO.File.ReadAllText("patients.json");
            List<Patient>? patientsList = System.Text.Json.JsonSerializer.Deserialize<List<Patient>>(patientJson);

            if (patientsList != null)
            {
                foreach (Patient patient in patientsList)
                {
                    modelBuilder.Entity<Patient>().HasData(patient);
                }
            }


        }
    }
}
