using Microsoft.Extensions.DependencyInjection;
using RulesEngine.Classes;
using RulesEngine.Classes.Rules;
using RulesEngine.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace RulesEngine
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var services = new ServiceCollection();

            //services.AddScoped<IRule<UnderwritingInput>, AgeUnder25Rule>();
            //services.AddScoped<IRule<UnderwritingInput>, SmokerRule>();
            //services.AddScoped<IRule<UnderwritingInput>, MaximumAgeRule>();
            //services.AddScoped<IRule<UnderwritingInput>, MinimumIncomeRule>();
            //services.AddScoped<IRule<UnderwritingInput>, RequestedCoverLimitRule>();

            //services.AddScoped<PolicyTierEvaluator<UnderwritingInput>>();

            //var provider = services.BuildServiceProvider();

            //var applicants = new[]
            //{
            //    new UnderwritingInput { Age = 22, IsSmoker = false, Income = 30000, RequestedCover = 400000 },
            //    new UnderwritingInput { Age = 65, IsSmoker = false, Income = 30000, RequestedCover = 400000 },
            //    new UnderwritingInput { Age = 40, IsSmoker = false, Income = 30000, RequestedCover = 510000 },
            //};

            //var index = 1;
            //var tiers = PolicyTierDefinitions.Tiers;

            //foreach (var applicant in applicants)
            //{
            //    var policyTierEvaluator = provider.GetRequiredService<PolicyTierEvaluator<UnderwritingInput>>();
            //    var qualifiedTier = policyTierEvaluator.EvaluateTier(applicant, tiers);

            //    Console.WriteLine($"\n=== Applicant #{index++} ===");
            //    Console.WriteLine($"Age: {applicant.Age}, Smoker: {applicant.IsSmoker}, Income: {applicant.Income}, Cover: {applicant.RequestedCover}");

            //    if (qualifiedTier != null)
            //    {
            //        Console.WriteLine($"Applicant qualifies for: {qualifiedTier.Name} (Premium: {qualifiedTier.Premium:C})");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Applicant does not qualify for any tier.");
            //    }

            //    Console.WriteLine(new string('-', 50));
            //}

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5183/"); 

            var applicant = new UnderwritingInput
            {
                Age = 30,
                IsSmoker = false,
                Income = 25000,
                RequestedCover = 400000
            };

            try
            {
                // POST /underwriting/evaluate
                var response = await client.PostAsJsonAsync("underwriting/evaluate", applicant);

                if (response.IsSuccessStatusCode)
                {
                    var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = await response.Content.ReadFromJsonAsync<JsonElement>(jsonOptions);

                    Console.WriteLine(result.ToString());
                }
                else
                {
                    Console.WriteLine($"API Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}

