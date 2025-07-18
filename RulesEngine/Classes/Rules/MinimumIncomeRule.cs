using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class MinimumIncomeRule : IRule<UnderwritingInput>
    {
        private const decimal MinIncome = 25000m;

        public Result Evaluate(UnderwritingInput input)
        {
            if (input.Income < MinIncome)
            {
                return new Result
                {
                    IsSuccessful = false,
                    Message = $"Applicant income is below the minimum required ({MinIncome:C})."
                };
            }

            return new Result { IsSuccessful = true };
        }
    }
}
