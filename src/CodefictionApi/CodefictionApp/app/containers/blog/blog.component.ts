import { Component, OnInit, Inject } from '@angular/core';
declare var jQuery: any;

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  title: string = 'Angular 5.x Universal & ASP.NET Core 2.0 advanced starter-kit';

  ngOnInit() {
    setTimeout(() => {

      },
      10);
  }
}
