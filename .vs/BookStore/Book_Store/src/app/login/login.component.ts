import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BookService } from '../services/book.service';
import { Router } from '@angular/router';
import { AuthServiceService } from '../auth-service.service';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm!: FormGroup;


  constructor(private fb:FormBuilder,private bookService:BookService,private router:Router,private authService: AuthServiceService){
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
   
 onLogin() {

    const { username, password } = this.loginForm.value;
     if (!username || !password) {
    alert('Username and password are required.');
    return;
  }
    this.bookService.login(username, password).subscribe({
  next: (res) => {
    this.authService.login(res.token);  // 🔁 this updates user$ stream
    alert('Login successful!');
    this.router.navigate(['/dashboard']);
  }
});

  }
 
}


