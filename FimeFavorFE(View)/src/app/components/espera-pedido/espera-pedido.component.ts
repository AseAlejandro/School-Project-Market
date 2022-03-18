import { importType } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { OrdenService } from 'src/app/services/orden/orden.service';
import { CuentaService } from 'src/app/services/cuenta/cuenta.service';

@Component({
  selector: 'app-espera-pedido',
  templateUrl: './espera-pedido.component.html',
  styleUrls: ['./espera-pedido.component.css']
})
export class EsperaPedidoComponent implements OnInit {
  categorias: any[] = [];
  searchText: string = "";
  idCuenta: string = "";
  nombreRepartidor: string = "";
  lugarDeEntrega: string = ""

  constructor(
    private router: Router,
    private _categoriaService: CategoriaService,
    private _ordenService: OrdenService,
    private _cuentaService: CuentaService
  ) { }

  ngOnInit(): void {
    this._categoriaService.getCategorias().subscribe(categorias =>
      this.categorias = categorias)
    this._ordenService.getOrdenes().subscribe(ordenes =>
      this.idCuenta = ordenes[0].clienteId)
    this._cuentaService.getCuenta("asealejandro0").subscribe(nombre =>
      this.nombreRepartidor = nombre.nombre)
    this._ordenService.getOrdenes().subscribe(ordenes =>
        this.lugarDeEntrega = ordenes[0].lugarDeEntrega)
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }
}
