import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { LoginData } from '../models/login.model';
import { Usuario } from '../models/usuario.model';

@Injectable({
  providedIn: 'root',
})
export class SeguridadService {
  private usuario?: Usuario;

  public seguridadCambio = new Subject<boolean>();

  constructor(private router: Router) {}

  registrarUsuario(usuario: Usuario) {
    this.usuario = {
      ...usuario,
      id: Math.round(Math.random() * 10000).toString(),
    };
    this.seguridadCambio.next(true);
    this.router.navigate(["/"]);
  }

  login(login: LoginData) {
    this.usuario = {
      ...login,
      nombre: '',
      apellidos: '',
      username: '',
      id: Math.round(Math.random() * 10000).toString(),
      password: ''
    };
    this.seguridadCambio.next(true);
    this.router.navigate(["/"]);
  }

  salirSesion() {
    this.usuario = undefined;
    this.seguridadCambio.next(false);
    this.router.navigate(["/login"]);
  }

  obtenerUsuario() {
    return { ...this.usuario };
  }

  onSesion():boolean {
    return this.usuario != undefined;
  }
}
