import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  usuarioNombre: string = '';
  usuarios: string[] = ["Daniela", "Jose", "Juan", "Pedro"];
  visible: boolean = false;

  constructor() {

    setTimeout(() => {
      this.visible = true;
    }, 3000);
  }

  ngOnInit(): void {
  }

  onAgregarUsuario(){
    this.usuarios.push(this.usuarioNombre);
  }
}
