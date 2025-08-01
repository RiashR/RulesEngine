using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Rules
{
    public class AgeUnder25Rule : IRule<UnderwritingInput>
    {
        public Result Evaluate(UnderwritingInput input) =>
            new() { IsSuccessful = input.Age <= 25 };
    }
}