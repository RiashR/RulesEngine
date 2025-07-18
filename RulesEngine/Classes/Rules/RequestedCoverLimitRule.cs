using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class RequestedCoverLimitRule : IRule<UnderwritingInput>
    {
        private const decimal MaxRequestedCover = 500000m;

        public Result Evaluate(UnderwritingInput input)
        {
            if (input.RequestedCover > MaxRequestedCover)
            {
                return new Result
                {
                    IsSuccessful = false,
                    Message = $"Requested cover exceeds the maximum allowed ({MaxRequestedCover:C})."
                };
            }

            return new Result { IsSuccessful = true };
        }
    }
}