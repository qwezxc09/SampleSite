import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-crane',
  templateUrl: './crane.component.html',
  styleUrls: ['./crane.component.css']
})
export class CraneComponent implements OnInit {
  items: MenuItem[];
  constructor() { }

  ngOnInit() {
    this.items = [
      { label: 'Отчет по контролю переустановки кранов', icon: 'pi pi-fw pi-chevron-right', routerLink: ['craneData'] },
      { label: 'Справочная информация по кранам', icon: 'pi pi-fw pi-chevron-right', routerLink: ['craneNSI'] },
    ];
  }

}
