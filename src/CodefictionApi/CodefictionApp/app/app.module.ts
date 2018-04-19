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
import { BreadcrumbsComponent } from './components/breadcrumbs/breadcrumbs.component';
import { HeaderComponent } from "./components/header/header.component";
import { FooterComponent } from "./components/footer/footer.component";
import { PaginationComponent } from "./components/pagination/pagination.component";

import { HomeComponent } from './containers/home/home.component';
import { AboutComponent } from './containers/about/about.component';
import { BlogComponent } from './containers/blog/blog.component';
import { NotFoundComponent } from './containers/not-found/not-found.component';

import { LinkService } from './shared/link.service';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavMobileMenuComponent,
    BreadcrumbsComponent,
    HeaderComponent,
    FooterComponent,
    PaginationComponent,

    AboutComponent,
    HomeComponent,
    BlogComponent,
    NotFoundComponent,
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
        data: {
          title: 'About',
          meta: [{ name: 'description', content: 'This is an example Description Meta tag!' }],
          links: [
            { rel: 'canonical', href: 'http://blogs.example.com/blah/nice' },
            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/' }
          ]
        }
      },
      {
        path: 'blog', component: BlogComponent,
        data: {
          title: 'Blog',
          meta: [{ name: 'description', content: 'This is an example Description Meta tag!' }],
          links: [
            { rel: 'canonical', href: 'http://blogs.example.com/blah/nice' },
            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/' }
          ]
        }
      },
      {
        path: '**', component: NotFoundComponent,
        data: {
          title: '404 - Not found',
          meta: [{ name: 'description', content: '404 - Error' }],
          links: [
            { rel: 'canonical', href: 'http://blogs.example.com/bootstrap/something' },
            { rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/bootstrap-demo' }
          ]
        }
      },
      //{ path: 'lazy', loadChildren: './containers/lazy/lazy.module#LazyModule' }
    ], {
        // Router options
        useHash: false,
        preloadingStrategy: PreloadAllModules,
        initialNavigation: 'enabled'
      })
  ],
  providers: [
    LinkService
  ],
  bootstrap: [AppComponent]
})
export class AppModuleShared {
}
