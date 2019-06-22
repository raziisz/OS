import { Injectable } from '@angular/core';
import { Usuario } from '../_models';
import { UsuarioService, AlertifyService } from '../_services';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UsuarioListaResolver implements Resolve<Usuario[]> {
  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Usuario[]> {
    return this.usuarioService.getUsuarios().pipe(
      catchError(error => {
        this.alertify.error('Problema ao recuperar dados');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
