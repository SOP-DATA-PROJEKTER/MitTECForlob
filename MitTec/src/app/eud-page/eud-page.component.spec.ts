import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EudPageComponent } from './eud-page.component';

describe('EudPageComponent', () => {
  let component: EudPageComponent;
  let fixture: ComponentFixture<EudPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EudPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EudPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
