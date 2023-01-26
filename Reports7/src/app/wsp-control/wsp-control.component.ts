import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-wsp-control',
  templateUrl: './wsp-control.component.html',
  styleUrls: ['./wsp-control.component.css']
})
export class WspControlComponent implements OnInit {

  items: MenuItem[];
  constructor() { }

  ngOnInit(): void {
    this.items = [
      { label: 'Контроль передачи данных с ЛПУ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['lpu'] },
      { label: 'Контроль передачи данных с КЦ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['kc'] },
      { label: 'Контроль ручного ввода', icon: 'pi pi-fw pi-chevron-right', routerLink: ['arm'] },
    ];
  }

}
