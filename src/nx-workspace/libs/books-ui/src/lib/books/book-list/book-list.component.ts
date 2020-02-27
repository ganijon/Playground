import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Book } from '../book';
import { BookService } from '../book.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'nx-playground-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {
  books$: Observable<Book[]>;
  searchTerm: FormControl;

  constructor(private service: BookService) {}

  ngOnInit(): void {
    this.books$ = this.service.getBooks();
  }

  onSearch() {
    this.service.search(this.searchTerm.value);
  }
}
