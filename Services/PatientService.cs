
using Entities;
using ServiceContracts;
using ServiceContracts.Dto;
using Services.Helpers;
using ServiceContracts.Enums;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly PatientsDbContext _db;
        private readonly ICountriesService _countriesService;

        public PatientService(PatientsDbContext patientsDbContext, ICountriesService countriesService )
        {
            _db = patientsDbContext ;
            _countriesService = countriesService;
           
                
        }
        private PatientResponse ConvertPatientTOPatientResponse(Patient patient)
        {
            PatientResponse response = patient.ToPatientResponse();
            response.CountryName = _countriesService.GetCountryByCountryID(patient.CountryID)?.CountryName;
            return response;
        }

        private string GenerateUniquePatientId()
        {
            string newId;
            do
            {
                newId = Guid.NewGuid().ToString().Substring(0, 5);
            } while (_db.Patients.Any(p => p.PatientId.StartsWith(newId)));

            return newId;
        }



        public PatientResponse AddPatient(PatientAddRequest? patientAddRequest)
        {

            //check if PatientAddRequest is not null
            if (patientAddRequest == null)
            {
                throw new ArgumentNullException(nameof(patientAddRequest));
            }
            if (string.IsNullOrEmpty(patientAddRequest.PatientName))
            {
                throw new ArgumentException("Patient name can't be null");
            }
            ValidationHelpers.ModelValadition(patientAddRequest);

            //convert patientAddRequest into patient type
            Patient patient = patientAddRequest.ToPatient();

            //generate new patientid
            //patient.PatientId = Guid.NewGuid();
            string uniquePatientId = GenerateUniquePatientId();
            patient.PatientId = uniquePatientId;


            //add patient obj to patient List
            _db.Patients.Add(patient);
            _db.SaveChanges();


            //convert the patient obj into patientresponse type
            return ConvertPatientTOPatientResponse(patient);




        }

        public List<PatientResponse> GetAllPatient()
        {
            //select * from Patients
            return _db.Patients.ToList().Select(temp => ConvertPatientTOPatientResponse(temp)).ToList();
        }

        public PatientResponse? GetPatientByPatientId(string? patientId)
        {
            if (patientId == null)
            {
                return null;

            }
            Patient? patient = _db.Patients.FirstOrDefault(p =>
            p.PatientId == patientId);
            if (patient == null)
                return null;

            return ConvertPatientTOPatientResponse(patient);

        }

        public List<PatientResponse> GetFilteredPatient(string searchBy, string? searchString)
        {
            List<PatientResponse> allPatients = GetAllPatient();
            List<PatientResponse> matchingPatients = allPatients;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return matchingPatients;
            }

            switch (searchBy)
            {
                case nameof(PatientResponse.PatientId):
                    matchingPatients = allPatients.Where(temp =>
                    (!string.IsNullOrEmpty(temp.PatientId) ?
                    temp.PatientId.Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PatientResponse.PatientName):
                    matchingPatients = allPatients.Where(temp =>
                    (!string.IsNullOrEmpty(temp.PatientName) ?
                    temp.PatientName.Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PatientResponse.Email):
                    matchingPatients = allPatients.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Email) ?
                    temp.Email.Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PatientResponse.DateOfBirth):
                    matchingPatients = allPatients.Where(temp =>
                    (temp.DateOfBirth != null) ?
                    temp.DateOfBirth.Value.ToString("dd-mm-yyyy").Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PatientResponse.Gender):
                    matchingPatients = allPatients.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Gender) ?
                    temp.Gender.Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PatientResponse.CountryID):
                    matchingPatients = allPatients.Where(temp =>
                    (!string.IsNullOrEmpty(temp.CountryName) ?
                    temp.CountryName.Contains(searchString,
                    StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

            

                default: matchingPatients = allPatients; break;
            }
            return matchingPatients;
        }

        public List<PatientResponse> GetSortedPatients(List<PatientResponse> allPatients, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allPatients;

            List<PatientResponse> storedPatients = (sortBy, sortOrder)
            switch
            {
                (nameof(PatientResponse.PatientId), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.PatientId,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.PatientId), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.PatientId,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.PatientName), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.PatientName,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.PatientName), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.PatientName,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.Email), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.Email,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.Email), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.Email,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.DateOfBirth), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.DateOfBirth
                ).ToList(),

                (nameof(PatientResponse.DateOfBirth), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.DateOfBirth
                ).ToList(),

                (nameof(PatientResponse.Age), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.Age).ToList(),

                (nameof(PatientResponse.Age), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PatientResponse.Gender), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.Gender,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.Gender), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.Gender,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.CountryName), SortOrderOptions.ASC)
                => allPatients.OrderBy(temp => temp.CountryName,
                StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PatientResponse.CountryName), SortOrderOptions.DESC)
                => allPatients.OrderByDescending(temp => temp.CountryName,
                StringComparer.OrdinalIgnoreCase).ToList(),

                _ => allPatients
            };

            return storedPatients;

        }

        public PatientResponse UpdatePatient(PatientUpdateRequest? patientUpdateRequest)
        {
            if (patientUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(patientUpdateRequest));
            }

            ValidationHelpers.ModelValadition(patientUpdateRequest);

            Patient? matchingPatient = _db.Patients.FirstOrDefault(temp => temp.PatientId == patientUpdateRequest.PatientId);
            if (matchingPatient == null)
            {
                throw new ArgumentException("Given Patient ID doesn't exist");
            }

            // Update patient entity with values from update request
            matchingPatient.PatientName = patientUpdateRequest.PatientName;
            matchingPatient.Email = patientUpdateRequest.Email;
            matchingPatient.DateOfBirth = patientUpdateRequest.DateOfBirth;
            matchingPatient.Gender = patientUpdateRequest.Gender?.ToString(); 
            matchingPatient.CountryID = patientUpdateRequest.CountryID;
            
            matchingPatient.PresentDoorNo = patientUpdateRequest.PresentDoorNo;
            matchingPatient.PresentStreetName = patientUpdateRequest.PresentStreetName;
            matchingPatient.PresentVillageTown = patientUpdateRequest.PresentVillageTown;
            matchingPatient.PresentPostOffice = patientUpdateRequest.PresentPostOffice;
            matchingPatient.PresentTaluk = patientUpdateRequest.PresentTaluk;
            matchingPatient.PresentState = patientUpdateRequest.PresentState?.ToString();
            matchingPatient.PresentDistrict = patientUpdateRequest.PresentDistrict;
            matchingPatient.PresentPincode = patientUpdateRequest.PresentPincode;
            matchingPatient.PermanentDoorNo = patientUpdateRequest.PermanentDoorNo;
            matchingPatient.PermanentStreetName = patientUpdateRequest.PermanentStreetName;
            matchingPatient.PermanentVillageTown = patientUpdateRequest.PermanentVillageTown;
            matchingPatient.PermanentPostOffice = patientUpdateRequest.PermanentPostOffice;
            matchingPatient.PermanentTaluk = patientUpdateRequest.PermanentTaluk;
            matchingPatient.PermanentState = patientUpdateRequest.PermanentState.ToString();
            matchingPatient.PermanentDistrict = patientUpdateRequest.PermanentDistrict;
            matchingPatient.PermanentPincode = patientUpdateRequest.PermanentPincode;
            matchingPatient.Phone = patientUpdateRequest.Phone;
            matchingPatient.Occupation = patientUpdateRequest.Occupation;
            matchingPatient.FatherName = patientUpdateRequest.FatherName;
            matchingPatient.MotherName = patientUpdateRequest.MotherName;
            matchingPatient.GuardianName = patientUpdateRequest.GuardianName;
            matchingPatient.GuardianPhoneNumber = patientUpdateRequest.GuardianPhoneNumber;
            matchingPatient.Religion = patientUpdateRequest.Religion?.ToString(); 
            matchingPatient.Title = patientUpdateRequest.Title?.ToString(); 
            matchingPatient.MaritalStatus = patientUpdateRequest.MaritalStatus?.ToString();
            matchingPatient.Aadhar = patientUpdateRequest.Aadhar;
            matchingPatient.Gurdain = patientUpdateRequest.Gurdain.ToString();
            matchingPatient.GurdainOccupation = patientUpdateRequest.GurdainOccupation;
            matchingPatient.Detailedinfo = patientUpdateRequest.Detailedinfo;
            matchingPatient.PermanentCountry = patientUpdateRequest.PermanentCountry;



            _db.SaveChanges();

            return ConvertPatientTOPatientResponse(matchingPatient);
        }


        public bool DeletePatient(string? patientId)
        {
            if (patientId == null)
                throw new ArgumentNullException(nameof(patientId));

            Patient? patient = _db.Patients.FirstOrDefault(temp => temp.PatientId == patientId);
            if (patient == null)
                return false;
            _db.Patients.Remove(_db.Patients.First( temp => temp.PatientId == patientId));
            _db.SaveChanges();
            return true;
        }

        public async Task<MemoryStream> GetPatientsExcel()
        {
            MemoryStream memoryStream = new MemoryStream();
            using (ExcelPackage excelPackage = new ExcelPackage(memoryStream))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("PatientsSheet");
                excelWorksheet.Cells["A1"].Value = "Patient Name";
                excelWorksheet.Cells["B1"].Value = "Email";
                excelWorksheet.Cells["C1"].Value = "Date of Birth";
                excelWorksheet.Cells["D1"].Value = "Age";
                excelWorksheet.Cells["E1"].Value = "Gender";
                //excelWorksheet.Cells["F1"].Value = "Country Name"; // Corrected column index
                excelWorksheet.Cells["F1"].Value = "Address"; // Corrected column index

                int row = 2;
                List<PatientResponse> response = _db.Patients
                    .Include("CountryName") // Assuming "CountryName" is the navigation property
                    .Select(temp => temp.ToPatientResponse())
                    .ToList();

                foreach (PatientResponse responseItem in response)
                {
                    excelWorksheet.Cells[row, 1].Value = responseItem.PatientName;
                    excelWorksheet.Cells[row, 2].Value = responseItem.Email;
                    if (responseItem.DateOfBirth.HasValue)
                        excelWorksheet.Cells[row, 3].Value = responseItem.DateOfBirth.Value.ToString("yyyy-MM-dd");
                    excelWorksheet.Cells[row, 4].Value = responseItem.Age;
                    excelWorksheet.Cells[row, 5].Value = responseItem.Gender;
                    //excelWorksheet.Cells[row, 6].Value = responseItem.CountryName; // Corrected column index
                    excelWorksheet.Cells[row, 6].Value = responseItem.PresentDoorNo;
                    excelWorksheet.Cells[row, 6].Value = responseItem.PresentStreetName;
                    excelWorksheet.Cells[row, 6].Value = responseItem.PresentState;// Corrected column index

                    row++;
                }

                excelWorksheet.Cells[$"A1:G{row - 1}"].AutoFitColumns(); // Adjusted range to include all columns

                // Save the package to the memory stream
                await excelPackage.SaveAsync();
            }

            memoryStream.Position = 0;
            return memoryStream;
        }


      
       
    }
}
