import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Article } from '../softech/models/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  baseUrl: string
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)     
    {
      this.baseUrl = baseUrl;
    }

    get(): Observable<Article[]>{
      return this.http.get<Article[]>(this.baseUrl + 'api/Article').pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Article[]>('Consulta articulo',[]))
      );
    }
  
    post(article: Article): Observable<any> {
    
      return this.http.post<Article>(this.baseUrl + 'api/Article', article)
      .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Article>('Registrar articulo', new Article()))
      );
      
    }
}
