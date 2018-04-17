import { NgModule, Inject } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { HttpModule, Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { TransferHttpCacheModule } from '@nguniversal/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './containers/home.component';

import { LinkService } from './shared/link.service';

const appRoutes: Routes = [{
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home', component: HomeComponent,

        // *** SEO Magic ***
        // We're using "data" in our Routes to pass in our <title> <meta> <link> tag information
        // tslint:disable-next-line:max-line-length
        // Note: This is only happening for ROOT level Routes, you'd have to add some additional logic if you wanted this for Child level routing
        // When you change Routes it will automatically append these to your document for you on the Server-side
        //  - check out app.component.ts to see how it's doing this
        data: {
            title: 'Homepage',
            meta: [{ name: 'description', content: 'This is an example Description Meta tag!' }],
            links: [
                { rel: 'canonical', href: 'http://blogs.example.com/blah/nice' },
                { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/' }
            ]
        }
    }];

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent
    ],
  imports: [
        CommonModule,
        // To support Universal rendering. The application ID can be any identifier which is unique on the page.
        BrowserModule.withServerTransition({
           appId: 'my-app-site'
        }),
        BrowserModule,
        HttpClientModule,
        TransferHttpCacheModule,
        BrowserTransferStateModule,
        FormsModule,

        RouterModule.forRoot(appRoutes, {
                // Router options
                useHash: false,
                preloadingStrategy: PreloadAllModules,
                initialNavigation: 'enabled'
            })
    ],
    providers: [LinkService],
    bootstrap: [AppComponent]
})
export class AppModuleShared { }
