namespace Quiz.DTO
{
    public class CheckoutDTO
    {
        public int UserId { get; set; }               // ID của user thanh toán
        public int SubscriptionId { get; set; }       // ID gói (Pro, Premium...)
        public string SupscriptionName { get; set; } = string.Empty; // Tên hiển thị
        public int Amount { get; set; }
    }
}
