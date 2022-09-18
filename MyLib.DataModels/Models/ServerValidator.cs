using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyLib.UI.Validation
{
    public class ServerValidation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("errors")]
        public IDictionary<string, string[]> Errors { get; set; }
    }

    public static class ServerValidationHelper
    {
        public static ServerValidation ServerValidationBadReqest()
        {
            return new ServerValidation
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = 400
            };
        }
    }
}
