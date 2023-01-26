import { async, TestBed } from '@angular/core/testing';
import { CraneReportDataComponent } from './crane-report-data.component';
describe('CraneReportDataComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [CraneReportDataComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(CraneReportDataComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=crane-report-data.component.spec.js.map