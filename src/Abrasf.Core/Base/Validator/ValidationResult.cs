namespace Abrasf.Core.Base.Validator
{

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<KeyValuePair<string, string>> Messages { get; } = new();

        public void AddValidationError(string errorCode, string errorMessage)
        {
            this.Messages.Add(new KeyValuePair<string, string>(errorCode, errorMessage));
        }
    }
}