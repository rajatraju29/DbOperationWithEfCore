import { Component,OnInit  } from '@angular/core';
import { BookService } from '../services/book.service';
import { Book } from '../models/book';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-book',
  imports: [CommonModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  book:Book[]=[];
  constructor(private bookService: BookService) {} // ✅ Inject service in constructor

ngOnInit(): void {
  this.book
    this.bookService.getAllBooks().subscribe(data => {
      this.book = data;
    });
  }
}
