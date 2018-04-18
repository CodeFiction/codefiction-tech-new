import { NgModule, Inject } from '@angular/core';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { HttpModule, Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { TransferHttpCacheModule } from '@nguniversal/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { NavMobileMenuComponent } from './components/navmobilemenu/navmobilemenu.component';
import { BreadcrumbsComponent } from "./components/breadcrumbs/breadcrumbs.component";
import { HeaderComponent } from "./components/header/header.component";
import { FooterComponent } from "./components/footer/footer.component";

import { HomeComponent } from './containers/home/home.component';
import { AboutComponent } from './containers/about/about.component';
import { UsersComponent } from './containers/users/users.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';
import { CounterComponent } from './containers/counter/counter.component';
import { NotFoundComponent } from './containers/not-found/not-found.component';
import { NgxBootstrapComponent } from './containers/ngx-bootstrap-demo/ngx-bootstrap.component';

import { LinkService } from './shared/link.service';
import { UserService } from './shared/user.service';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        NavMobileMenuComponent,
        BreadcrumbsComponent,
        HeaderComponent,
        FooterComponent,

        AboutComponent,
        CounterComponent,
        UsersComponent,
        UserDetailComponent,
        HomeComponent,
        NotFoundComponent,
        NgxBootstrapComponent
    ],
    imports: [
        CommonModule,
        BrowserModule.withServerTransition({
          appId: 'my-app-id' // make sure this matches with your Server NgModule
        }),
        HttpClientModule,
        TransferHttpCacheModule,
        BrowserTransferStateModule,


        FormsModule,

        // App Routing
        RouterModule.forRoot([
            {
                path: '',
                redirectTo: 'home',
                pathMatch: 'full'
            },
            {
                path: 'home', component: HomeComponent,

                // *** SEO Magic ***
                // We're using "data" in our Routes to pass in our <title> <meta> <link> tag information
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
            },
            {
                path: 'about', component: AboutComponent,

                // *** SEO Magic ***
                // We're using "data" in our Routes to pass in our <title> <meta> <link> tag information
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
            }
            //{
            //    path: 'counter', component: CounterComponent,
            //    data: {
            //        title: 'Counter',
            //        meta: [{ name: 'description', content: 'This is an Counter page Description!' }],
            //        links: [
            //            { rel: 'canonical', href: 'http://blogs.example.com/counter/something' },
            //            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/counter' }
            //        ]
            //    }
            //},
            //{
            //    path: 'users', component: UsersComponent,
            //    data: {
            //        title: 'Users REST example',
            //        meta: [{ name: 'description', content: 'This is User REST API example page Description!' }],
            //        links: [
            //            { rel: 'canonical', href: 'http://blogs.example.com/chat/something' },
            //            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/users' }
            //        ]
            //    }
            //},
            //{
            //    path: 'ngx-bootstrap', component: NgxBootstrapComponent,
            //    data: {
            //        title: 'Ngx-bootstrap demo!!',
            //        meta: [{ name: 'description', content: 'This is an Demo Bootstrap page Description!' }],
            //        links: [
            //            { rel: 'canonical', href: 'http://blogs.example.com/bootstrap/something' },
            //            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/bootstrap-demo' }
            //        ]
            //    }
            //},

            ////{ path: 'lazy', loadChildren: './containers/lazy/lazy.module#LazyModule'},

            //{
            //    path: '**', component: NotFoundComponent,
            //    data: {
            //        title: '404 - Not found',
            //        meta: [{ name: 'description', content: '404 - Error' }],
            //        links: [
            //            { rel: 'canonical', href: 'http://blogs.example.com/bootstrap/something' },
            //            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/bootstrap-demo' }
            //        ]
            //    }
            //}
        ], {
          // Router options
          useHash: false,
          preloadingStrategy: PreloadAllModules,
          initialNavigation: 'enabled'
        })
    ],
    providers: [
        LinkService,
        UserService
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
