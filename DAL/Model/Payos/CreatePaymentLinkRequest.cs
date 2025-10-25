
namespace DAL.Model.Momo
{
    public record CreatePaymentLinkRequest(
    string supscriptionName,
    string description,
    int amount,
    string returnUrl,
    string cancelUrl
);
}

