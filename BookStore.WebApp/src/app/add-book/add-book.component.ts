import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder } from '@angular/forms'
import { BookService } from '../book.service'

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss'],
})
export class AddBookComponent implements OnInit {
  public bookForm: FormGroup

  constructor(private formBuilder: FormBuilder, private service: BookService) {
    this.bookForm = this.formBuilder.group({
      title: [],
      description: [],
    })
  }

  ngOnInit(): void {
    // this.init()
  }

  public saveBook(): void {
    this.service.addBook(this.bookForm.value).subscribe((result) => {
      alert(`New book add with id = ${result}`)
    })
  }

  private init(): void {
    this.bookForm = this.formBuilder.group({
      title: [],
      description: [],
    })
  }
}
