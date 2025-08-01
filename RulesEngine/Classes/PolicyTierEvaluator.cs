using RulesEngine.Classes.Policies;

namespace RulesEngine.Classes
{
    public class PolicyTierEvaluator<T>
    {
        public PolicyTier? EvaluateTier(T input, IEnumerable<PolicyTier> policyTiers)
        {
            if (input is UnderwritingInput underwritingInput)
            {
                foreach (var tier in policyTiers)
                {
                    bool allPassed = tier.Rules.All(rule => rule.Evaluate(underwritingInput).IsSuccessful);
                    if (allPassed)
                        return tier;
                }
            }
            return null;
        }
    }
}
