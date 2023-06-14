import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Product } from "./product";


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = "https://localhost:7116/api";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }


  getProduct(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.apiUrl + '/product')
      .pipe(
        catchError(this.errorHandler)
      );
  }


  createProduct(product : any): Observable<Product> {
    return this.httpClient.post<Product>(this.apiUrl + '/product/', JSON.stringify(product), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateProduct(id : any , product:any): Observable<Product> {
    return this.httpClient.put<Product>(this.apiUrl + '/product/' + id, JSON.stringify(product), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteProduct(id: any) {
    return this.httpClient.delete<Product>(this.apiUrl + '/product/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error : any) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }

 
}
