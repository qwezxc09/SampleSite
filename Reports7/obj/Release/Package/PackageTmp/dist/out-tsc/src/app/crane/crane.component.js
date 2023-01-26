import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
var CraneComponent = /** @class */ (function () {
    function CraneComponent() {
    }
    CraneComponent.prototype.ngOnInit = function () {
        this.items = [
            { label: 'Отчет по контролю переустановки кранов', icon: 'pi pi-fw pi-chevron-right', routerLink: ['craneData'] },
            { label: 'Справочная информация по кранам', icon: 'pi pi-fw pi-chevron-right', routerLink: ['craneNSI'] },
        ];
    };
    CraneComponent = tslib_1.__decorate([
        Component({
            selector: 'app-crane',
            templateUrl: './crane.component.html',
            styleUrls: ['./crane.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], CraneComponent);
    return CraneComponent;
}());
export { CraneComponent };
//# sourceMappingURL=crane.component.js.map