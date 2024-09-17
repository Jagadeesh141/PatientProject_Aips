using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Patient
    {
        [Key]
        public string? PatientId { get; set; }

        [StringLength(50)]
        public string? PatientName { get; set;}
       
        [StringLength(30)]
        
        public  string? Email { get; set;}
        public DateTime? DateOfBirth { get; set;}
        [StringLength(10)]
        public string? Gender { get; set;}
        public Guid? CountryID { get; set;}
        [StringLength(100)]
       //present address
        public string? PresentDoorNo { get; set; }
        [StringLength(100)]
        public string? PresentStreetName { get; set; }
        [StringLength(100)]
        public string? PresentVillageTown { get; set; }
        [StringLength(100)]
        public string? PresentPostOffice { get; set; }
        [StringLength(100)]
        public string? PresentTaluk { get; set; }
        [StringLength(100)]
        public string? PresentState { get; set; }
        [StringLength(100)]
        public string? PresentDistrict { get; set; }
        [StringLength(100)]
        public long? PresentPincode { get; set; }
        //pernment address
        [StringLength(100)]
        public string? PermanentDoorNo { get; set; }
        [StringLength(100)]
        public string? PermanentStreetName { get; set; }
        [StringLength(100)]
        public string? PermanentVillageTown { get; set; }
        [StringLength(100)]
        public string? PermanentPostOffice { get; set; }
        [StringLength(100)]
        public string? PermanentTaluk { get; set; }
        [StringLength(100)]
        public string? PermanentState { get; set; }
        [StringLength(100)]
        public string? PermanentDistrict { get; set; }
        [StringLength(100)]
        public long? PermanentPincode { get; set; }

        public long ? Phone {  get; set;}


        public string ? GurdainOccupation { get; set; }
        public string ? Gurdain {  get; set; }
         public string? Detailedinfo { get; set; }
        public long ? Aadhar {  get; set; }

        
        

        public string? Occupation { get; set; } 
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }

        [StringLength(50)]
        public string? GuardianName { get; set; }
        public long? GuardianPhoneNumber { get; set; }

        public string? Religion {  get; set; }
        public string? Title { get; set; }
        public string? MaritalStatus { get; set; }
        public virtual Country? CountryName { get; set; }
        public string? PermanentCountry {  get; set; }
    }
}
