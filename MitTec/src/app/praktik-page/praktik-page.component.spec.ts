import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PraktikPageComponent } from './praktik-page.component';

describe('PraktikPageComponent', () => {
  let component: PraktikPageComponent;
  let fixture: ComponentFixture<PraktikPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PraktikPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PraktikPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
