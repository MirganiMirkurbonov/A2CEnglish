using Domain.Enums;

namespace Domain.Models.Response;

public class ErrorModel
{
    public string Code { get; set; }
    public string Message { get; set; }

    public ErrorModel(ErrorEnum error)
    {
        Code = ((short)error).ToString();
        Message = error.ToString();
    }
}