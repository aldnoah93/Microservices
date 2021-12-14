import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { SeguridadService } from 'src/app/seguridad/services/seguridad.service';

@Component({
  selector: 'app-menu-lista',
  templateUrl: './menu-lista.component.html',
  styleUrls: ['./menu-lista.component.css'],
})
export class MenuListaComponent implements OnInit, OnDestroy {
  @Output() menuToggle = new EventEmitter();
  $seguridadCambioSubscription: Subscription | undefined;
  estadoUsuario: boolean = false;
  constructor(private seguridad: SeguridadService) {}
  ngOnDestroy(): void {
    this.$seguridadCambioSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.$seguridadCambioSubscription = this.seguridad.seguridadCambio.subscribe(status=>{
      this.estadoUsuario = status;
    })
  }

  onClick(): void {
    this.menuToggle.emit();
  }

  salir(): void{
    this.seguridad.salirSesion();
    this.menuToggle.emit();
  }
}
