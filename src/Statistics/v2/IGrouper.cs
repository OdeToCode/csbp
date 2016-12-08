using System.Collections.Generic;

namespace Statistics.v2
{
    public interface IGrouper
    {
        IEnumerable<IEnumerable<Measurement>> Group(IEnumerable<Measurement> measurements);
    }
}