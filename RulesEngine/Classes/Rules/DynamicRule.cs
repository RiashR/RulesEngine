using RulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Classes.Rules
{
    public class DynamicRule : IRule<UnderwritingInput>
    {
        public string? Field { get; set; }
        public string? Operator { get; set; }
        public object? Value { get; set; }

        Result IRule<UnderwritingInput>.Evaluate(UnderwritingInput input)
        {
            var property = typeof(UnderwritingInput).GetProperty(Field);
            if (property == null)
                return new Result { IsSuccessful = false };

            var inputValue = property.GetValue(input);

            // Dynamically convert Value to the property type
            object? compareValue = Convert.ChangeType(Value, property.PropertyType);

            if (inputValue == null || compareValue == null)
                return new Result { IsSuccessful = false };

            bool isSuccess = Operator switch
            {
                "<" => Convert.ToDecimal(inputValue) < Convert.ToDecimal(compareValue),
                ">" => Convert.ToDecimal(inputValue) > Convert.ToDecimal(compareValue),
                "==" => Equals(inputValue, compareValue),
                ">=" => Convert.ToDecimal(inputValue) >= Convert.ToDecimal(compareValue),
                "<=" => Convert.ToDecimal(inputValue) <= Convert.ToDecimal(compareValue),
                _ => false
            };

            return new Result { IsSuccessful = isSuccess };
        }
    }
}
