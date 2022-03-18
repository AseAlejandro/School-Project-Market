import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router, NavigationExtras } from '@angular/router';
import { MochilaService } from 'src/app/services/mochila/mochila.service';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {
  producto: any;
  cantidad: any = 1;
  precio: any;
  categorias: any[] = [];
  searchText: string ="";
  currentUser: any[] = []
  id: number = 0

  constructor(
    private router : Router,
    private route: ActivatedRoute,
    private _mochilaService: MochilaService,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private tokenStorage: TokenService
  ) { }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.id = this.currentUser[0].id
    this._categoriaService.getCategorias().subscribe(categorias =>
      this.categorias = categorias)
    this.route.params.subscribe((params: Params) => {
      let id: number = +params['id'];
      this._productoService.getProducto(id).subscribe(producto =>
          this.producto = producto)
    })
  }

  addToMochila(){
    this._mochilaService.addToMochila({
      productoId: this.producto.id,
      cantidad: this.cantidad,
      agenteId: this.id,
      clienteId: 1,
      precio: this.producto.precio
    }, this.id).subscribe((response => {
      this.router.navigate(['/mochila']);
    }));
  }
  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }

}
