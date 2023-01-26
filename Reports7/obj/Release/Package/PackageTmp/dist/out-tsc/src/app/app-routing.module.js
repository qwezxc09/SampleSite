import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AutoSystemComponent } from './auto-system/auto-system.component';
import { ConnectedSystemsComponent } from './auto-system/connected-systems/connected-systems.component';
import { ParametersComponent } from './auto-system/parameters/parameters.component';
import { FullDataControlComponent } from './full-data-control/full-data-control.component';
import { TagListComponent } from './full-data-control/tag-list/tag-list.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MasduComponent } from './masdu/masdu.component';
import { ParamListComponent } from './masdu/param-list/param-list.component';
import { ArmControlComponent } from './wsp-control/arm-control/arm-control.component';
import { KcControlComponent } from './wsp-control/kc-control/kc-control.component';
import { LpuControlComponent } from './wsp-control/lpu-control/lpu-control.component';
import { WspControlComponent } from './wsp-control/wsp-control.component';
import { CraneComponent } from './crane/crane.component';
import { CraneReportDataComponent } from './crane/crane-report-data/crane-report-data.component';
import { CraneNsiDataComponent } from './crane/crane-nsi-data/crane-nsi-data.component';
var routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomePageComponent },
    { path: 'masdu', component: MasduComponent },
    { path: 'arm', component: ArmControlComponent },
    {
        path: 'wsp', component: WspControlComponent, children: [
            { path: 'arm', component: ArmControlComponent },
            { path: 'kc', component: KcControlComponent },
            { path: 'lpu', component: LpuControlComponent }
        ]
    },
    { path: 'kc', component: KcControlComponent },
    { path: 'lpu', component: LpuControlComponent },
    {
        path: 'crane', component: CraneComponent, children: [
            { path: 'craneData', component: CraneReportDataComponent },
            { path: 'craneNSI', component: CraneNsiDataComponent },
        ]
    },
    { path: 'craneData', component: CraneReportDataComponent },
    { path: 'craneNSI', component: CraneNsiDataComponent },
    { path: 'fulldatas', component: FullDataControlComponent },
    {
        path: 'autosystem', component: AutoSystemComponent, children: [
            { path: 'param', component: ParametersComponent },
            { path: 'connetc-sys', component: ConnectedSystemsComponent }
        ]
    },
    { path: 'param', component: ParametersComponent },
    { path: 'connetc-sys', component: ConnectedSystemsComponent },
    { path: 'taglist/:kodLpu/:typeId/:stDate/:endDt/:typeData', component: TagListComponent },
    { path: 'paramlist/:lpuTitle/:errId/:session/:date', component: ParamListComponent }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib_1.__decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map