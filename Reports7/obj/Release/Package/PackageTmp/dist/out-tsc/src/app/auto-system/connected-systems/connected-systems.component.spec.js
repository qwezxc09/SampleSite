import { async, TestBed } from '@angular/core/testing';
import { ConnectedSystemsComponent } from './connected-systems.component';
describe('ConnectedSystemsComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ConnectedSystemsComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(ConnectedSystemsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=connected-systems.component.spec.js.map