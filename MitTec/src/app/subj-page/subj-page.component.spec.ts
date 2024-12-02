import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjPageComponent } from './subj-page.component';

describe('SubjPageComponent', () => {
  let component: SubjPageComponent;
  let fixture: ComponentFixture<SubjPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubjPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubjPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
