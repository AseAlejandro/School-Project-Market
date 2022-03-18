import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { OrdenService } from 'src/app/services/orden/orden.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { CuentaService } from 'src/app/services/cuenta/cuenta.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-inicio-vendedor',
  templateUrl: './inicio-vendedor.component.html',
  styleUrls: ['./inicio-vendedor.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class InicioVendedorComponent implements OnInit {
  ordenes: [] = [];
  orden: any = "";
  header: string = "";
  searchText: string ="";
  categorias: any[] = [];
  displayedColumns: string[] = ["fecha", "clienteId", "repartidorId", "total"]
  expandedElement: ListaOrden | null | undefined;
  currentUser: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private router: Router,
    private _ordenService: OrdenService,
    private _cuentaService: CuentaService,
    private token: TokenService
  ) { }

  ngOnInit(): void {
    this.header = "Ordenes"
    this._ordenService.getOrdenes().subscribe(ordenes =>
      this.ordenes = ordenes)
    this.getUserLogged();
    this.currentUser = this.token.getUser();
    console.log(this.currentUser)
  }

  getUserLogged() {
    this._cuentaService.getCuenta1().subscribe(user => {
      console.log(user);
    })
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }

}

export interface ListaOrden {
  id: number,
  clienteId: number
}
