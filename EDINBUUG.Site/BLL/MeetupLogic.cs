using EDINBUUG.Site.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EDINBUUG.Site.BLL
{
    public class MeetupLogic
    {
        /// <summary>
        /// Gets the next upcoming meetup from the Meetup API.
        /// </summary>
        /// <returns>
        /// A <see cref="Meetup"/> object or <c>null</c> if there are no upcoming meetups.
        /// </returns>
        public static Meetup GetNextMeetup()
        {
            Meetup meetup = null;

            
             using (var client = new HttpClient())
 +            {
 +                var result = client.GetAsync($"http://api.meetup.com/Edinburgh-Umbraco-Users-Group/events").Result;
 +                if (result.IsSuccessStatusCode)
 +                {
 +                    var content = result.Content.ReadAsStringAsync().Result;
 +                    var meetups = JsonConvert.DeserializeObject<IEnumerable<Meetup>>(content);
 +                    meetup = meetups.FirstOrDefault();
 +                }
 +            }
            
          

            return meetup;
        }
    }
}
