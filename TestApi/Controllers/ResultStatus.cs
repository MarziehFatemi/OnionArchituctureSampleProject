using Newtonsoft.Json;

namespace TestApi.Controllers
{
    public class ResultStatus
    {
        [JsonProperty(PropertyName = "isOk")]
        public bool IsOk { get; set; } = false;
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; } = "";
    }
}
