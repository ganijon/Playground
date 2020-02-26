import { Book } from 'libs/books-ui/src/lib/books/book';

//import { Book } from '@nx-playground/books-ui/Book';

//import { Book } from '@nx-playground/books-ui';

export interface Author {
  id: string;
  name: string;
  books: Book[];
}
