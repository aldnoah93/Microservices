import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { SeguridadService } from "./services/seguridad.service";
@Injectable({providedIn: "root"})
export class SeguridadRouter implements CanActivate {
  constructor(private seguridad: SeguridadService, private router: Router){}
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(this.seguridad.onSesion()){
      return true;
    }
    this.router.navigate(["/login"]);
    return false;
  }

}
