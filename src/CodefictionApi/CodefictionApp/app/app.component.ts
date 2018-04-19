import { Component, OnInit, OnDestroy, Inject, ViewEncapsulation, RendererFactory2, PLATFORM_ID, Injector } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute, PRIMARY_OUTLET } from '@angular/router';
import { Meta, Title, DOCUMENT, MetaDefinition } from '@angular/platform-browser';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/mergemap';
import 'rxjs/add/operator/map';
import { isPlatformServer } from '@angular/common';
//import { LinkService } from './shared/link.service';

import { REQUEST } from '@nguniversal/aspnetcore-engine/tokens';

declare var jQuery: any;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit, OnDestroy {

    // This will go at the END of your title for example "Home - Angular Universal..." <-- after the dash (-)
    private endPageTitle: string = 'Angular Universal and ASP.NET Core Starter';
    // If no Title is provided, we'll use a default one before the dash(-)
    private defaultPageTitle: string = 'My App';

    private routerSub$: Subscription;
    private request;

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private title: Title,
        private meta: Meta,
        //private linkService: LinkService,
        private injector: Injector
    ) {

        this.request = this.injector.get(REQUEST);

        console.log(`What's our REQUEST Object look like?`);
        console.log(`The Request object only really exists on the Server, but on the Browser we can at least see Cookies`);
        console.log(this.request);
    }

    ngOnInit() {
        // Change "Title" on every navigationEnd event
        // Titles come from the data.title property on all Routes (see app.routes.ts)
        //this._changeTitleOnNavigation();

      setTimeout(() => {
          jQuery('.simple-slider').owlCarousel({
            items: 1,
            loop: true,
          });

          // Show element on scroll
          jQuery('.animate-in').viewportChecker({
            classToAdd: 'animated',
            callbackFunction(elem, action) {
              if (elem.hasClass('progress')) {
                jQuery('.progress .progress-bar').css('width',
                  function () {
                    return jQuery(this).attr('aria-valuenow') + "%";
                  });
              }
            }
          });
        },
        10);
    }

    ngOnDestroy() {
        // Subscription clean-up
       // this.routerSub$.unsubscribe();
    }

    //private _changeTitleOnNavigation() {

    //    this.routerSub$ = this.router.events
    //        .filter(event => event instanceof NavigationEnd)
    //        .map(() => this.activatedRoute)
    //        .map(route => {
    //            while (route.firstChild) route = route.firstChild;
    //            return route;
    //        })
    //        .filter(route => route.outlet === 'primary')
    //        .mergeMap(route => route.data)
    //        .subscribe((event) => {
    //            this._setMetaAndLinks(event);
    //        });
    //}

    //private _setMetaAndLinks(event) {

    //    // Set Title if available, otherwise leave the default Title
    //    const title = event['title']
    //        ? `${event['title']} - ${this.endPageTitle}`
    //        : `${this.defaultPageTitle} - ${this.endPageTitle}`;

    //    this.title.setTitle(title);

    //    const metaData = event['meta'] || [];
    //    const linksData = event['links'] || [];

    //    for (let i = 0; i < metaData.length; i++) {
    //        this.meta.updateTag(metaData[i]);
    //    }

    //    for (let i = 0; i < linksData.length; i++) {
    //        this.linkService.addTag(linksData[i]);
    //    }
    //}

}

