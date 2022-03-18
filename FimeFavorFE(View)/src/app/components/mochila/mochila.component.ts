import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { MochilaService, MochilaRecord, Cart } from 'src/app/services/mochila/mochila.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-mochila',
  templateUrl: './mochila.component.html',
  styleUrls: ['./mochila.component.css']
})
export class MochilaComponent implements OnInit {
  mochila!: Cart;
  displayedColumns: string[] = ['nombre','modelo','cantidad' ,'precio', 'costoTotal'];
  records: any[] = [];
  searchText: any;
  categorias: any[] = [];
  currentUser: any[] = []
  id: number = 0

  constructor(
    private _mochilaService: MochilaService,
    private router: Router,
    private _categoriaService: CategoriaService,
    private tokenStorage: TokenService
  ) { }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.id = this.currentUser[0].id

    this._mochilaService.getMochila(this.id).subscribe(mochila =>
      this.mochila = mochila);

    this._mochilaService.getMochila(this.id).subscribe(mochila =>
      this.records = mochila);

      this._categoriaService.getCategorias().subscribe(categorias =>
        this.categorias = categorias)
    
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }
}
