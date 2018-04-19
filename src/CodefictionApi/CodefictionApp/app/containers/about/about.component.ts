import { Component, OnInit, Inject } from '@angular/core';
declare var jQuery: any;

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  title: string = 'Angular 5.x Universal & ASP.NET Core 2.0 advanced starter-kit';


  // Here you want to handle anything with @Input()'s @Output()'s
  // Data retrieval / etc - this is when the Component is "ready" and wired up
  ngOnInit() {
    setTimeout(() => {
        jQuery('.simple-slider').owlCarousel({
          items: 1,
          loop: true,
        });

        jQuery('.preloader-wrapper').fadeOut();
        jQuery('#about .heding-wrapper').addClass('animated');

        // Show element on scroll
        jQuery('.animate-in').viewportChecker({
          classToAdd: 'animated',
          callbackFunction(elem, action) {
            if (elem.hasClass('progress')) {
              jQuery('.progress .progress-bar').css('width',
                function() {
                  return jQuery(this).attr('aria-valuenow') + "%";
                });
            }
          }
        });
      },
      10);
  }
}
