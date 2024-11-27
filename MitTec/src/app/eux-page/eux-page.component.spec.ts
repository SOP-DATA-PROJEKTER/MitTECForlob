import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EuxPageComponent } from './eux-page.component';

describe('EuxPageComponent', () => {
  let component: EuxPageComponent;
  let fixture: ComponentFixture<EuxPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EuxPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EuxPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
