
using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.Dto
{
    public class PatientResponse
    {
        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? PresentDoorNo { get; set; }
        public string? PresentStreetName { get; set; }
        public string? PresentVillageTown { get; set; }
        public string? PresentPostOffice { get; set; }
        public string? PresentTaluk { get; set; }
        public string? PresentState { get; set; }
        public string? PresentDistrict { get; set; }
        public long? PresentPincode { get; set; }
        public string? PermanentDoorNo { get; set; }
        public string? PermanentStreetName { get; set; }
        public string? PermanentVillageTown { get; set; }
        public string? PermanentPostOffice { get; set; }
        public string? PermanentTaluk { get; set; }
        public string? PermanentState { get; set; }
        public string? PermanentDistrict { get; set; }
        public long? PermanentPincode { get; set; }
        public long? Phone { get; set; }
        public string? Occupation { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? GuardianName { get; set; }
        public long? GuardianPhoneNumber { get; set; }
        public string? Religion { get; set; }
        public string? Title { get; set; }
        public string? MaritalStatus { get; set; }
        public double? Age { get; set; }
        public string? CountryName { get; set; }
        public string? GurdainOccupation { get; set; }
        public string? Gurdain { get; set; }
        public string? Detailedinfo { get; set; }
        public long? Aadhar { get; set; }
        public string? PermanentCountry {  get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;


            


            PatientResponse other = (PatientResponse)obj;
            return PatientId == other.PatientId &&
                   PatientName == other.PatientName &&
                   Email == other.Email &&
                   DateOfBirth == other.DateOfBirth &&
                   Gender == other.Gender &&
                   CountryID == other.CountryID &&
                   PresentDoorNo == other.PresentDoorNo &&
                   PresentStreetName == other.PresentStreetName &&
                   PresentVillageTown == other.PresentVillageTown &&
                   PresentPostOffice == other.PresentPostOffice &&
                   PresentTaluk == other.PresentTaluk &&
                   PresentState == other.PresentState &&
                   PresentDistrict == other.PresentDistrict &&
                   PresentPincode == other.PresentPincode &&
                   PermanentDoorNo == other.PermanentDoorNo &&
                   PermanentStreetName == other.PermanentStreetName &&
                   PermanentVillageTown == other.PermanentVillageTown &&
                   PermanentPostOffice == other.PermanentPostOffice &&
                   PermanentTaluk == other.PermanentTaluk &&
                   PermanentState == other.PermanentState &&
                   PermanentDistrict == other.PermanentDistrict &&
                   PermanentPincode == other.PermanentPincode &&
                   Phone == other.Phone &&
                   Occupation == other.Occupation &&
                   FatherName == other.FatherName &&
                   MotherName == other.MotherName &&
                   GuardianName == other.GuardianName &&
                   GuardianPhoneNumber == other.GuardianPhoneNumber &&
                   Religion == other.Religion &&
                   Title == other.Title &&
                   MaritalStatus == other.MaritalStatus &&
                   GurdainOccupation == other.GurdainOccupation &&
                   Gurdain == other.Gurdain &&
                   Detailedinfo == other.Detailedinfo &&
                   Aadhar == other.Aadhar &&
                   PermanentCountry == other.PermanentCountry;


        }

        

        public override string ToString()
        {
            return $"PatientId: {PatientId}, PatientName: {PatientName}, Email: {Email}, DateOfBirth: {DateOfBirth?.ToString("yyyy-MM-dd")}, " +
                   $"Gender: {Gender}, CountryId: {CountryID}, PresentAddress: {PresentDoorNo} {PresentStreetName}, " +
                   $"{PresentVillageTown}, {PresentPostOffice}, {PresentTaluk}, {PresentState}, {PresentDistrict}, {PresentPincode}, " +
                   $"PermanentAddress: {PermanentDoorNo} {PermanentStreetName}, {PermanentVillageTown}, {PermanentPostOffice}, " +
                   $"{PermanentTaluk}, {PermanentState}, {PermanentDistrict}, {PermanentPincode}, Phone: {Phone}, " +
                   $"Occupation: {Occupation}, FatherName: {FatherName}, MotherName: {MotherName}, GuardianName: {GuardianName}, " +
                   $"GuardianPhoneNumber: {GuardianPhoneNumber}, Religion: {Religion}, Title: {Title}, MaritalStatus: {MaritalStatus}, CountryName: { CountryName}" +
                   $"GurdainOccupation:{GurdainOccupation},Gurdain:{Gurdain}, Aadhar:{Aadhar}, Detailedinfo:{Detailedinfo},PermanentCountry: { PermanentCountry}";
        }

        public PatientUpdateRequest ToPatientUpdateRequest()
        {


            return new PatientUpdateRequest()
            {
                PatientId = PatientId,
                PatientName = PatientName,
                Email = Email,
                DateOfBirth = DateOfBirth,
               
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                CountryID = CountryID,
                PresentDoorNo = PresentDoorNo,
                PresentStreetName = PresentStreetName,
                PresentVillageTown = PresentVillageTown,
                PresentPostOffice = PresentPostOffice,
                PresentTaluk = PresentTaluk,
                PresentState = (States)Enum.Parse(typeof(States), PresentState, true),
                PresentDistrict = PresentDistrict,
                PresentPincode = PresentPincode,
                PermanentDoorNo = PermanentDoorNo,
                PermanentStreetName = PermanentStreetName,
                PermanentVillageTown = PermanentVillageTown,
                PermanentPostOffice = PermanentPostOffice,
                PermanentTaluk = PermanentTaluk,
                PermanentState = (States)Enum.Parse(typeof(States), PermanentState, true),
                PermanentDistrict = PermanentDistrict,
                PermanentPincode = PermanentPincode,
                Phone = Phone,
                Occupation = Occupation,
                FatherName = FatherName,
                MotherName = MotherName,
                GuardianName = GuardianName,
                GuardianPhoneNumber = GuardianPhoneNumber,
                
                Religion = (ReligionOptions)Enum.Parse(typeof(ReligionOptions), Religion, true),
                
                Title = (TitleOptions)Enum.Parse(typeof(TitleOptions), Title, true),

                MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), MaritalStatus, true),
                GurdainOccupation = GurdainOccupation ,
                   Gurdain = (GuardianType)Enum.Parse(typeof(GuardianType), Gurdain, true),
                PermanentCountry = PermanentCountry,
                   Detailedinfo = Detailedinfo, 
                   Aadhar = Aadhar


        };
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }



    public static class PatientExtensions
    {
        public static PatientResponse ToPatientResponse(this Patient patient)
        {
            return new PatientResponse()
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Email = patient.Email,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                CountryID = patient.CountryID,
                PresentDoorNo = patient.PresentDoorNo,
                PresentStreetName = patient.PresentStreetName,
                PresentVillageTown = patient.PresentVillageTown,
                PresentPostOffice = patient.PresentPostOffice,
                PresentTaluk = patient.PresentTaluk,
                PresentState = patient.PresentState,
                PresentDistrict = patient.PresentDistrict,
                PresentPincode = patient.PresentPincode,
                PermanentDoorNo = patient.PermanentDoorNo,
                PermanentStreetName = patient.PermanentStreetName,
                PermanentVillageTown = patient.PermanentVillageTown,
                PermanentPostOffice = patient.PermanentPostOffice,
                PermanentTaluk = patient.PermanentTaluk,
                PermanentState = patient.PermanentState,
                PermanentDistrict = patient.PermanentDistrict,
                PermanentPincode = patient.PermanentPincode,
                Phone = patient.Phone,
                Occupation = patient.Occupation,
                FatherName = patient.FatherName,
                MotherName = patient.MotherName,
                GuardianName = patient.GuardianName,
                GuardianPhoneNumber = patient.GuardianPhoneNumber,
                Religion = patient.Religion,
                Title = patient.Title,
                MaritalStatus = patient.MaritalStatus,
                Age = (patient.DateOfBirth != null) ? Math.Round((DateTime.Now - patient.DateOfBirth.Value).TotalDays / 365.25) : null,
                GurdainOccupation =patient.GurdainOccupation,
                Gurdain = patient.Gurdain,
                Detailedinfo = patient.Detailedinfo,
                Aadhar = patient.Aadhar,
                PermanentCountry = patient.PermanentCountry


            };
        }
    }



}
