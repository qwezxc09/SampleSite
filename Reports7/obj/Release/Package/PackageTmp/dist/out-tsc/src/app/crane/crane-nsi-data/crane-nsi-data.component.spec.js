import { async, TestBed } from '@angular/core/testing';
import { CraneNsiDataComponent } from './crane-nsi-data.component';
describe('CraneNsiDataComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [CraneNsiDataComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(CraneNsiDataComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=crane-nsi-data.component.spec.js.map