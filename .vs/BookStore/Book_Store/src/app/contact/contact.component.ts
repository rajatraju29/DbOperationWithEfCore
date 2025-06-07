import { Component,OnInit  } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-contact',
  imports: [ReactiveFormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {
contactForm!:FormGroup;

constructor(private fb:FormBuilder,private bookService: BookService,){}
ngOnInit(){
  this.contactForm=this.fb.group({
    name:[''],
    email:[''],
    message:['']
  })
}

add(){
  if(this.contactForm.valid){
    debugger
    const formdata= this.contactForm.value;
    this.bookService.addContact(formdata).subscribe({
      next:(res)=>{
        console.log("Message sent successfully:", res);
        this.contactForm.reset();
      }
    })
    console.log("SendMsg",this.contactForm.value)
  }
}
}
