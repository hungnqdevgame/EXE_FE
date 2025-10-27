
namespace DAL.Model.Momo
{
    public record CreatePaymentLinkRequest(
           int userId,
    int supscriptionId,
    string supscriptionName,
    string description,
    int amount,
    string returnUrl,
    string cancelUrl
);
}

