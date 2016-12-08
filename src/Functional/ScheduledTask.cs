using System;

namespace BeyondQueries.demo
{
    public interface ITask { }
    public class GenerateReportTask : ITask { }

    public class ScheduledTask
    {
        public ITask Task { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan Expiration { get; set; }

        public ScheduledTask(ITask task, TimeSpan interval, TimeSpan expiration)
        {
            Task = task;
            Interval = interval;
            Expiration = expiration;
        }

        public static ScheduledTask HowToUse()
        {
            return new ScheduledTask(new GenerateReportTask(), 
                                     new TimeSpan(0, 0, 30, 0),
                                     new TimeSpan(2, 0, 0, 0));
        }
    }

    public class ScheduledTask2
    {
        public ITask Task { get; set; }
        public TimeSpan Interval { get; set; }
        public TimeSpan Expiration { get; set; }

        public ScheduledTask2(ITask task, TimeSpan runEvery, TimeSpan expireIn)
        {
            Task = task;
            Interval = runEvery;
            Expiration = expireIn;
        }

        public static ScheduledTask2 HowToUse()
        {
            return new ScheduledTask2(new GenerateReportTask(),
                                     runEvery: 2.Minutes(),
                                     expireIn: 5.Days());
        }
    }

    public static class SchedulingExtensions
    {
        public static TimeSpan Minutes(this int value)
        {
            return new TimeSpan(0, value, 0);
        }

        public static TimeSpan Days(this int value)
        {
            return new TimeSpan(value, 0, 0);
        }
    }
}