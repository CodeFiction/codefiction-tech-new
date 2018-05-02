import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { PodcastService } from '../../shared/podcasts.service';
import { Podcast } from '../../models/Podcasts';

@Component({
    selector: 'app-podcasts',
    templateUrl: './podcasts.component.html',
    styleUrls: ['./podcasts.component.css']
})
export class PodcastsComponent implements OnInit {
    podcasts: Podcast[];

    constructor(
        @Inject(PLATFORM_ID) private platformId: Object,
        private podcastService: PodcastService) {

    }

    ngOnInit() {
        this.podcastService.getPodcasts().subscribe(result => {
            console.log('HttpClient [GET] /api/podcasts', result);
            this.podcasts = result;
        });

        //this.podcasts$ = this.podcastService.getPodcasts();
    }
}
