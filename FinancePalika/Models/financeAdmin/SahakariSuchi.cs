using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePalika.Models.financeAdmin
{
    public class SahakariSuchi
    {
        public int Id { get; set; }
        public string DartaNo { get; set; }
        public string DartaMiti { get; set; }
        public string Name { get; set; }
        public string NameNepali { get; set; }
        public string FinanceType { get; set; }
        public string PanNo { get; set; }
        public string MainTask { get; set; }
        public string WorkArea { get; set; }
        public Nullable<int> StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }

        public Nullable<int> DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        public string LocalLevel { get; set; }

        public int WardNo { get; set; }
        public string ToleName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNo { get; set; }
    }
}
