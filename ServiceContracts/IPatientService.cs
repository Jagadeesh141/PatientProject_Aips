using ServiceContracts.Dto;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    public interface IPatientService
    {
        PatientResponse AddPatient(PatientAddRequest? patientAddRequest);
        List<PatientResponse> GetAllPatient();

        //retuens the matching patient obj
        PatientResponse? GetPatientByPatientId(string? patientId);


        List<PatientResponse> GetFilteredPatient(string searchby, string? searchString);

        List<PatientResponse> GetSortedPatients(List<PatientResponse> allPatients, string sortBy, SortOrderOptions sortOrder);

        PatientResponse UpdatePatient (PatientUpdateRequest? patientUpdateRequest);
        

        bool DeletePatient(string? patientId);

        Task<MemoryStream> GetPatientsExcel();
        
    }
}
