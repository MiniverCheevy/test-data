using System.Collections.Generic;
using System.Linq;

namespace Voodoo.TestData.Strategy.TypeStrategy
{
    public class PredefinedSetTypeStrategy<T> : GenerationByTypeStrategy<T>
    {
        public PredefinedSetTypeStrategy(IEnumerable<T> possibleValues)
        {
            PossibleValues = possibleValues.ToArray();
        }

        public T[] PossibleValues { get; protected set; }


        public override T GenerateValue()
        {
            return PossibleValues.RandomElement();
        }
    }
}