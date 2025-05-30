import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'http://localhost:7059/api/Books'; 
  

  constructor(private http:HttpClient) { }

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }
  login(Username:string,Password:string):Observable<LoginResponse>{
    const logindata={Username,Password}
    return this.http.post<LoginResponse>("http://localhost:7059/api/Auth/login",logindata)
  }
}
