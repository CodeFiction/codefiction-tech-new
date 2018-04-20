import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformServer, isPlatformBrowser } from '@angular/common';
declare var jQuery: any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {

  }

  ngOnInit() {
    if (isPlatformBrowser(this.platformId)) {
      setTimeout(() => {
        jQuery('.preloader-wrapper').fadeOut();
      },
        10);
    }
  }
}
