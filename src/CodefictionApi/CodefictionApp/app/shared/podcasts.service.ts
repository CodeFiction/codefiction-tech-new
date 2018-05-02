import { Injectable, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Http, URLSearchParams } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';
import { Observable } from 'rxjs/Observable';
import { Podcast } from '../models/Podcasts';

@Injectable()
export class PodcastService {

    private baseUrl: string;

    constructor(
        private http: HttpClient,
        private injector: Injector
    ) {
        this.baseUrl = this.injector.get(ORIGIN_URL);
    }

    getPodcasts() {
        return this.http.get<Podcast[]>(`${this.baseUrl}/api/podcasts`);
    }

    getPodcastbySlug(slug: string) {
        return this.http.get<Podcast>(`${this.baseUrl}/api/podcasts/` + slug);
    }
}
