namespace NotaNacional.Core.Base.Validator
{

    public interface IValidator
    {
        ValidationResult Validate(object? data);
    }
}