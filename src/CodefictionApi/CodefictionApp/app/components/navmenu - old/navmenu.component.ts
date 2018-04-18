import { Component } from '@angular/core';

@Component({
    selector: 'app-nav-menu2',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})

export class NavMenuComponent2 {
    collapse: string = 'collapse';

    collapseNavbar(): void {
        if (this.collapse.length > 1) {
            this.collapse = '';
        } else {
            this.collapse = 'collapse';
        }
    }

    collapseMenu() {
        this.collapse = 'collapse';
    }
}
