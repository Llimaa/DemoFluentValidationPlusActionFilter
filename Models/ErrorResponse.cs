namespace DemoFluentValidationPlusActionFilterPlusActionFilter;

public record ErrorResponse
{
    public ErrorResponse(int status) =>
        (Status, Errors) = (status, new());
        

    public int Status { get; set; }
    public Dictionary<string, string> Errors { get; set; } = default!;
}
