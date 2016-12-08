using System.Collections.Generic;
using System.Linq;

namespace Statistics.v2
{
    public class SizeGrouper : IGrouper
    {
        private readonly int _size;

        public SizeGrouper(int size)
        {
            _size = size;
        }

        public IEnumerable<IEnumerable<Measurement>> 
            Group(IEnumerable<Measurement> measurements)
        {
            int total = 0;
            while (total < measurements.Count())
            {
                yield return measurements.Skip(total).Take(_size);
                total += _size;
            }
        }
    }
}