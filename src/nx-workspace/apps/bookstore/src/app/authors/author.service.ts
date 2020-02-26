import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag';

import { Author } from './author';
import { map } from 'rxjs/operators';

const AUTHOR_LIST_QUERY = gql`
  query authors($name: String) {
    authors(name: $name) {
      id
      name
      books {
        name
      }
    }
  }
`;

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  authorList$: Observable<Author[]>;

  private queryList: QueryRef<Author[]>;

  constructor(private apollo: Apollo) {
    this.queryList = this.apollo.watchQuery({
      query: AUTHOR_LIST_QUERY,
      variables: { name: '' }
    });

    this.authorList$ = this.queryList.valueChanges.pipe(
      map(result => result.data && result.data['authors'])
    );
  }

  getAuthor(authorId: string) {
    return this.authorList$.pipe(
      map((authors: Author[]) => authors.find(author => author.id === authorId))
    );
  }

  search(searchTerm: string) {
    this.queryList.refetch({ name: searchTerm });
  }
}
