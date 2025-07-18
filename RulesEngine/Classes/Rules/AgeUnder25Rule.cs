using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class AgeUnder25Rule : IRule<UnderwritingInput>
    {
        public Result Evaluate(UnderwritingInput input)
        {
            if (input.Age < 25)
            {
                return new Result
                {
                    IsSuccessful = false,
                    Message = "Applicant under 25 requires manual review."
                };
            }

            return new Result { IsSuccessful = true };
        }
    }
}