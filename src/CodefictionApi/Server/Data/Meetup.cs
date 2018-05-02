using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
    public class Meetup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MeetupLink { get; set; }

        public string[] Attendees { get; set; }

        public string[] Videos { get; set; }

        public string[] Sponsors { get; set; }

        public string[] Photos { get; set; }

        public DateTime Date { get; set; }
    }
}
