using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class SmokerRule : IRule<UnderwritingInput>
    {
        public Result Evaluate(UnderwritingInput input)
        {
            if (input.IsSmoker)
            {
                return new Result
                {
                    IsSuccessful = false,
                    Message = "Smoker applicants require premium loading."
                };
            }

            return new Result { IsSuccessful = true };
        }
    }
}
