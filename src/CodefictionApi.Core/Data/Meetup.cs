using System;

namespace CodefictionApi.Core.Data
{
    public class Meetup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MeetupLink { get; set; }

        public string[] Attendees { get; set; }

        public int[] VideoIds { get; set; }

        public int[] SponsorIds { get; set; }

        public string[] Photos { get; set; }

        public DateTime Date { get; set; }
    }
}
