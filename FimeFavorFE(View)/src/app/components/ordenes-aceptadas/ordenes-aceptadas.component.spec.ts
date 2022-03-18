import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdenesAceptadasComponent } from './ordenes-aceptadas.component';

describe('OrdenesAceptadasComponent', () => {
  let component: OrdenesAceptadasComponent;
  let fixture: ComponentFixture<OrdenesAceptadasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdenesAceptadasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdenesAceptadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
