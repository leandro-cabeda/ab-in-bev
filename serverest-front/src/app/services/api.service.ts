import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map, switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://serverest.dev'; // servidor online
  private token: string = '';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<any> {
    return this.http.get(`${this.baseUrl}/usuarios`);
  }

  createUser(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/usuarios`, user);
  }

  private authenticate(): Observable<string> {
    return this.http.post<any>(`${this.baseUrl}/login`, {
      email: "fulano@qa.com",
      password: "teste"
    }).pipe(
      map(response => {
        this.token = response.authorization;
        return this.token;
      })
    );
  }


  getProducts(): Observable<any> {
    return this.authenticate().pipe(
      switchMap(token => {
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
        return this.http.get(`${this.baseUrl}/produtos`, { headers });
      })
    );
  }
}
