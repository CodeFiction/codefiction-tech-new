using System;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Models
{
    public class MeetupModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MeetupLink { get; set; }

        public Person[] Attendees { get; set; }

        public VideoModel[] Videos { get; set; }

        public Sponsor[] Sponsors { get; set; }

        public string[] Photos { get; set; }

        public DateTime Date { get; set; }
    }
}