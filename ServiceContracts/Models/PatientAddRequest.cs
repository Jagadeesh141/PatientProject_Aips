
using ServiceContracts.Enums;
using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Dto
{
    public class PatientAddRequest
    {
        [Required(ErrorMessage = "Patient Name can't be empty")]
        public string? PatientName { get; set; }

        [Required(ErrorMessage = "Email Can't be blank")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [CustomValidation(typeof(PatientAddRequest), "ValidateDateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public GenderOptions? Gender { get; set; } 

        public Guid? CountryID { get; set; }

        // Present Address
        [Required(ErrorMessage = "Present Door No. is required")]
        [RegularExpression(@"^[#]?\d+$", ErrorMessage = " Door No. must be a number")]
        public string? PresentDoorNo { get; set; }
        [Required(ErrorMessage = " StreetName. is required")]
        public string? PresentStreetName { get; set; }
        [Required(ErrorMessage = " Village/Town. is required")]
        public string? PresentVillageTown { get; set; }
        
        public string? PresentPostOffice { get; set; }
        
        public string? PresentTaluk { get; set; }
        [Required(ErrorMessage = "Present State is required")]
        public States? PresentState { get; set; }
        public string? PresentDistrict { get; set; }
        [Required(ErrorMessage = "Present Pincode is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "must be a 6-digit number")]
        public long? PresentPincode { get; set; }

        // Permanent Address
        [RegularExpression(@"^[#]?\d+$", ErrorMessage = " Door No. must be a number")]
        [Required(ErrorMessage = "Present Door No. is required")]
        public string? PermanentDoorNo { get; set; }
        [Required(ErrorMessage = "Present StreetName. is required")]
        public string? PermanentStreetName { get; set; }
        [Required(ErrorMessage = "Present Village/Town. is required")]
        public string? PermanentVillageTown { get; set; }
        public string? PermanentPostOffice { get; set; }
        public string? PermanentTaluk { get; set; }
        [Required(ErrorMessage = "Present State is required")]
        public States? PermanentState { get; set; }
        public string? PermanentDistrict { get; set; }
        
        [RegularExpression(@"^\d{6}$", ErrorMessage = " must be a 6-digits")]
        [Required(ErrorMessage = "Present Pincode is required")]
        public long? PermanentPincode { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "  must be a 10-digits")]
        public long? Phone { get; set; }

 
        public string? Occupation { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        [Required(ErrorMessage = "GuardianName. is required")]
        public string? GuardianName { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = " must be a 10-digits")]
        [Required(ErrorMessage = "GuardianPhoneNumber. is required")]
        public long? GuardianPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select Religion")]
        public ReligionOptions? Religion { get; set; }
        [Required(ErrorMessage = "Please Select  Title")]
        public TitleOptions? Title { get; set; }
        [Required(ErrorMessage = "Marital Status is required")]
        public MaritalStatus? MaritalStatus { get; set; }


        public string? GurdainOccupation { get; set; }
        [Required(ErrorMessage = "GuardianType is required")]
        public GuardianType? Gurdain { get; set; }
        public string? Detailedinfo { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = " must be a 12-digits")]
        public long? Aadhar { get; set; }
        public String? PermanentCountry { get; set; }



        public Patient ToPatient()
        {
            return new Patient()
            {
                PatientName = PatientName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                
                PresentDoorNo = PresentDoorNo,
                PresentStreetName = PresentStreetName,
                PresentVillageTown = PresentVillageTown,
                PresentPostOffice = PresentPostOffice,
                PresentTaluk = PresentTaluk,
                PresentState = PresentState.ToString(),
                PresentDistrict = PresentDistrict,
                PresentPincode = PresentPincode,
               
                PermanentDoorNo = PermanentDoorNo,
                PermanentStreetName = PermanentStreetName,
                PermanentVillageTown = PermanentVillageTown,
                PermanentPostOffice = PermanentPostOffice,
                PermanentTaluk = PermanentTaluk,
                PermanentState = PermanentState.ToString(),
                PermanentDistrict = PermanentDistrict,
                PermanentPincode = PermanentPincode,
                Phone = Phone,
                Occupation = Occupation,
                FatherName = FatherName,
                MotherName = MotherName,
                GuardianName = GuardianName,
                GuardianPhoneNumber = GuardianPhoneNumber,
                Religion = Religion.ToString(),
                Title = Title.ToString(),
                MaritalStatus = MaritalStatus.ToString(),
                GurdainOccupation = GurdainOccupation,
                Gurdain = Gurdain.ToString(),
                Detailedinfo = Detailedinfo,
                Aadhar = Aadhar,
                PermanentCountry = PermanentCountry,




            };
        }

        public static ValidationResult? ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext? context)
        {
            if (dateOfBirth.Date >= DateTime.Today)
            {
                string memberName = context?.MemberName ?? string.Empty;
                return new ValidationResult("Date of Birth cannot be in the future.", new[] { memberName });
            }

            if (dateOfBirth.Year <= 1920)
            {
                string memberName = context?.MemberName ?? string.Empty;
                return new ValidationResult("Date of Birth should be after 1920.", new[] { memberName });
            }

            return ValidationResult.Success;
        }

    }
}
