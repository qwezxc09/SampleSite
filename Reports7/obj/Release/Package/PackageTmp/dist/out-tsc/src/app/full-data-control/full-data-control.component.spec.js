import { async, TestBed } from '@angular/core/testing';
import { FullDataControlComponent } from './full-data-control.component';
describe('FullDataControlComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [FullDataControlComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(FullDataControlComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=full-data-control.component.spec.js.map