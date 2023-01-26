import { async, TestBed } from '@angular/core/testing';
import { NavMenuComponent } from './nav-menu.component';
describe('NavMenuComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [NavMenuComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(NavMenuComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=nav-menu.component.spec.js.map