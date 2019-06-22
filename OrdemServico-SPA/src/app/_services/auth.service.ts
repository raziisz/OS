import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Usuario } from '../_models/index';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUsuario: Usuario;

  constructor(private http: HttpClient) {}
  
  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const usuario = response;
        if (usuario) {
          localStorage.setItem('token', usuario.token);
          localStorage.setItem('usuario', JSON.stringify(usuario.usuario));
          this.decodedToken = this.jwtHelper.decodeToken(usuario.token);
          this.currentUsuario = usuario.usuario;
        }
      })
    );
  }
  registrar(usuario: Usuario) {
    return this.http.post(this.baseUrl + 'registrar', usuario);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
