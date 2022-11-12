namespace LearnWebApi.Model.DTO.Validator
{
    public interface IValidator
    {
        string Message { get; set; }
        bool Validate();
    }
}
