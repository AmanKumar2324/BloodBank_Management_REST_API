namespace BloodBank_Management_REST_API.Models
{
    public class BloodBankEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DonorName { get; set; }
        public int Age { get; set; }
        public string BloodType { get; set; }
        public string ContactInfo { get; set; }
        public int Quantity { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
    }
}
