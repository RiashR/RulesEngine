using RulesEngine.Classes;
using RulesEngine.Classes.Policies;
using RulesEngine.Classes.Rules;
using RulesEngine.Interfaces;

namespace RulesEngine
{
    public static class PolicyTierDefinitions
    {
        public static List<PolicyTier> Tiers { get; } = new List<PolicyTier>
        {
            PremiumTier,
            SeniorTier,
            ActiveTier
        };

        public static PolicyTier ActiveTier => new PolicyTier
        {
            Name = "Active Tier",
            Rules = new IRule<UnderwritingInput>[]
            {
                new AgeUnder25Rule(),
                new SmokerRule()
            },
            Premium = 100m
        };

        public static PolicyTier SeniorTier => new PolicyTier
        {
            Name = "Senior Tier",
            Rules = new IRule<UnderwritingInput>[]
            {
                new MaximumAgeRule(),
                new SmokerRule()
            },
            Premium = 200m
        };

        public static PolicyTier PremiumTier => new PolicyTier
        {
            Name = "Premium Tier",
            Rules = new IRule<UnderwritingInput>[]
            {
                new RequestedCoverLimitRule(),
                new MinimumIncomeRule(),
                new SmokerRule()
            },
            Premium = 300m
        };
    }
}
