import { Injectable } from '@angular/core';
import { Books } from './books.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  private _books: Books[] = [
    { libroId: 1, titulo: "Algoritmos", descripcion: "Libro basico", autor: "Vaxi Drez", precio: 10},
    { libroId: 2, titulo: "Angular", descripcion: "Libro basico", autor: "Heli Arcila", precio: 25},
  ];

  constructor() { }

  get books() {
    return this._books.slice();
  }
}
