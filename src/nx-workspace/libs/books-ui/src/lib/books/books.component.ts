import { Component, OnInit } from '@angular/core';
import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag';
import { Book } from './book';
import { FormControl } from '@angular/forms';

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

@Component({
  selector: 'nx-playground-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];
  searchTerm = new FormControl();

  private query: QueryRef<Book[]>;

  constructor(private apollo: Apollo) {}

  ngOnInit() {
    this.query = this.apollo.watchQuery({
      query: BOOKS_QUERY,
      variables: { name: '' }
    });

    this.query.valueChanges.subscribe(result => {
      this.books = result.data && result.data['books'];
    });
  }

  onSearch() {
    this.query.refetch({ name: this.searchTerm.value });
  }
}
