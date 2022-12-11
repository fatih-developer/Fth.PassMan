namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string Method { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}