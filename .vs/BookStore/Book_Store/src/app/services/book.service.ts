import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book, contact } from '../models/book';
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
  addContact(booknotify:contact):Observable<Book>{
    return this.http.post<Book>(`${this.apiUrl}/savecontactinfo`,booknotify)
  }
  login(Username:string,Password:string):Observable<LoginResponse>{
    const logindata={Username,Password}
    return this.http.post<LoginResponse>("http://localhost:7059/api/Auth/login",logindata)
  }
    addBook(bookData: Book): Observable<Book> {
  return this.http.post<Book>(`${this.apiUrl}/AddNewBookAsync`, bookData);
  }
  updateBook(bookData: Book): Observable<Book> {
  return this.http.put<Book>(`${this.apiUrl}/updateBookAsync/${bookData.id}`, bookData);
}
deletebook(id:number):Observable<any>{
  return this.http.delete(`${this.apiUrl}/DeleteBookasync/${id}`);
}
getallusers(): Observable<Book[]>{
    return this.http.get<Book[]>(`${this.apiUrl}/TotalUsers`);

}
recentaddbook():Observable<Book[]>{
  return this.http.get<Book[]>(`${this.apiUrl}/RecentBook`);
}
getthisMonth():Observable<Book[]>{
  return this.http.get<Book[]>(`${this.apiUrl}/thisMonthbook`);
}
getProfileDetailsByUsername(username: string): Observable<any> {
  
  return this.http.get<any>(`${this.apiUrl}/PrfileDetailsbyUsername?Username=${username}`);
}
UpdateProfile(profile:any):Observable<any>{
  return this.http.post<any>(`${this.apiUrl}/UpdateProfiles`,profile)
}


}
