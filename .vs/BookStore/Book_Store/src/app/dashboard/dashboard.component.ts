import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service';
import { FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
declare var bootstrap: any;

@Component({
  selector: 'app-dashboard',
    imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  totalbook: any[] = []; 
  Recentbook: any[] = []; 
  books:any[]=[];
  // Define the book array

  constructor(private bookService: BookService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.loadBooks();
    this.recentUser();
  }

  loadBooks(): void {
    this.bookService.getallusers().subscribe(data => {
      this.totalbook = data;
    }, error => {
      console.error('Error fetching books:', error);
    });
  }
  recentUser():void{
    this.bookService.recentaddbook().subscribe(data=>{
      this.Recentbook=data;
      
    },error=>{
      console.error('not getting');
    }
  )
  }

   getBooksThisMonth(): void {
  
      this.bookService.getthisMonth().subscribe(data=>{
        this.books=data;
             const modalElement = document.getElementById('booksModal');
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      })
  }
}
