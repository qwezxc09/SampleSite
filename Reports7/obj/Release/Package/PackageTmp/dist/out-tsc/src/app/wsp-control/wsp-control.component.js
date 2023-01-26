import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
var WspControlComponent = /** @class */ (function () {
    function WspControlComponent() {
    }
    WspControlComponent.prototype.ngOnInit = function () {
        this.items = [
            { label: 'Контроль передачи данных с ЛПУ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['lpu'] },
            { label: 'Контроль передачи данных с КЦ', icon: 'pi pi-fw pi-chevron-right', routerLink: ['kc'] },
            { label: 'Контроль ручного ввода', icon: 'pi pi-fw pi-chevron-right', routerLink: ['arm'] },
        ];
    };
    WspControlComponent = tslib_1.__decorate([
        Component({
            selector: 'app-wsp-control',
            templateUrl: './wsp-control.component.html',
            styleUrls: ['./wsp-control.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], WspControlComponent);
    return WspControlComponent;
}());
export { WspControlComponent };
//# sourceMappingURL=wsp-control.component.js.map