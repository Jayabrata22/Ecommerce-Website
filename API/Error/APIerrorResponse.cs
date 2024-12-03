namespace API.Error
{
    public class APIerrorResponse(int Statuscode, string message, string? Details)
    {
        public int Statuscode { get; set; } = Statuscode;
        public string message { get; set; } = message;
        public string? Details { get; set; } = Details;
    }
}
