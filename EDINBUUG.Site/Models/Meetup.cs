using Newtonsoft.Json;
using System;

namespace EDINBUUG.Site.Models
{
    /// <summary>
    /// Represents a Meetup Event.
    /// </summary>
    public class Meetup
    {
        /// <summary>
        /// Gets or sets the link to event on meetup.com.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the UTC start time of the event, in milliseconds since the epoch.
        /// </summary>
        [JsonProperty("time")]
        public ulong Time { get; set; }

        /// <summary>
        /// Gets or sets the local offset from UTC time, in milliseconds.
        /// </summary>
        [JsonProperty("utc_offset")]
        public ulong UtcOffset { get; set; }

        /// <summary>
        /// Gets the actual date/time of the event, calculated based on the UTC start time and offset.
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                return epoch.AddMilliseconds(Time + UtcOffset);
            }
        }
    }
}