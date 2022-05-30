namespace Back_End_App.Models
{
    public class ResponseCodeModel
    {
        public string Code { get; set; } = "";
        public bool Success { get; set; } = false;
        public string Error { get; set; } = "";
        public object objectResponse { get; set; }

    }
}
