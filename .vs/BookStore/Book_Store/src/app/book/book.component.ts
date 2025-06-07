import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service';
import { Book } from '../models/book';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule, Validators, FormBuilder } from '@angular/forms';
declare var bootstrap: any;



@Component({
  selector: 'app-book',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  book: Book[] = [];
  isEditMode: boolean = false; // true for update, false for add


  constructor(private bookService: BookService, private fb: FormBuilder) {

    this.editForm = this.fb.group({
      id: [''],
      title: ['', Validators.required],
      description: [''],
      noOfPages: [''],
      isActive: [''],
      createdOn: [''],
      languageId: [''],
      authorId: [''],

    });

  } // ✅ Inject service in constructor
  editForm!: FormGroup
  ngOnInit(): void {
    this.book
    this.bookService.getAllBooks().subscribe(data => {
      this.book = data;


    });
  }

  openEditModal(book: any) {
    this.editForm.patchValue(book);
    this.isEditMode = true;
    const modalElement = document.getElementById('editModal');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    } else {
      console.error('Modal element not found');
    }
  }
  openAddBookModal() {
    this.isEditMode = false;
    this.editForm.reset(); // clear form for adding new book

    // Set default values (like createdOn and authorId)
    this.editForm.patchValue({
      createdOn: new Date().toISOString(),
      isActive: false,
      authorId: "" // default author
    });

    const modalElement = document.getElementById('editModal');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();

    }
  }

 submitBook() {
  if (this.editForm.valid) {
    const formValue = this.editForm.value;

    // Convert authorId (could be string) to number|null
    let authorId: number | null = null;
    if (formValue.authorId === '' || formValue.authorId == null) {
      authorId = null;
    } else {
      authorId = Number(formValue.authorId);
      if (isNaN(authorId)) {
        authorId = null;
      }
    }

    // Prepare bookData with proper types
    let bookData: Book = {
      ...formValue,
      id: formValue.id ?? 0,
      authorId: authorId,
      languageId: Number(formValue.languageId),
      createdOn:
        formValue.createdOn instanceof Date
          ? formValue.createdOn.toISOString()
          : formValue.createdOn,
    };

    if (this.isEditMode) {
      this.bookService.updateBook(bookData).subscribe(
        (response) => {
          console.log('Book updated:', response);
          const index = this.book.findIndex((b) => b.id === response.id);
          if (index !== -1) {
            this.book[index] = response;
          }
          const modalElement = document.getElementById('editModal');
          if (modalElement) {
            const modal = new bootstrap.Modal(modalElement);
            modal.hide();
          }
        },
        (error) => {
          console.error('Error updating book:', error);
        }
      );
    } else {
      this.bookService.addBook(bookData).subscribe(
        (response) => {
          console.log('Book added:', response);
          if(response.message=="Book added successfully."){
            alert("book addded Succesfully");
          }
          this.book.push(response);
          const modalElement = document.getElementById('editModal');
          if (modalElement) {
            const modal = new bootstrap.Modal(modalElement);
            modal.hide();
          }
        },
        (error) => {
          console.error('Error adding book:', error);
        }
      );
    }
  }
}
DeleteBooks(id:number){
 this.bookService.deletebook(id).subscribe({
  next: () => {
    alert("Book deleted Succesfully")
    // Optionally, refresh the list or update UI
  },
  error: err => {
    console.error('Error deleting book:', err);
  }
});
}
}
