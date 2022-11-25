import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {catchError, tap, map} from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Person } from '../softech/models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl: string
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)     
    {
      this.baseUrl = baseUrl;
    }

  get(): Observable<Person[]>{
    return this.http.get<Person[]>(this.baseUrl + 'api/Person').pipe(
      tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Person[]>('Consulta Persona',[]))
    );
  }

  post(person: Person): Observable<any> {
    
    return this.http.post<Person>(this.baseUrl + 'api/Person', person)
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.handleError<Person>('Registrar Persona', new Person()))
    );
    
  }
    
}
