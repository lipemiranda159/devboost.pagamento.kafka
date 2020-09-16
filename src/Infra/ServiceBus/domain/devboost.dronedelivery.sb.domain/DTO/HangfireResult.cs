using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.sb.domain.DTO
{
    public class HangfireResult
    {
        public List<string> Messages { get; set; }
        public string Status { get; set; }
    }
}
