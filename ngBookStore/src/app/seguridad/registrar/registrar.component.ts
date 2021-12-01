import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from '../models/usuario.model';
import { SeguridadService } from '../services/seguridad.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css'],
})
export class RegistrarComponent implements OnInit {
  constructor(private seguridadService: SeguridadService) {}

  ngOnInit(): void {}

  guardarUsuario(f: NgForm): void {
    const usuario: Usuario = {
      nombre: f.value.name as string,
      apellidos: f.value.lastname as string,
      username: f.value.username as string,
      password: f.value.password as string,
      email: f.value.email as string,
      id: ''
    }
    this.seguridadService.registrarUsuario(usuario);
  }
}
