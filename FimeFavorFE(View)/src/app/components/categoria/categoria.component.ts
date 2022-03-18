import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class CategoriaComponent implements OnInit {
  categorias: any[] = [];
  header: string = "";
  categoria: any;
  displayedColumns: string[] = ['id', 'categoriaNombre'];
  searchText: string = "";
  expandedElement: ListaCategorias | null | undefined;

  constructor(
    private _categoriaService: CategoriaService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.header = "Categorias"
    this._categoriaService.getCategorias().subscribe(categorias =>
      console.log(categorias));
  }

}

export interface ListaCategorias{
  id: number,
  categoriaNombre: string
}
