using System.Collections.Generic;

namespace Statistics.v2
{
    public class MeasurementAggregator 
    {
        public MeasurementAggregator(IList<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public IEnumerable<Measurement> Aggregate(
            IGrouper grouper, IAggregationCalculator calculator)
        {
            var partitions = grouper.Group(_measurements);
            foreach (var partition in partitions)
            {
                yield return calculator.Calculate(partition);
            }
        }

        private readonly IList<Measurement> _measurements;
    }
}