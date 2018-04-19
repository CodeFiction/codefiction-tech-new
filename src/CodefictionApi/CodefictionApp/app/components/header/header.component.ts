import { Component, OnInit } from '@angular/core';
declare var jQuery: any;

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  ngOnInit() {
    setTimeout(() => {
        jQuery('.preloader-wrapper').fadeOut();
      },
      10);
  }

}
