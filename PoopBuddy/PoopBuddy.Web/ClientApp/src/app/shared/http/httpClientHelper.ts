import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface IHttpClientHelper {
  get<TResponse>(address: string, onResponse: (response: TResponse) => void) : void;
  post<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void;
  put<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void;
  delete<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void;
}

@Injectable({
  providedIn: 'root',
})
export class HttpClientHelper implements IHttpClientHelper{
  
  constructor(private httpClient: HttpClient) {
  }

  get<TResponse>(address: string, onResponse: (response: TResponse) => void) : void {
    this.httpClient.get<TResponse>(address).subscribe((data: TResponse) => {
      onResponse(data);
    });
  }

  post<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void{
    this.httpClient.post<TResponse>(address, request).subscribe(onResponse);
  }

  put<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void{
    this.httpClient.put<TResponse>(address, request).subscribe(onResponse);
  }

  delete<TRequest, TResponse>(request: TRequest, address: string, onResponse: (response: TResponse) => void) : void{
    this.httpClient.delete<TResponse>(address, request).subscribe(onResponse);
  }

}
