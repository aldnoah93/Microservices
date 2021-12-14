import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { SeguridadService } from 'src/app/seguridad/services/seguridad.service';

@Component({
  selector: 'app-barra',
  templateUrl: './barra.component.html',
  styleUrls: ['./barra.component.css']
})
export class BarraComponent implements OnInit, OnDestroy {
  @Output() menuToggle = new EventEmitter();
  $seguridadCambioSubscription: Subscription | undefined;
  estadoUsuario: boolean = false;
  constructor(private seguridad: SeguridadService) {}
  ngOnDestroy(): void {
    this.$seguridadCambioSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.$seguridadCambioSubscription = this.seguridad.seguridadCambio.subscribe(status => {
      this.estadoUsuario = status;
    });
  }

  onClick(): void {
    this.menuToggle.emit();
  }

  cerrarSesion():void {
    this.seguridad.salirSesion();
  }

}
