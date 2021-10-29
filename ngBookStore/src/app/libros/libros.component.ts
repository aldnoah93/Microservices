import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { LibrosService } from './libros.service';

@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})
export class LibrosComponent implements OnInit, OnDestroy {

  libros!: string[];
  private librosSubscription!: Subscription;

  constructor(private librosService: LibrosService) {
  }
  ngOnDestroy(): void {
    this.librosSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.libros = this.librosService.obtenerLibros();
    this.librosSubscription = this.librosService.librosSubject.subscribe(()=>{
      this.libros = this.librosService.obtenerLibros();
    });

  }

  guardarLibro(f:NgForm) : void {
    if(f.valid){
      this.librosService.agregarLibro(f.value.nombreLibro);
    }
  }

  eliminarLibro(libro: string) : void{
    this.librosService.eliminarLibro(libro);
  }
}
