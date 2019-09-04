using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models
{
    public class SmsMessage
    {
        public string recipientNumber { get; set; }
        public string smsText { get; set; }
        public SmsMessage(string recipientNumber, string smsText)
        {
            this.recipientNumber = recipientNumber;
            this.smsText = smsText;
        }
    }
}