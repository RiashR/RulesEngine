using RulesEngine.Interfaces;

namespace RulesEngine.Classes.Policies
{
    public class PolicyTier
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<IRule<UnderwritingInput>> Rules { get; set; } = [];
        public decimal Premium { get; set; }
    }
}
