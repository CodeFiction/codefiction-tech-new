using System;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Models
{
    public interface IPodcastModel
    {
        int Id { get; set; }

        int Season { get; set; }

        string Title { get; set; }

        string Slug { get; set; }

        string SoundcloudId { get; set; }

        string YoutubeUrl { get; set; }

        string ShortDescription { get; set; }

        string LongDescription { get; set; }

        Person Guest { get; set; }

        Person[] Attendees { get; set; }

        string[] Tags { get; set; }

        DateTime PublishDate { get; set; }
    }

    public class PodcastModel : IPodcastModel
    {
        public int Id { get; set; }

        public int Season { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string SoundcloudId { get; set; }

        public string YoutubeUrl { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public Person Guest { get; set; }

        public Person[] Attendees { get; set; }

        public string[] Tags { get; set; }

        public DateTime PublishDate { get; set; }
    }
}