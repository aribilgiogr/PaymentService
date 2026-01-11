using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string>? ValidationErrors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? TraceId { get; set; }
    }
}
