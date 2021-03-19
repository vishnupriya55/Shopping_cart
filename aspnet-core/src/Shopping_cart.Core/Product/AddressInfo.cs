using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
    public class AddressInfo
    {
        [Key]
        public int AddressId { get; set; }
        public string FullName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string MobileNumber { get; set; }
        public int Pincode { get; set; }

        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public UserDetails UserInfo { get; set; }
    }
}