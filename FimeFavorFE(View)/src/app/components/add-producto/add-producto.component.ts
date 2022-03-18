import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-add-producto',
  templateUrl: './add-producto.component.html',
  styleUrls: ['./add-producto.component.css']
})
export class AddProductoComponent implements OnInit {
  searchText: any;
  accion = 'Agregar';
  form!: FormGroup;
  id: number | undefined;
  currentUser: any[] = []
  id2: number = 0
  producto: any[] = []
  
  constructor(
    private toastr: ToastrService,
    private fb: FormBuilder,
    private _productoService: ProductosService,
    private router: Router,
    private route: ActivatedRoute,
    private tokenStorage: TokenService
  ) 
  { 
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      modelo: ['', Validators.required],
      descripcion: ['', Validators.required],
      categoriaId: ['', Validators.required],
      precio: ['', Validators.required],
      existencia: ['1', Validators.required],
      vendedorId: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.id2 = this.currentUser[0].id
    this.route.params.subscribe(params=> {
      if("id" in params) {
        let id: number =+ params["id"];
        this._productoService.getProducto(id).subscribe(producto => {
          this.producto = producto
          console.log(producto)
          this.form = this.fb.group({
            id: producto.id,
            nombre: producto.nombre,
            modelo: producto.modelo,
            descripcion: producto.descripcion,
            categoriaId: producto.categoriaId,
            precio: producto.precio,
            existencia: producto.existencia,
            vendedorId: this.id2,
            imagen: producto.imagen
          })
        })
      }
    })
  }

  guardarProducto() {
    const producto: any = {
      id: this.form.get('id')?.value,
      nombre: this.form.get('nombre')?.value,
      modelo: this.form.get('modelo')?.value,
      descripcion: this.form.get('descripcion')?.value,
      categoriaId: this.form.get('categoriaId')?.value,
      precio: this.form.get('precio')?.value,
      existencia: this.form.get('existencia')?.value,
      vendedorId: this.id2,
      imagen: this.form.get('imagen')?.value
    }
    console.log(producto)
    if(producto.id == undefined){
      this._productoService.addProducto(producto).subscribe(data => {
        this.toastr.success('El producto se registro con exito!', 'Producto registrado');
        this.form.reset();
      }, error =>{
        this.toastr.error('Opss.. ocurrio un error','Error')
        console.log(error);
      })
    } else {
      this.accion = 'Editar'
      console.log(producto)
      this._productoService.modifyProducto(producto.id, producto).subscribe(data=> {
        this.form.reset();
        this.accion = 'Agregar';
        this.id = undefined;
        this.toastr.info('El producto fue actualizado con exito!', 'Producto Actualizado');
      }, error => {
        console.log(error);
      })
    }
  }

  editarProducto(producto: any) {
    this.accion = 'Editar';
    this.id = producto.id;

    this.form.patchValue({
      folioComhaf: producto.folioComhaf,
      nombre: producto.nombre,
      modelo: producto.modelo,
      descripcion: producto.descripcion,
      categoriaId: producto.categoriaId,
      precio: producto.precio,
      existencia: producto.existencia,
      vendedorId: producto.vendedorId
    })
  }
  
  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/productosVendedor'], navigationExtras);
  }
}
