import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor() { }
  items: MenuItem[];

  ngOnInit() {
    this.items = [
      { label: 'Отчеты', icon: 'pi pi-fw pi-th-large', routerLink: ['/home'] },
      { label: 'Контроль М АСДУ ЕСГ', icon: 'pi pi-fw pi-briefcase', routerLink: ['/masdu'] },
      { label: 'Контроль WSP', icon: 'pi pi-fw pi-sliders-h', routerLink: ['/wsp'] },
      { label: 'Контроль полноты сбора данных', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/fulldatas'] },
      { label: 'Система автоматики', icon: 'pi pi-fw pi-cog', routerLink: ['/autosystem'] },
      { label: 'Контроль переустановки кранов', icon: 'pi pi-fw pi-sliders-h', routerLink: ['/crane'] },
    ];
  }

}
