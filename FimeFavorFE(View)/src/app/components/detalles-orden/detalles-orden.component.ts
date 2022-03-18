import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Params, Router } from '@angular/router';
import { animate, state, style, transition, trigger} from '@angular/animations';
import { OrdenService } from 'src/app/services/orden/orden.service';

@Component({
  selector: 'app-detalles-orden',
  templateUrl: './detalles-orden.component.html',
  styleUrls: ['./detalles-orden.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class DetallesOrdenComponent implements OnInit {
  orden: any;
  Detalles: ordenDetalles[] = []
  displayedColumns: string[] = ["nombre", "modelo", "descripcion", "precio", "cantidad", "costoTotal"]
  searchText: string = "";

  constructor(
    private router: Router,
    private _route: ActivatedRoute,
    private _ordenService: OrdenService
  ) { }

  ngOnInit(): void {
    this._route.params.subscribe((params: Params) => {
      let id: number = +params['id'];
      this._ordenService.getOrdenConDetalle(id).subscribe(orden =>
        this.orden = orden)
      this._ordenService.getOrdenConDetalle(id).subscribe(detalles =>
        this.Detalles = detalles.orderDetails)
    })
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }

}

export interface ordenDetalles {
  nombre: string;
  modelo: string;
  descripcion: string;
  precio: number;
  cantidad: number;
  costoTotal: number;
}
