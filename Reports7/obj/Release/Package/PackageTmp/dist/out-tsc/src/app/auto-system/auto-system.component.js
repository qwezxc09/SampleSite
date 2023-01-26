import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
var AutoSystemComponent = /** @class */ (function () {
    function AutoSystemComponent() {
    }
    AutoSystemComponent.prototype.ngOnInit = function () {
        this.items = [
            { label: 'Параметры', icon: 'pi pi-fw pi-chevron-right', routerLink: ['param'] },
            { label: 'Подключенные системы', icon: 'pi pi-fw pi-chevron-right', routerLink: ['connetc-sys'] },
        ];
    };
    AutoSystemComponent = tslib_1.__decorate([
        Component({
            selector: 'app-auto-system',
            templateUrl: './auto-system.component.html',
            styleUrls: ['./auto-system.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], AutoSystemComponent);
    return AutoSystemComponent;
}());
export { AutoSystemComponent };
//# sourceMappingURL=auto-system.component.js.map