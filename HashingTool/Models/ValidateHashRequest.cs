namespace HashingTool.Models
{
    public class ValidateHashRequest
    {
        public string Base64Data { get; set; }

        public string ExpectedHash { get; set; }
    }
}