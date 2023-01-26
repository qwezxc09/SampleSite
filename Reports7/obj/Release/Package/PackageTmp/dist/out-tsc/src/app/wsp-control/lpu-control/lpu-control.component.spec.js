import { async, TestBed } from '@angular/core/testing';
import { LpuControlComponent } from './lpu-control.component';
describe('LpuControlComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [LpuControlComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(LpuControlComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=lpu-control.component.spec.js.map