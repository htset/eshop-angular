import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AdminOrderDetailsComponent } from './admin-order-details.component';

describe('AdminOrderDetailsComponent', () => {
  let component: AdminOrderDetailsComponent;
  let fixture: ComponentFixture<AdminOrderDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminOrderDetailsComponent],
      imports: [HttpClientTestingModule, RouterTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminOrderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
