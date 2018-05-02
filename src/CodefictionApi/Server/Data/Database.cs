﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
    public class Database
    {
        public Podcast[] Podcasts { get; set; }

        public P2P[] P2Ps { get; set; }

        public Special[] Specials { get; set; }

        public Meetup[] Meetups { get; set; }

        public Video[] Videos { get; set; }

        public Person[] People { get; set; }

        public Sponsor[] Sponsors { get; set; }
    }
}
