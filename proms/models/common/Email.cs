using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.common
{
    public class Email
    {
        public string fromName { set; get; }
        public string toAddress { set; get; }
        public string[] ccAddresses { set; get; }
        public string fromAddress { set; get; }
        public string subject { set; get; }
        public string htmlContent { set; get; }

        public Email(string fromName, string toAddress, string[] ccAddresses, string fromAddress, string subject, string htmlContent)
        {
            this.fromName = fromName; this.toAddress = toAddress; this.ccAddresses = ccAddresses; this.fromAddress = fromAddress; this.subject = subject; this.htmlContent = htmlContent;
        }
    }
}