import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-auto-system',
  templateUrl: './auto-system.component.html',
  styleUrls: ['./auto-system.component.css']
})
export class AutoSystemComponent implements OnInit {

  items: MenuItem[];
  constructor() { }

  ngOnInit(): void {
    this.items = [
      { label: 'Параметры', icon: 'pi pi-fw pi-chevron-right', routerLink: ['param'] },
      { label: 'Подключенные системы', icon: 'pi pi-fw pi-chevron-right', routerLink: ['connetc-sys'] },
    ];
  }

}
