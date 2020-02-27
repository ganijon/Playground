import { Component, OnInit } from '@angular/core';

import { AuthorService } from '../author.service';
import { Author } from '../author';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'nx-playground-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.scss']
})
export class AuthorListComponent implements OnInit {
  authors$: Observable<Author[]>;
  searchTerm = new FormControl();

  constructor(private service: AuthorService) {}

  ngOnInit() {
    this.authors$ = this.service.getAuthors();
  }

  onSearch() {
    this.service.search(this.searchTerm.value);
  }
}
