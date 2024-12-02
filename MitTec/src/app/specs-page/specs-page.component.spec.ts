import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecsPageComponent } from './specs-page.component';

describe('SpecsPageComponent', () => {
  let component: SpecsPageComponent;
  let fixture: ComponentFixture<SpecsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SpecsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SpecsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
