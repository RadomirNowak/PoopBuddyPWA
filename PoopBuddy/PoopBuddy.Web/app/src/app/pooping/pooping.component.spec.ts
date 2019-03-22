import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoopingComponent } from './pooping.component';

describe('PoopingComponent', () => {
  let component: PoopingComponent;
  let fixture: ComponentFixture<PoopingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoopingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoopingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
