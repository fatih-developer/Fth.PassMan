using Newtonsoft.Json;

namespace Core.Extensions
{
    public class ErrorDetail
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public int InfoCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}