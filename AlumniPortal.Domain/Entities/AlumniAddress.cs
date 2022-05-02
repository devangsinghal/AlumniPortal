namespace AlumniPortal.Domain.Entities
{
    public class AlumniAddress:BaseEntity
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string LandMark { get; set; }
        public AlumniPersonalDetails AlumniPersonalDetail { get; set; }
    }
}
