namespace MultiShop.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public int IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
