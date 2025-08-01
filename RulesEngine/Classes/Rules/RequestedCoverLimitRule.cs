using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class RequestedCoverLimitRule : IRule<UnderwritingInput>
    {
        private const decimal MaxRequestedCover = 500000m;

        public Result Evaluate(UnderwritingInput input) =>
            new() { IsSuccessful = input.RequestedCover >= MaxRequestedCover };
    }
}