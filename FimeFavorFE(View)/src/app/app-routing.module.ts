import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { AddCuentaComponent } from './components/add-cuenta/add-cuenta.component';
import { LoginComponent } from './components/login/login.component';
import { MercadoComponent } from './components/mercado/mercado.component';
import { InicioVendedorComponent } from './components/inicio-vendedor/inicio-vendedor.component';
import { ProductosVendedorComponent } from './components/productos-vendedor/productos-vendedor.component';
import { AddProductoComponent } from './components/add-producto/add-producto.component';
import { MochilaComponent } from './components/mochila/mochila.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { EsperaPedidoComponent } from './components/espera-pedido/espera-pedido.component';
import { InicioRepartidorComponent } from './components/inicio-repartidor/inicio-repartidor.component';
import { ResenasComponent } from './components/resenas/resenas.component';
import { ProductoComponent } from './components/producto/producto.component';
import { DetallesOrdenComponent } from './components/detalles-orden/detalles-orden.component';
import { AddResenaComponent } from './components/add-resena/add-resena.component';
import { PreguntasComponent } from './components/preguntas/preguntas.component';
import { SeleccionComponent } from './components/seleccion/seleccion.component';
import { OrdenesAceptadasComponent } from './components/ordenes-aceptadas/ordenes-aceptadas.component';

const routes: Routes = [{
  path: '',
  redirectTo: 'home',
  pathMatch: 'full'
},
{ path: 'categorias', component: CategoriaComponent},
{ path: 'register', component: AddCuentaComponent},
{ path: 'login', component: LoginComponent},
{ path: 'mercado', component: MercadoComponent},
{ path: 'mercado/:id', component: MercadoComponent},
{ path: 'inicioVendedor', component: InicioVendedorComponent},
{ path: 'productosVendedor', component: ProductosVendedorComponent},
{ path: 'addProducto', component: AddProductoComponent},
{ path: 'addProducto/:id', component: AddProductoComponent},
{ path: 'mochila', component: MochilaComponent},
{ path: 'checkout', component: CheckoutComponent},
{ path: 'espera', component: EsperaPedidoComponent},
{ path: 'inicioRepartidor', component: InicioRepartidorComponent},
{ path: 'resenas', component: ResenasComponent},
{ path: 'producto/:id', component: ProductoComponent},
{ path: 'orden/:id', component: DetallesOrdenComponent},
{ path: 'addResenas', component: AddResenaComponent},
{ path: 'preguntas', component: PreguntasComponent},
{ path: 'seleccion', component: SeleccionComponent},
{ path: 'ordenesAceptadas', component: OrdenesAceptadasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routedComponents = [CategoriaComponent, AddCuentaComponent, LoginComponent, MercadoComponent, InicioVendedorComponent,
                                ProductosVendedorComponent, AddProductoComponent, MochilaComponent, CheckoutComponent, EsperaPedidoComponent,
                                InicioRepartidorComponent, ResenasComponent, ProductoComponent, DetallesOrdenComponent, AddResenaComponent,
                                PreguntasComponent, SeleccionComponent, OrdenesAceptadasComponent]
