import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Usuario, PaginatedResult } from '../_models';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsuarios(page?, itemsPerPage?): Observable<PaginatedResult<Usuario[]>> {
    const paginatedResult: PaginatedResult<Usuario[]> = new PaginatedResult<Usuario[]>();

    let params = new HttpParams();

    if(page != null && itemsPerPage != null){
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    return this.http.get<Usuario[]>(this.baseUrl + 'usuarios', {observe: 'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        })
      );
  }

}
