import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
 private userSubject = new BehaviorSubject<any>(null);
  user$ = this.userSubject.asObservable();
  constructor() { 
     const token = localStorage.getItem('token');
    if (token) {
      const user = this.parseJwt(token);
      this.userSubject.next(user);
  }
}   parseJwt(token: string): any {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(
        atob(base64).split('').map(c =>
          '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
        ).join('')
      );
      return JSON.parse(jsonPayload);
    } catch (e) {
      return null;
    }
  }
  login(token: string) {
    localStorage.setItem('token', token);
    const user = this.parseJwt(token);
    this.userSubject.next(user);
  }

  logout() {
    localStorage.removeItem('token');
    this.userSubject.next(null);
  }
}


