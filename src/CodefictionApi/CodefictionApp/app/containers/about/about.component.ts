import { Component, OnInit, Inject } from '@angular/core';

@Component({
    selector: 'app-about',
    templateUrl: './about.component.html'
})
export class AboutComponent implements OnInit {

    title: string = 'Angular 5.x Universal & ASP.NET Core 2.0 advanced starter-kit';


    // Here you want to handle anything with @Input()'s @Output()'s
    // Data retrieval / etc - this is when the Component is "ready" and wired up
    ngOnInit() { }
}
