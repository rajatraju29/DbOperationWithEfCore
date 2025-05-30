import { Routes } from '@angular/router';
import { BookComponent } from './book/book.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
   { path: 'books', component: BookComponent },
   { path: 'login', component: LoginComponent },
  // optional default route
  { path: '', redirectTo: '/books', pathMatch: 'full' },
  // wildcard route (optional)
 // { path: '**', redirectTo: '/books' }
];
