import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, tap, catchError } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Invoice } from '../softech/models/invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  baseUrl: string
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)     
    {
      this.baseUrl = baseUrl;
    }

  get(): Observable<Invoice[]>{
    return this.http.get<Invoice[]>(this.baseUrl + 'api/Invoice').pipe(
      tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Invoice[]>('Consulta Facturas',[]))
    );
  }

  post(person: Invoice): Observable<any> {
    
    return this.http.post<Invoice>(this.baseUrl + 'api/Invoice', person)
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.handleError<Invoice>('Registrar Factura', new Invoice()))
    );
    
  }

  
}
