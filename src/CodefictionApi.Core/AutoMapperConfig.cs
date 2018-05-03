using AutoMapper;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;

namespace CodefictionApi.Core
{
    public static class AutoMapperConfig
    {
        private static readonly object LockObject = new object();

        public static void Init()
        {
            lock (LockObject)
            {
                IMapper mapper = null;

                try
                {
                    mapper = Mapper.Instance;
                }
                catch
                {
                }

                if (mapper != null)
                {
                    return;
                }

                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<IPodcast, PodcastModel>()
                       .ForMember(model => model.Attendees, expression => expression.Ignore())
                       .ForMember(model => model.Guest, expression => expression.Ignore());

                    cfg.CreateMap<IPodcast, P2PModel>()
                       .ForMember(model => model.Attendees, expression => expression.Ignore())
                       .ForMember(model => model.Guest, expression => expression.Ignore());

                    cfg.CreateMap<IPodcast, SpecialModel>()
                       .ForMember(model => model.Attendees, expression => expression.Ignore())
                       .ForMember(model => model.Guest, expression => expression.Ignore());

                    cfg.CreateMap<Meetup, MeetupModel>()
                       .ForMember(model => model.Attendees, expression => expression.Ignore())
                       .ForMember(model => model.Videos, expression => expression.Ignore())
                       .ForMember(model => model.Sponsors, expression => expression.Ignore());

                    cfg.CreateMap<IVideo, VideoModel>()
                       .ForMember(model => model.Attendees, expression => expression.Ignore());
                });
            }
        }
    }
}
