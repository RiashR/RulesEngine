using RulesEngine.Classes;
using RulesEngine.Classes.Rules;
using RulesEngine.Interfaces;

namespace RulesEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = new UnderwritingInput
            {
                Age = 22,
                IsSmoker = true,
                Income = 30000,
                RequestedCover = 250000
            };

            var rules = new List<IRule<UnderwritingInput>>
            {
                new SmokerRule(),
                new AgeUnder25Rule(),
                new MaximumAgeRule(),
                new MinimumIncomeRule(),
                new RequestedCoverLimitRule()
            };

            foreach (var rule in rules)
            {
                var result = rule.Evaluate(input);
                Console.WriteLine(result.IsSuccessful
                    ? "Rule passed"
                    : $"Rule failed: {result.Message}");
            }
        }
    }
}
