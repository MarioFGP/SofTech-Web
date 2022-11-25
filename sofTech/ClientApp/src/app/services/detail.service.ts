import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, tap, catchError } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Detail } from '../softech/models/detail';

@Injectable({
  providedIn: 'root'
})
export class DetailService {

  baseUrl: string
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)     
    {
      this.baseUrl = baseUrl;
    }

  get(): Observable<Detail[]>{
    return this.http.get<Detail[]>(this.baseUrl + 'api/Detail').pipe(
      tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Detail[]>('Consulta detalle',[]))
    );
  }

  post(detail: Detail): Observable<any> {
    
    return this.http.post<Detail>(this.baseUrl + 'api/Detail', detail)
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.handleError<Detail>('Registrar detalle', new Detail()))
    );
    
  }
}
