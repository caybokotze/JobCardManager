using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService
{
    public class Invoice
    {
        public Invoice()
        {

        }

        public string Currency { get; set; } = "R";

        public string Title { get; set; } = "Quote";

        public string Notes { get; set; } = "Just a quick insert from your lovely team at Merge Group";

        public string Terms { get; set; } = "Normally terms and conditions can be placed here.";

        public string InvoiceNumber { get; set; } = "#1";

        public double Discount { get; set; } = 0; //Percentage. = "N/A";

        public string Status { get; set; } = "N/A";

        public DateTime Date { get; set; }

        public Client Client { get; set; }

        public Business Business { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }

    public class Client
    {
        public Client(string companyName, string personName, string phoneNumber, string emailAddress, string physicalAddress)
        {
            this.CompanyName = CompanyName;
            this.PersonName = personName;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.PhysicalAddress = physicalAddress;
        }
        public string CompanyName { get; set; } = "N/A";
        public string PersonName { get; set; } = "N/A";
        public string PhoneNumber { get; set; } = "N/A";
        public string EmailAddress { get; set; } = "N/A";
        public string PhysicalAddress { get; set; } = "N/A";
    }

    public class Business
    {
        public string LogoRootPath { get; set; } = "~/Images/icon.png";
        public string CompanyName { get; set; } = "N/A";
        public string EmailAddress { get; set; } = "N/A";
        public string WebsiteAddress { get; set; } = "N/A";
        public string PhoneNumber { get; set; } = "N/A";
        public string PhysicalAddress { get; set; } = "N/A";
        public string BankAccountNumber { get; set; } = "N/A";
        public string BankBranchCode { get; set; } = "N/A";
        public string SwiftCode { get; set; } = "N/A";
        public string BankReferenceNumber { get; set; } = "N/A";
    }
}
