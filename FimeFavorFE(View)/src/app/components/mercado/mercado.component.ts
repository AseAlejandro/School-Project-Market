import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';

@Component({
  selector: 'app-mercado',
  templateUrl: './mercado.component.html',
  styleUrls: ['./mercado.component.css']
})
export class MercadoComponent implements OnInit {
  productos: any[] = [];
  header: string = "";
  searchText: string ="";
  categorias: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this._categoriaService.getCategorias().subscribe(categorias =>
      this.categorias = categorias)
    this.route.queryParams.subscribe(params=> {
      if ("searchText" in params) {
        let searchText: string = params["searchText"];
        this.header = "Buscando: " + searchText;
        this._productoService.searchProducto(searchText).subscribe(productos =>
          this.productos = productos)
        }
        else {
          this.route.params.subscribe(params => {
            switch(true) {
              case ("id" in params):
                let categoriaId: number = +params["id"];
                this._categoriaService.getCategoria(categoriaId).subscribe(categoria=>
                  this.header = categoria.categoriaNombre);
                this._categoriaService.getProductosCategoria(categoriaId).subscribe(productos =>
                  this.productos = productos);
                  break;
              default:
                this.header ="Productos";
                this._productoService.getProductos().subscribe(productos =>
                    this.productos = productos);
            }
          })
        }
      } 
    )
  }
  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }
}
