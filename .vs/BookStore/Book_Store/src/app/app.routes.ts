import { Routes } from '@angular/router';
import { BookComponent } from './book/book.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomepageComponent } from './homepage/homepage.component';
import { AuthGuard } from './auth.guard';
import { ContactComponent } from './contact/contact.component';

export const routes: Routes = [
   { path: 'books', component: BookComponent,canActivate: [AuthGuard] },
   { path: 'login', component: LoginComponent },
      { path: 'dashboard', component: DashboardComponent },
        { path: 'home', component: HomepageComponent }, 
           { path: 'contact', component: ContactComponent }, // Add route for homepage

  // optional default route
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  // wildcard route (optional)
 // { path: '**', redirectTo: '/books' }
];
