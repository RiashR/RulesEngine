using RulesEngine.Classes;

namespace RulesEngine.Interfaces
{
    public interface IRule<T>
    {
        Result Evaluate(T input);
    }
}
