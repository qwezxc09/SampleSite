import { async, TestBed } from '@angular/core/testing';
import { AutoSystemComponent } from './auto-system.component';
describe('AutoSystemComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [AutoSystemComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(AutoSystemComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=auto-system.component.spec.js.map