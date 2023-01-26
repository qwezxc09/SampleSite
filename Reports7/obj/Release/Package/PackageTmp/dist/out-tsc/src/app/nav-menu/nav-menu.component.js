import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent() {
    }
    NavMenuComponent.prototype.ngOnInit = function () {
        this.items = [
            { label: 'Отчеты', icon: 'pi pi-fw pi-th-large', routerLink: ['/home'] },
            { label: 'Контроль М АСДУ ЕСГ', icon: 'pi pi-fw pi-briefcase', routerLink: ['/masdu'] },
            { label: 'Контроль WSP', icon: 'pi pi-fw pi-sliders-h', routerLink: ['/wsp'] },
            { label: 'Контроль полноты сбора данных', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/fulldatas'] },
            { label: 'Система автоматики', icon: 'pi pi-fw pi-cog', routerLink: ['/autosystem'] },
            { label: 'Контроль переустановки кранов', icon: 'pi pi-fw pi-sliders-h', routerLink: ['/crane'] },
        ];
        //this.items = [
        //  {
        //    label: 'Отчеты',
        //    icon: 'pi pi-fw pi-th-large',
        //    routerLink: ['/'] 
        //    },
        //  {
        //    label: 'Контроль М АСДУ ЕСГ',
        //    icon: 'pi pi-fw pi-briefcase',
        //    routerLink: ['/masdu']
        //  },
        //  {
        //    label: 'Контроль WSP',
        //    icon: 'pi pi-fw pi-sliders-h',
        //    items: [
        //      { label: 'Контроль передачи данных с ЛПУ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['/lpu'] },
        //      { label: 'Контроль передачи данных с КЦ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['/kc'] },
        //      { label: 'Контроль ручного ввода', icon: 'pi pi-fw pi-chevron-right', routerLink: ['/arm'] },
        //    ]
        //  },
        //  { label: 'Контроль полноты сбора данных', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/fulldatas'] },
        //  {
        //    label: 'Система автоматики',
        //    icon: 'pi pi-fw pi-cog',
        //    items: [
        //      { label: 'Параметры', icon: 'pi pi-fw pi-chevron-right', routerLink: ['/param'] },
        //      { label: 'Подключенные системы', icon: 'pi pi-fw pi-chevron-right', routerLink: ['/connetc-sys'] },
        //    ]
        //  }
        //];
    };
    NavMenuComponent = tslib_1.__decorate([
        Component({
            selector: 'app-nav-menu',
            templateUrl: './nav-menu.component.html',
            styleUrls: ['./nav-menu.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], NavMenuComponent);
    return NavMenuComponent;
}());
export { NavMenuComponent };
//# sourceMappingURL=nav-menu.component.js.map