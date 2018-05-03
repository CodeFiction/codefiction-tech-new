using System;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Models
{
    public class VideoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string YoutubeUrl { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public Person[] Attendees { get; set; }

        public string[] Tags { get; set; }

        public Relation[] Relations { get; set; }

        public DateTime PublishDate { get; set; }

        public string Type { get; set; }
    }
}