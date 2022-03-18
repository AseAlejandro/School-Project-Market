import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-productos-vendedor',
  templateUrl: './productos-vendedor.component.html',
  styleUrls: ['./productos-vendedor.component.css']
})
export class ProductosVendedorComponent implements OnInit {
  productos: any[] = [];
  header: string = "";
  searchText: string ="";
  categorias: any[] = [];
  currentUser: any[] = []
  id: number = 0

  constructor(
    private route: ActivatedRoute,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private router: Router,
      private tokenStorage: TokenService
  ) { }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.id = this.currentUser[0].id
    this._productoService.productosForVendedor(this.id).subscribe(productos =>
      this.productos = productos)
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/productosVendedor'], navigationExtras);
  }

}
