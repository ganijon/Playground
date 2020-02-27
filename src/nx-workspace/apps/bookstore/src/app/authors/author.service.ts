import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag';

import { Author } from './author';

const AUTHORS_QUERY = gql`
  query authors($name: String) {
    authors(name: $name) {
      id
      name
      books {
        id
        name
      }
    }
  }
`;

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private authors$: Observable<Author[]>;
  private query: QueryRef<Author[]>;

  constructor(private apollo: Apollo) {
    this.query = this.apollo.watchQuery({
      query: AUTHORS_QUERY,
      variables: { name: '' }
    });

    this.authors$ = this.query.valueChanges.pipe(
      map(result => result.data && result.data['authors'])
    );
  }

  getAuthors() {
    this.query.refetch();
    return this.authors$.pipe();
  }

  getAuthor(authorId: string) {
    return this.authors$.pipe(
      map((authors: Author[]) => authors.find(a => a.id === authorId))
    );
  }

  search(searchTerm: string) {
    this.query.refetch({ name: searchTerm });
  }
}
