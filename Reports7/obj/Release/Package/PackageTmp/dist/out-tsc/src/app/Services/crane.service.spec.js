import { TestBed } from '@angular/core/testing';
import { CraneService } from './crane.service';
describe('CraneService', function () {
    beforeEach(function () { return TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = TestBed.get(CraneService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=crane.service.spec.js.map