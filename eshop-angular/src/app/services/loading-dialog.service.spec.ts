import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { LoadingDialogService } from './loading-dialog.service';

describe('LoadingDialogService', () => {
  let service: LoadingDialogService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(LoadingDialogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
