using System.Collections.Generic;
using System.Linq;
using Statistics.v1;
using Xunit;

namespace Statistics.Tests.v1
{
    public class When_aggregating_four_measurements
    {
        [Fact]
        public void grouping_by_4_should_produce_single_result()
        {
            var aggregator = new MeasurementAggregator(_data);
            var result = aggregator.Aggregate(4, AggregationType.Mean);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void grouping_by_2_should_produce_two_results()
        {
            var aggregator = new MeasurementAggregator(_data);
            var result = aggregator.Aggregate(2, AggregationType.Mean);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void averaging_should_calculate_average_high_and_low_values()
        {
            var aggregator = new MeasurementAggregator(_data);
            var result = aggregator.Aggregate(2, AggregationType.Mean);

            var first = result.ElementAt(0);
            Assert.Equal(7.5, first.HighValue, 2);
            Assert.Equal(1.5, first.LowValue, 2);

            var second = result.ElementAt(1);
            Assert.Equal(6.0, second.HighValue, 2);
            Assert.Equal(2.5, second.LowValue, 2);
        }

        [Fact]
        public void mode_should_calculate_average_high_and_low_values()
        {
            var aggregator = new MeasurementAggregator(_data);
            var result = aggregator.Aggregate(4, AggregationType.Mode);

            var first = result.ElementAt(0);
            Assert.Equal(10.0, first.HighValue, 1);
            Assert.Equal(1.0, first.LowValue, 1);
        }

        private readonly List<Measurement> _data = new List<Measurement>
                       {
                           new Measurement() {HighValue = 10.0, LowValue = 1.0},
                           new Measurement() {HighValue = 5.0, LowValue = 2.0},
                           new Measurement() {HighValue = 2.0, LowValue = 1.0},
                           new Measurement() {HighValue = 10.0, LowValue = 4.0}
                       };
    }
}