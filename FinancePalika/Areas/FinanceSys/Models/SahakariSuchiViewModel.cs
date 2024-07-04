using FinancePalika.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FinancePalika.Areas.FinanceSys.Models
{
    public class SahakariSuchiViewModel
    {
        public int Id { get; set; }
        [DisplayName("दर्ता नं")]
        public string DartaNo { get; set; }
        [DisplayName("दर्ता मिति")]
        public string DartaMiti { get; set; }
        [DisplayName("नाम ")]
        public string Name { get; set; }
        [DisplayName("नाम (नेपाली)")]
        public string NameNepali { get; set; }
        [DisplayName("प्रकार")]
        public string FinanceType { get; set; }
        [DisplayName("स्थायी लेखा नं.")]
        public string PanNo { get; set; }
        [DisplayName("मुख्य कार्य")]
        public string MainTask { get; set; }
        [DisplayName("कार्य क्षेत्र")]
        public string WorkArea { get; set; }
        [DisplayName("प्रदेश")]
        public Nullable<int> StateId { get; set; }
        public State? State { get; set; }
        [DisplayName("जिल्ला")]
        public Nullable<int> DistrictId { get; set; }
        public District? District { get; set; }
        [DisplayName("स्थानीय तह")]
        public string LocalLevel { get; set; }
        [DisplayName("वडा नं.")]
        public int WardNo { get; set; }
        [DisplayName("टोल नाम")]
        public string ToleName { get; set; }
        [DisplayName("ईमेल ठेगाना")]
        public string EmailAddress { get; set; }
        [DisplayName("फोन नं")]
        public string PhoneNumber { get; set; }
        [DisplayName("मोवाइल नं.")]
        public string MobileNumber { get; set; }
        [DisplayName("फ्याक्स नं")]
        public string FaxNo { get; set; }
        public string? StateName { get; set; }
        public string? DistrictName { get; set; }
    }
}
