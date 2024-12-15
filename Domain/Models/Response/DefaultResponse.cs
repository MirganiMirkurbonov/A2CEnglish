namespace Domain.Models.Response;

public class DefaultResponse <T>
{
    public T? Result { get; set; }
    public bool Success { get; set; }
    public ErrorModel? ErrorModel { get; set; }

    public DefaultResponse(T resul)
    {
        Result = resul;
        Success = true;
    }

    public DefaultResponse(ErrorModel error)
    {
        ErrorModel = error;
        Success = false;
    }
    
    public static implicit operator DefaultResponse<T>(T result) => new(result);

    public static implicit operator DefaultResponse<T>(ErrorModel error) => new(error);
}