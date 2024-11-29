namespace WebApplicationDaData
{
    public class UserAddress
    {
        public UserAddress() { }
        public UserAddress(string? country, string? region, int postalCode, string? street, string? city) 
        { 
            Country = country;
            Region = region;
            Postal_Code = postalCode;
            Street = street;
            City = city;
        }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public int Postal_Code { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
