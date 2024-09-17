
using System.ComponentModel.DataAnnotations;
using ServiceContracts.Dto;

namespace Services.Helpers
{
    public class ValidationHelpers
    {
        internal static void ModelValadition(object obj) 
        {
            //Model PatientName
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }

        }
    }
}
