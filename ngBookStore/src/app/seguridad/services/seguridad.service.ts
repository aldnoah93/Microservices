import { Injectable } from '@angular/core';
import { LoginData } from '../models/login.model';
import { Usuario } from '../models/usuario.model';

@Injectable({
  providedIn: 'root',
})
export class SeguridadService {
  private usuario?: Usuario;

  constructor() {}

  registrarUsuario(usuario: Usuario) {
    this.usuario = {
      ...usuario,
      id: Math.round(Math.random() * 10000).toString(),
    };
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
  }

  salirSesion() {
    this.usuario = undefined;
  }

  obtenerUsuario() {
    return { ...this.usuario };
  }
}
