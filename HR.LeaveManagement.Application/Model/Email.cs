using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Model
{
    public class Email
    {
        public string From { get; set; }
        public string  To { get; set; }
        public string  Subject { get; set; }

        public string  Body { get; set; }

    }
}
