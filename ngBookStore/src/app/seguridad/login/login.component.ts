import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SeguridadService } from '../services/seguridad.service';
import { LoginData } from '../models/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private seguridadService: SeguridadService) { }

  ngOnInit(): void {
  }

  login(form:NgForm) {
    const loginData: LoginData = {
      email: form.value.email,
      password: form.value.password
    };
    this.seguridadService.login(loginData);
  }

}
