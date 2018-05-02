using System;
using Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
    public class Podcast : IPodcast
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string SoundcloudId { get; set; }
        public string YoutubeUrl { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Guest { get; set; }
        public string[] Attendees { get; set; }
        public string[] Tags { get; set; }  
        public Relation[] Relations { get; set; }
        public DateTime PublishDate { get; set; }
    }
}