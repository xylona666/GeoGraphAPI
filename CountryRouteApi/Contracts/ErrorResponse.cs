namespace CountryRouteApi.Contracts;

public class ErrorResponse
{
    public string Valid { get; set; }
    public string Reason { get; set; }

    public ErrorResponse(string valid, string reason)
    {
        this.Valid = valid;
        this.Reason = reason;
    }
}