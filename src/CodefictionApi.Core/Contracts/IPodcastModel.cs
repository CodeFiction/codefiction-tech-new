using System;
using CodefictionApi.Core.Data;

namespace CodefictionApi.Core.Contracts
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

        Relation[] Relations { get; set; }

        DateTime PublishDate { get; set; }
    }
}