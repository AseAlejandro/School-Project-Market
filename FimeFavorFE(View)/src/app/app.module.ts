import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { LoginComponent } from './components/login/login.component';
import { AddCuentaComponent } from './components/add-cuenta/add-cuenta.component';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MercadoComponent } from './components/mercado/mercado.component';
import { InicioVendedorComponent } from './components/inicio-vendedor/inicio-vendedor.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductosVendedorComponent } from './components/productos-vendedor/productos-vendedor.component';
import { AddProductoComponent } from './components/add-producto/add-producto.component';
import { ToastrModule } from 'ngx-toastr';
import { MochilaComponent } from './components/mochila/mochila.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { EsperaPedidoComponent } from './components/espera-pedido/espera-pedido.component';
import { InicioRepartidorComponent } from './components/inicio-repartidor/inicio-repartidor.component';
import { ResenasComponent } from './components/resenas/resenas.component';
import { ProductoComponent } from './components/producto/producto.component';
import { DetallesOrdenComponent } from './components/detalles-orden/detalles-orden.component';
import { CookieService } from 'ngx-cookie-service';
import { AddResenaComponent } from './components/add-resena/add-resena.component';
import { PreguntasComponent } from './components/preguntas/preguntas.component';
import { SeleccionComponent } from './components/seleccion/seleccion.component';
import { OrdenesAceptadasComponent } from './components/ordenes-aceptadas/ordenes-aceptadas.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoriaComponent,
    LoginComponent,
    AddCuentaComponent,
    MercadoComponent,
    InicioVendedorComponent,
    ProductosVendedorComponent,
    AddProductoComponent,
    MochilaComponent,
    CheckoutComponent,
    EsperaPedidoComponent,
    InicioRepartidorComponent,
    ResenasComponent,
    ProductoComponent,
    DetallesOrdenComponent,
    AddResenaComponent,
    PreguntasComponent,
    SeleccionComponent,
    OrdenesAceptadasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    ToastrModule.forRoot(),
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
