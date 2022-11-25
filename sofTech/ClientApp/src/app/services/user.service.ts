import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, tap, catchError } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { User } from '../softech/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)     
    {
      this.baseUrl = baseUrl;
    }

  get(): Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl + 'api/User').pipe(
      tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<User[]>('Consulta usuario',[]))
    );
  }

  post(user: User): Observable<any> {
    
    return this.http.post<User>(this.baseUrl + 'api/User', user)
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.handleError<User>('Registrar articulo', new User()))
    );
    
  }

  
}
