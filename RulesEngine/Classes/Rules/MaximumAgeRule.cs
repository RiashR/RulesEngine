using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class MaximumAgeRule : IRule<UnderwritingInput>
    {

        private const int MaxAge = 60;

        public Result Evaluate(UnderwritingInput input)
        {
            if (input.Age > MaxAge)
            {
                return new Result 
                { 
                    IsSuccessful = true, 
                };
            }

            return new Result { IsSuccessful = false };
        }
    }
}

