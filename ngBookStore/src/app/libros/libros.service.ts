import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LibrosService {

  public librosSubject: Subject<unknown> = new Subject();
  private libros = ["Libro 1", "Libro 2", "Libro 3"];

  constructor() { }

  public obtenerLibros(): string[]{
    return this.libros;
  }

  public agregarLibro(libro:string): void {
    this.libros.push(libro);
    this.librosSubject.next();
  }

  public eliminarLibro(libro: string) : void{
    this.libros = this.libros.filter(l => l !== libro);
    this.librosSubject.next();
  }
}
