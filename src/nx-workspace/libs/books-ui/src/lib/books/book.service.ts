import { Injectable } from '@angular/core';
import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { Book } from './book';

const BOOKS_QUERY = gql`
  query Books($name: String) {
    books(name: $name) {
      id
      name
      genre
      author {
        name
      }
    }
  }
`;

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private books$: Observable<Book[]>;
  private query: QueryRef<Book[]>;

  constructor(private apollo: Apollo) {
    this.query = this.apollo.watchQuery({
      query: BOOKS_QUERY,
      variables: { name: '' }
    });

    this.books$ = this.query.valueChanges.pipe(
      map(result => result.data && result.data['books'])
    );
  }

  search(searchTerm: string) {
    this.query.refetch({ name: searchTerm });
  }

  getBook(bookId: string) {
    return this.books$.pipe(
      map((books: Book[]) => books.find(b => b.id === bookId))
    );
  }

  getBooks() {
    this.query.refetch();
    return this.books$.pipe();
  }
}
