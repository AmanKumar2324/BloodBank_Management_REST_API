using BloodBank_Management_REST_API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BloodBank_Management_REST_API.Data
{
    public class InmemoryDataStore
    {
        //Static in memory list to store BloodBankEntry objects
        public static List<BloodBankEntry> BloodBankEntries { get; set; } = new List<BloodBankEntry>
        {
            new BloodBankEntry
            {
                DonorName = "Aman Singh",
                Age = 22,
                BloodType = "O+",
                ContactInfo = "aksingh230502@gmail.com",
                Quantity = 500,
                CollectionDate = DateTime.Now.AddDays(-5),
                ExpirationDate = DateTime.Now.AddDays(25),
                Status = "Available"
            },
            new BloodBankEntry
            {
                DonorName = "Jane Smith",
                Age = 25,
                BloodType = "O-",
                ContactInfo = "jane.smith@example.com",
                Quantity = 450,
                CollectionDate = DateTime.Now.AddDays(-10),
                ExpirationDate = DateTime.Now.AddDays(20),
                Status = "Available"
            },
            new BloodBankEntry
            {
                DonorName = "John Doe",
                Age = 30,
                BloodType = "A+",
                ContactInfo = "john.doe@example.com",
                Quantity = 500,
                CollectionDate = DateTime.Now.AddDays(-5),
                ExpirationDate = DateTime.Now.AddDays(25),
                Status = "Available"
            },
            new BloodBankEntry
            {
                DonorName = "Robert Brown",
                Age = 40,
                BloodType = "B+",
                ContactInfo = "robert.brown@example.com",
                Quantity = 600,
                CollectionDate = DateTime.Now.AddDays(-15),
                ExpirationDate = DateTime.Now.AddDays(15),
                Status = "Expired"
            }
        };
    }
}
