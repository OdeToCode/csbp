using System.Collections.Generic;

namespace Statistics.v2
{
    public interface IAggregationCalculator
    {
        Measurement Calculate(IEnumerable<Measurement> measurments);
    }
}