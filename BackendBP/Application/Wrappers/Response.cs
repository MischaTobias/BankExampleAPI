namespace Application.Wrappers;

public class Response<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = default!;
    public List<string> Errors { get; set; } = default!;
    public T Result { get; set; } = default!;

    public Response() { }
}
