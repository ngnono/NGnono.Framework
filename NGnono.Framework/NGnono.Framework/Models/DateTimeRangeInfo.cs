using System;

namespace NGnono.Framework.Models
{
    [Serializable]
    public class DateTimeRangeInfo
    {
        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }
    }
}