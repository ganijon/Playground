import { Component, OnInit } from '@angular/core';
import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag';
import { Author } from './author';
import { FormControl } from '@angular/forms';

const authors_QUERY = gql`
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

@Component({
  selector: 'nx-playground-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss']
})
export class AuthorsComponent implements OnInit {
  authors: Author[] = [];
  searchTerm = new FormControl();

  private query: QueryRef<Author[]>;

  constructor(private apollo: Apollo) {}

  ngOnInit() {
    this.query = this.apollo.watchQuery({
      query: authors_QUERY,
      variables: { name: '' }
    });

    this.query.valueChanges.subscribe(result => {
      this.authors = result.data && result.data['authors'];
    });
  }

  onSearch() {
    this.query.refetch({ name: this.searchTerm.value });
  }
}
