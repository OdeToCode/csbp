using System.Collections.Generic;
using System.Linq;

namespace Statistics.v2
{
    public class MeanAggregationCalculator : IAggregationCalculator
    {
        public Measurement Calculate(IEnumerable<Measurement> measurements)
        {
            var result = new Measurement();
            result.HighValue = measurements.Average(m => m.HighValue);
            result.LowValue = measurements.Average(m => m.LowValue);
            return result;
        }
    }
}