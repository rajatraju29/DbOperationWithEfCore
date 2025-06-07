import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule,FormBuilder,Validators,FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AuthServiceService } from './auth-service.service';
import { Subscription } from 'rxjs';
import { BookService } from './services/book.service';
declare var bootstrap: any;

interface JwtPayload {
  sub: string;
  email?: string;
  name?: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, FormsModule, CommonModule,ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // ✅ Fixed typo (was styleUrl)
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Book_Store';
  username: string | null = null;
  isLoggedIn: boolean = false;
  Profiledetails: any = null;

  private userSub!: Subscription;

  constructor(private authService: AuthServiceService,private bookService: BookService,private fb:FormBuilder) {}
 profiledataForm!: FormGroup;
  ngOnInit(): void {
 this.createform();
  this.username = localStorage.getItem('username') || '';
    this.userSub = this.authService.user$.subscribe(user => {
      this.isLoggedIn = !!user;
      this.username =
        user?.['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] ||
        user?.username ||
        null;
    });
  }
  createform():void{
    this.profiledataForm=this.fb.group({
      username:[''],
      name:[''],
      mobile:[''],
      address:[''],
      city:[''],
     // email:['']

    })
   }
  logout(): void {
    this.authService.logout();
    window.location.href = '/login';
  }

  ngOnDestroy(): void {
    this.userSub?.unsubscribe();
  }

   loadProfileDetails(): void {
    debugger
    if (!this.username) {
    console.warn('Username is not set.');
    return;
  }
    this.bookService.getProfileDetailsByUsername(this.username).subscribe(data => {
     if (data && data.length > 0) {
        this.Profiledetails = data[0];
            this.profiledataForm.patchValue(this.Profiledetails);
            this.profiledataForm.get('username')?.disable();
        this.openModal(); // Open modal after loading data
      }
    }, error => {
      console.error('Error fetching books:', error);
    });
  }
  openModal(): void {
    const modalElement = document.getElementById('profileModal');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    }
  }
  updateProfile(){
    debugger
if(this.profiledataForm.valid){
  const data=this.profiledataForm.getRawValue();
  console.log('updateprofile',data);
  this.bookService.UpdateProfile(data).subscribe({
      next: (res) => {
        alert('Profile updated successfully!');
      },
      error: (err) => {
        console.error('Update failed:', err);
        alert('Error updating profile.');
      }
    });
  
}
  }
}


