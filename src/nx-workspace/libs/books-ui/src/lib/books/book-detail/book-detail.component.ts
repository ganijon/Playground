import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { BookService } from '../book.service';
import { Book } from '../book';

@Component({
  selector: 'nx-playground-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.scss']
})
export class BookDetailComponent implements OnInit {
  book$: Observable<Book>;

  constructor(
    private service: BookService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.book$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => this.service.getBook(params.get('id')))
    );
  }
}
