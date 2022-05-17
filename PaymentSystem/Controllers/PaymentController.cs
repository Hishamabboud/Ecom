using Microsoft.AspNetCore.Mvc;
using Mollie;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment;
using Mollie.Api.Models.Payment.Response;
using Mollie.Api.Client;
using Mollie.Api.Models.Refund;

namespace PaymentSystem.Controllers
{
    public class PaymentController : Controller
    {
        IPaymentClient paymentClient = new PaymentClient("");
        IRefundClient refundClient = new RefundClient("{ApiKey}");
        PaymentRequest paymentRequest = new PaymentRequest();
        IPaymentMethodClient _paymentMethodClient = new PaymentMethodClient("{ApiKey}");

        [HttpPost]
        public async Task<string> CreatePayment(string amount, string description, string customerId, string webhookUrl, string redirectUrl, string TableNr)
        {
            var metaData = new { test = "f" };


            var paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, amount),
                Description = description,
                CustomerId = customerId,
                WebhookUrl = webhookUrl,
                RedirectUrl = redirectUrl,
                Methods = new List<string>()
                {
                PaymentMethod.Ideal,
                PaymentMethod.ApplePay,
                PaymentMethod.CreditCard,
                PaymentMethod.DirectDebit
                }
            };

            paymentRequest.SetMetadata(metaData);

            var result = await paymentClient.CreatePaymentAsync(paymentRequest);

            return result.Links.Checkout.Href;
        }


        [HttpPut]
        public async Task<PaymentResponse> UpdatePayment(string PaymentId, string description, string metadata)
        {

            PaymentUpdateRequest paymentUpdateRequest = new PaymentUpdateRequest()
            {
                Description = description,
                Metadata = metadata
            };
            PaymentResponse updatedPayment = await this.paymentClient.UpdatePaymentAsync(PaymentId, paymentUpdateRequest);
            return updatedPayment;
        }

        [HttpPost("paymentid")]
        public async Task<RefundResponse> CreateRefund(string paymentId, string refundId)
        {
            RefundResponse refundResponse = await this.refundClient.GetRefundAsync("{paymentId}", "{refundId}");
            return refundResponse;
        }


    }
}
