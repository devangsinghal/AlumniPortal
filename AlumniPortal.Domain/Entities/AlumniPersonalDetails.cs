namespace AlumniPortal.Domain.Entities
{
    public class AlumniPersonalDetails: BaseEntity
    {
        public int AlumniId { get; set; }
        public int AddressId { get; set; }
        public int EmployeeCode { get; set; }
        public string EmailAddress { get; set; }
        public string AlternateEmailAddress { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public  AlumniAddress AlumniAddress { get; set; }
    }
}
