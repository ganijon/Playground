import { Component, OnInit } from '@angular/core';
import { switchMap } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

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
  selectedId: number;
  searchTerm = new FormControl();

  constructor(private service: AuthorService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.authors$ = this.route.paramMap.pipe(
      switchMap(params => {
        this.selectedId = +params.get('id');
        return this.service.authorList$;
      })
    );
  }

  onSearch() {
    this.service.search(this.searchTerm.value);
  }
}
