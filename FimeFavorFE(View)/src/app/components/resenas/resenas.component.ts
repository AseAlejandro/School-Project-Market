import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { ReseñasService } from 'src/app/services/reseñas/resenas.service';
import { CuentaService } from 'src/app/services/cuenta/cuenta.service';

@Component({
  selector: 'app-resenas',
  templateUrl: './resenas.component.html',
  styleUrls: ['./resenas.component.css']
})
export class ResenasComponent implements OnInit {
  productos: any[] = [];
  header: string = "";
  searchText: string ="";
  categorias: any[] = [];
  displayedColumns: string[] = ['cuentaId','descripcion','calificacion'];
  resenas: any[] = []
  idCuenta: number = 1
  nombres: string[] = []

  constructor(
    private route: ActivatedRoute,
    private _cuentaService: CuentaService,
    private _categoriaService: CategoriaService,
    private router: Router,
    private _resenasService: ReseñasService
  ) { }

  ngOnInit(): void {
    this._categoriaService.getCategorias().subscribe(categorias =>
      this.categorias = categorias)

    this._resenasService.getReseñas().subscribe(resenas =>
      this.resenas = resenas)

    this._resenasService.getReseñas().subscribe(resenas =>
      this.idCuenta = resenas.cuentaId)
    
    this._cuentaService.getCuenta("asealejandro0").subscribe(nombres =>
      this.nombres)
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }
}
