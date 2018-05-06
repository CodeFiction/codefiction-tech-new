using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;
using CodefictionApi.Core.Tests.Mocks;
using Moq;
using Xunit;

namespace CodefictionApi.Core.Tests
{
    public class PodcastServiceTests
    {
        [Fact]
        public async Task GetPodcasts_Should_Return_Call_IPodcastRepository_GetPodcasts()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            mock.PodcastRepository
                .Setup(repository => repository.GetPodcasts())
                .ReturnsAsync(() => new List<Podcast>());

            mock.PodcastModelMapper.Setup(mapper => mapper.Map(It.IsAny<IEnumerable<Podcast>>()))
                .ReturnsAsync(() => new List<PodcastModel>());

            IEnumerable<IPodcastModel> podcastModels = await mock.GetPodcasts();

            mock.PodcastRepository.Verify(repository => repository.GetPodcasts(), Times.Once);
            Assert.NotNull(podcastModels);
        }

        [Fact]
        public async Task GetPodcasts_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var podcasts = new List<Podcast>
            {
                new Podcast {Id = 1, Title = "Angular 5"},
                new Podcast {Id = 2, Title = "Google IO"}
            };

            mock.PodcastRepository
                .Setup(repository => repository.GetPodcasts())
                .ReturnsAsync(() => podcasts);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<IEnumerable<Podcast>>(p => p.Equals(podcasts))))
                .ReturnsAsync(() => new List<PodcastModel>());

            IEnumerable<IPodcastModel> podcastModels = await mock.GetPodcasts();

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<IEnumerable<Podcast>>()), Times.Once);
            Assert.NotNull(podcastModels);
        }

        [Fact]
        public async Task GetPodcastBySlug_Should_Throw_ArgumentNullException_If_Slug_Is_Null()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            string slug = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => mock.GetPodcastBySlug(slug));
            mock.PodcastRepository.Verify(repository => repository.GetPodcastBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetPodcastBySlug_Should_Return_Call_IPodcastRepository_GetPodcastBySlug()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();
            
            var slug = "birinci-bolum-dotnet-core";

            mock.PodcastRepository
                .Setup(repository => repository.GetPodcastBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => new Podcast());

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.IsAny<Podcast>()))
                .ReturnsAsync(() => new PodcastModel());

            IPodcastModel podcastModel = await mock.GetPodcastBySlug(slug);

            mock.PodcastRepository.Verify(repository => repository.GetPodcastBySlug(It.IsAny<string>()), Times.Once);
            Assert.NotNull(podcastModel);
        }

        [Fact]
        public async Task GetPodcastBySlug_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var slug = "birinci-bolum-dotnet-core";

            var podcast = new Podcast {Id = 1, Title = "Angular 5"};

            mock.PodcastRepository
                .Setup(repository => repository.GetPodcastBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => podcast);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<Podcast>(p => p.Id == podcast.Id && p.Title == podcast.Title)))
                .ReturnsAsync(() => new PodcastModel());

            IPodcastModel podcastModel = await mock.GetPodcastBySlug(slug);

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<Podcast>()), Times.Once);
            Assert.NotNull(podcastModel);
        }

        [Fact]
        public async Task GetP2Ps_Should_Return_Call_IPodcastRepository_GetP2Ps()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            mock.PodcastRepository
                .Setup(repository => repository.GetP2Ps())
                .ReturnsAsync(() => new List<P2P>());

            mock.PodcastModelMapper.Setup(mapper => mapper.Map(It.IsAny<IEnumerable<P2P>>()))
                .ReturnsAsync(() => new List<P2PModel>());

            IEnumerable<IPodcastModel> p2pModels = await mock.GetP2Ps();

            mock.PodcastRepository.Verify(repository => repository.GetP2Ps(), Times.Once);
            Assert.NotNull(p2pModels);
        }

        [Fact]
        public async Task GetP2Ps_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var p2Ps = new List<P2P>
            {
                new P2P {Id = 1, Title = "Bilgem Çakır"},
                new P2P {Id = 2, Title = "Ebru Meriç Akgül"}
            };

            mock.PodcastRepository
                .Setup(repository => repository.GetP2Ps())
                .ReturnsAsync(() => p2Ps);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<IEnumerable<P2P>>(p => p.Equals(p2Ps))))
                .ReturnsAsync(() => new List<P2PModel>());

            IEnumerable<IPodcastModel> p2pModels = await mock.GetP2Ps();

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<IEnumerable<P2P>>()), Times.Once);
            Assert.NotNull(p2pModels);
        }

        [Fact]
        public async Task GetP2PBySlug_Should_Throw_ArgumentNullException_If_Slug_Is_Null()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            string slug = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => mock.GetP2PBySlug(slug));
            mock.PodcastRepository.Verify(repository => repository.GetP2PBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetP2PBySlug_Should_Return_Call_IPodcastRepository_GetPodcastBySlug()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var slug = "birinci-bolum-dotnet-core";

            mock.PodcastRepository
                .Setup(repository => repository.GetP2PBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => new P2P());

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.IsAny<P2P>()))
                .ReturnsAsync(() => new P2PModel());

            IPodcastModel p2pModel = await mock.GetP2PBySlug(slug);

            mock.PodcastRepository.Verify(repository => repository.GetP2PBySlug(It.IsAny<string>()), Times.Once);
            Assert.NotNull(p2pModel);
        }

        [Fact]
        public async Task GetP2PBySlug_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var slug = "yalin-kod-bilgem-cakir";

            var p2p = new P2P { Id = 1, Title = "Yalın Kod - Bilgem Çakır" };

            mock.PodcastRepository
                .Setup(repository => repository.GetP2PBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => p2p);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<P2P>(p => p.Id == p2p.Id && p.Title == p2p.Title)))
                .ReturnsAsync(() => new P2PModel());

            IPodcastModel p2pModel = await mock.GetP2PBySlug(slug);

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<P2P>()), Times.Once);
            Assert.NotNull(p2pModel);
        }

        [Fact]
        public async Task GetSpecials_Should_Return_Call_IPodcastRepository_GetSpecials()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            mock.PodcastRepository
                .Setup(repository => repository.GetSpecials())
                .ReturnsAsync(() => new List<Special>());

            mock.PodcastModelMapper.Setup(mapper => mapper.Map(It.IsAny<IEnumerable<Special>>()))
                .ReturnsAsync(() => new List<SpecialModel>());

            IEnumerable<IPodcastModel> specials = await mock.GetSpecials();

            mock.PodcastRepository.Verify(repository => repository.GetSpecials(), Times.Once);
            Assert.NotNull(specials);
        }

        [Fact]
        public async Task GetSpecials_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var specials = new List<Special>
            {
                new Special {Id = 1, Title = "Microsoft Ozel Yayını"},
                new Special {Id = 2, Title = "Facebook Skandalı"}
            };

            mock.PodcastRepository
                .Setup(repository => repository.GetSpecials())
                .ReturnsAsync(() => specials);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<IEnumerable<Special>>(p => p.Equals(specials))))
                .ReturnsAsync(() => new List<SpecialModel>());

            IEnumerable<IPodcastModel> specialModels = await mock.GetSpecials();

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<IEnumerable<Special>>()), Times.Once);
            Assert.NotNull(specialModels);
        }

        [Fact]
        public async Task GetSpecialBySlug_Should_Throw_ArgumentNullException_If_Slug_Is_Null()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            string slug = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => mock.GetSpecialBySlug(slug));
            mock.PodcastRepository.Verify(repository => repository.GetSpecialBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetSpecialBySlug_Should_Return_Call_IPodcastRepository_GetSpecialBySlug()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var slug = "microsoft-ozel-yayini";

            mock.PodcastRepository
                .Setup(repository => repository.GetSpecialBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => new Special());

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.IsAny<Special>()))
                .ReturnsAsync(() => new SpecialModel());

            IPodcastModel specialModel = await mock.GetSpecialBySlug(slug);

            mock.PodcastRepository.Verify(repository => repository.GetSpecialBySlug(It.IsAny<string>()), Times.Once);
            Assert.NotNull(specialModel);
        }

        [Fact]
        public async Task GetSpecialBySlug_Should_Return_Call_IPodcastModelMapper_Map()
        {
            PodcastServiceMock mock = PodcastServiceMock.Create();

            var slug = "microsoft-ozel-yayini";

            var special = new Special { Id = 1, Title = "Microsoft Ozel Yayını"};

            mock.PodcastRepository
                .Setup(repository => repository.GetSpecialBySlug(It.Is<string>(s => s == slug)))
                .ReturnsAsync(() => special);

            mock.PodcastModelMapper
                .Setup(mapper => mapper.Map(It.Is<Special>(s => s.Id == special.Id && s.Title == special.Title)))
                .ReturnsAsync(() => new SpecialModel());

            IPodcastModel specialModel = await mock.GetSpecialBySlug(slug);

            mock.PodcastModelMapper.Verify(repository => repository.Map(It.IsAny<Special>()), Times.Once);
            Assert.NotNull(specialModel);
        }
    }
}
