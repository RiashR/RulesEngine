using Microsoft.Extensions.DependencyInjection;
using RulesEngine.Classes;
using RulesEngine.Classes.Rules;
using RulesEngine.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace RulesEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // Load rules from JSON
            var json = File.ReadAllText("Configuration/rules.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dynamicRules = JsonSerializer.Deserialize<List<DynamicRule>>(json, options);

            if (dynamicRules != null)
            {
                services.AddSingleton<IEnumerable<IRule<UnderwritingInput>>>(dynamicRules);
            }

            services.AddScoped<PolicyTierEvaluator<UnderwritingInput>>();

            var provider = services.BuildServiceProvider();

            var applicants = new[]
            {
                new UnderwritingInput { Age = 22, IsSmoker = false, Income = 30000, RequestedCover = 400000 },
                new UnderwritingInput { Age = 65, IsSmoker = false, Income = 30000, RequestedCover = 400000 },
                new UnderwritingInput { Age = 40, IsSmoker = false, Income = 30000, RequestedCover = 510000 },
            };

            var index = 1;
            var tiers = PolicyTierDefinitions.Tiers;

            using var scope = provider.CreateScope();
            var policyTierEvaluator = scope.ServiceProvider.GetRequiredService<PolicyTierEvaluator<UnderwritingInput>>();

            foreach (var applicant in applicants)
            {
                var qualifiedTier = policyTierEvaluator.EvaluateTier(applicant, tiers);

                Console.WriteLine($"\n=== Applicant #{index++} ===");
                Console.WriteLine($"Age: {applicant.Age}, Smoker: {applicant.IsSmoker}, Income: {applicant.Income}, Cover: {applicant.RequestedCover}");

                if (qualifiedTier != null)
                {
                    Console.WriteLine($"Applicant qualifies for: {qualifiedTier.Name} (Premium: {qualifiedTier.Premium:C})");
                }
                else
                {
                    Console.WriteLine("Applicant does not qualify for any tier.");
                }

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}

