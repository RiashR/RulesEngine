using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class SmokerRule : IRule<UnderwritingInput>
    {
        public Result Evaluate(UnderwritingInput input)
        {
            return input.IsSmoker
                ? new Result { IsSuccessful = false }
                : new Result { IsSuccessful = true };
        }
    }
}
