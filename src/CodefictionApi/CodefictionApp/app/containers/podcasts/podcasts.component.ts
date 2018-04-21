import { Component, OnInit, 
     // animation imports
    trigger, state, style, transition, animate,
    PLATFORM_ID, Inject } from '@angular/core';

import { IPodcast as IPodcasts } from '../../models/Podcasts';
import { PodcastService } from '../../shared/podcasts.service';

@Component({
    selector: 'app-podcasts',
    templateUrl: './podcasts.component.html',
    styleUrls: ['./podcasts.component.css'],
    animations: [
        // Animation example
        // Triggered in the ngFor with [@flyInOut]
        trigger('flyInOut', [
          state('in', style({ transform: 'translateY(0)' })),
          transition('void => *', [
            style({ transform: 'translateY(-100%)' }),
            animate(1000)
          ]),
          transition('* => void', [
            animate(1000, style({ transform: 'translateY(100%)' }))
          ])
        ])
      ]
})
export class PodcastsComponent implements OnInit {
    podcasts: IPodcasts[];

    constructor(
        @Inject(PLATFORM_ID) private platformId: Object,
        private podcastService: PodcastService) {

    }

    ngOnInit() {
        this.podcastService.getPodcasts().subscribe(result => {
            console.log('HttpClient [GET] /api/podcasts', result);
            this.podcasts = result;
        });
    }
}
