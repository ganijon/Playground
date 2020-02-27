import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthorService } from '../author.service';
import { Author } from '../author';

@Component({
  selector: 'nx-playground-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.scss']
})
export class AuthorListComponent implements OnInit {
  authors$: Observable<Author[]>;
  searchText: string;

  constructor(private service: AuthorService) {}

  ngOnInit() {
    this.authors$ = this.service.getAuthors();
  }
}
