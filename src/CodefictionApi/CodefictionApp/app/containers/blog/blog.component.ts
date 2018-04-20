import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformServer, isPlatformBrowser } from '@angular/common';
declare var jQuery: any;

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {
  title: string = 'Angular 5.x Universal & ASP.NET Core 2.0 advanced starter-kit';

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {

  }

  ngOnInit() {
    if (isPlatformBrowser(this.platformId)) {
      setTimeout(() => {

      },
        10);
    }
  }
}
