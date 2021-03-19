using System;

namespace Module.Systems.Logs
{
    public class Log
    {
        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public string ResponseBody { get; set; }
        public string RequestBody { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }
        public string Query { get; set; }
        public string RequestHeaders { get; set; }
        public string ResponseHeaders { get; set; }
        public int Status { get; set; }
        public string Protocol { get; set; }
        public string Cookies { get; set; }
        public string StackTrace { get; set; }
        public string Errors { get; set; }
        public string Environment { get; set; }

    }

    public class LogException
    {

    }

}
