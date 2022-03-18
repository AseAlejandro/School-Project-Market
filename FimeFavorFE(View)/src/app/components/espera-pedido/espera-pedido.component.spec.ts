import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EsperaPedidoComponent } from './espera-pedido.component';

describe('EsperaPedidoComponent', () => {
  let component: EsperaPedidoComponent;
  let fixture: ComponentFixture<EsperaPedidoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EsperaPedidoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EsperaPedidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
