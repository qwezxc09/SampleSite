import * as tslib_1 from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MasduComponent } from './masdu/masdu.component';
import { FullDataControlComponent } from './full-data-control/full-data-control.component';
import { WspControlComponent } from './wsp-control/wsp-control.component';
import { ArmControlComponent } from './wsp-control/arm-control/arm-control.component';
import { KcControlComponent } from './wsp-control/kc-control/kc-control.component';
import { LpuControlComponent } from './wsp-control/lpu-control/lpu-control.component';
import { ParamListComponent } from './masdu/param-list/param-list.component';
import { TagListComponent } from './full-data-control/tag-list/tag-list.component';
import { AutoSystemComponent } from './auto-system/auto-system.component';
import { ConnectedSystemsComponent } from './auto-system/connected-systems/connected-systems.component';
import { ParametersComponent } from './auto-system/parameters/parameters.component';
import { TabMenuModule } from 'primeng/tabmenu';
import { MenubarModule } from 'primeng/menubar';
import { MenuModule } from 'primeng/menu';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CalendarModule } from 'primeng/calendar';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { DatePipe } from '@angular/common';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { PasswordModule } from 'primeng/password';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { CraneComponent } from './crane/crane.component';
import { CraneNsiDataComponent } from './crane/crane-nsi-data/crane-nsi-data.component';
import { CraneReportDataComponent } from './crane/crane-report-data/crane-report-data.component';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        NgModule({
            declarations: [
                AppComponent,
                NavMenuComponent,
                HomePageComponent,
                MasduComponent,
                FullDataControlComponent,
                WspControlComponent,
                ArmControlComponent,
                KcControlComponent,
                LpuControlComponent,
                ParamListComponent,
                TagListComponent,
                AutoSystemComponent,
                ConnectedSystemsComponent,
                ParametersComponent,
                CraneReportDataComponent,
                CraneComponent,
                CraneNsiDataComponent,
            ],
            imports: [
                FormsModule,
                BrowserModule,
                HttpClientModule,
                AppRoutingModule,
                FormsModule,
                ButtonModule,
                MenuModule,
                TabMenuModule,
                CardModule,
                DropdownModule,
                BrowserAnimationsModule,
                SelectButtonModule,
                CalendarModule,
                TableModule,
                MultiSelectModule,
                InputTextModule,
                TooltipModule,
                MenubarModule,
                PanelModule,
                DialogModule,
                ConfirmDialogModule,
                PasswordModule,
                MessageModule,
                MessagesModule
            ],
            providers: [DatePipe, ConfirmationService, MessageService],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map