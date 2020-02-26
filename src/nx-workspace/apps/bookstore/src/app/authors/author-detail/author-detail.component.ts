import { switchMap } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { Author } from '../author';
import { AuthorService } from '../author.service';

@Component({
  selector: 'nx-playground-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.scss']
})
export class AuthorDetailComponent implements OnInit {
  author$: Observable<Author>;

  constructor(
    private service: AuthorService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.author$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => this.service.getAuthor(params.get('id')))
    );
  }

  gotoAuthors(author: Author) {
    const authorId = author ? author.id : null;
    // Pass along the hero id if available
    // so that the AuthorList component can select that hero.
    // Include a junk 'foo' property for fun.
    this.router.navigate(['/authors', { id: authorId, foo: 'foo' }]);
  }
}
