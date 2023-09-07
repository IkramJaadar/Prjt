using Newtonsoft.Json.Linq;
using Stripe;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Prjt.Models
{
    public class ProcessPayment
    {
        public static async Task<dynamic> PayAsync(PaymentModel payModel)
        {
            try
            {
                //clé
                StripeConfiguration.ApiKey = "sk_test_51MgrOyLIZyfTBfckL313balx8VHro1y6NruojIPR8IygyqE3YQpVioX9I1UNRbsUb1N6gnApwbthtPPvDk91JJNQ00JbDbHpH0";
                //les infos du carte
                var options = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Name = payModel.NomCompletClient,
                        Number = payModel.CardNumder,
                        ExpMonth = payModel.Month.ToString(),
                        ExpYear = payModel.Year.ToString(),
                        Cvc = payModel.CVC
                    },
                };

                var serviceToken = new TokenService();

                Token stripeToken = await serviceToken.CreateAsync(options);

                var chargeOptions = new ChargeCreateOptions
                {
                    
                    Amount = (int)(payModel.MntPy * 100 / 10.3),
                    Currency = "usd",
                    Description = "Paiments de Rv de Service " + payModel.ServiceName,
                    Source = stripeToken.Id
                };

                var chargeService = new ChargeService();
                Charge charge = await chargeService.CreateAsync(chargeOptions);

                if (charge.Paid)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
