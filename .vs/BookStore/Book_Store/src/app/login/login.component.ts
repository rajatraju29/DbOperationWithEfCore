import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BookService } from '../services/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm!: FormGroup;


  constructor(private fb:FormBuilder,private bookService:BookService,private router:Router){
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
    username = '';
  password = '';
 onLogin() {
  debugger
    this.bookService.login(this.username, this.password)
      .subscribe({
        next: (res) => {
          localStorage.setItem('token', res.token);
          alert('Login successful!');
          this.router.navigate(['/dashboard']);
        },
        error: () => {
          alert('Invalid username or password.');
        }
      });
  }
 
}


