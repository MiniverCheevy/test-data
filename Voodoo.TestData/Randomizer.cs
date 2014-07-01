using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Voodoo.TestData.Strategy;
using Voodoo.TestData.Strategy.NameStrategy;
using Voodoo.TestData.Strategy.TypeStrategy;

namespace Voodoo.TestData
{
    public class Randomizer
    {
        private static RandomDataGenerator _gen;

        public Randomizer()
        {
            NameStrategies = new List<GenerationByNameStrategy> {new PropertyEndsWithIdNameStrategy()};
            TypeStrategies = new List<GenerationStrategy>
                {
                    new ByteStrategy(),
                    new IntStrategy(),
                    new ShortStrategy(),
                    new LongStrategy(),
                    new SingleStrategy(),
                    new DoubleStrategy(),
                    new DecimalStrategy(),
                    new DateStrategy(),
                    new BoolStrategy(),
                    new DefaultStringGenerationStrategy()
                };
        }

        protected List<GenerationStrategy> TypeStrategies { get; set; }
        protected List<GenerationByNameStrategy> NameStrategies { get; set; }

        internal static RandomDataGenerator RandomData
        {
            get { return _gen ?? (_gen = new RandomDataGenerator()); }
        }

        public void AddOrReplaceTypeStrategy<T>(GenerationByTypeStrategy<T> strategy)
        {
            var targetType = typeof (T);
            var strategies = TypeStrategies.Where(c => c.Type != targetType).ToList();
            strategies.Add(strategy);
            TypeStrategies = strategies;
        }

        
        public void AddOrReplaceNameStrategy<T>(GenerationByNameStrategy<T> strategy)
        {
            var targetType = typeof (T);
            var strategies = NameStrategies.Where(c => c.Type != targetType).ToList();
            strategies.Add(strategy);
            NameStrategies = strategies;
        }

        public void AddNameStrategy<T>(GenerationByNameStrategy<T> strategy)
        {            
            NameStrategies.Add(strategy);            
        }

        public void Randomize(object @object)
        {
            var existing = TypeStrategies.FirstOrDefault(c => c is DefaultStringGenerationStrategy);
            if (existing != null)
            {
                var stringStrategy = (existing as DefaultStringGenerationStrategy);
                if (stringStrategy != null)
                {
                    stringStrategy.Person = TestHelper.Data.Person();
                    AddOrReplaceTypeStrategy<string>(stringStrategy);
                }
            }

            var type = @object.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var info in properties)
            {
                if (!info.CanWrite)
                {
                    continue;
                }
                var propertyType = info.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    propertyType = propertyType.GetGenericArguments()[0];
                }

                var nameStrategy =
                    NameStrategies.Where(
                        strategy =>
                        strategy.Matches(info) || strategy.Matches(propertyType) || strategy.Matches(propertyType, info))
                                  .OrderBy(c => c.SortOrder)
                                  .FirstOrDefault();

                if (nameStrategy != null)
                {
                    nameStrategy.SetValue(@object, info);
                    continue;
                }

                var typeStrategy = TypeStrategies.Where(c => c.Type == propertyType).FirstOrDefault();

                if (typeStrategy != null)
                {
                    typeStrategy.SetValue(@object, info);
                    continue;
                }
            }
        }
    }
}