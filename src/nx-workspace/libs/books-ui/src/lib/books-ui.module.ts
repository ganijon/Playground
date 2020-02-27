import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksRoutingModule } from './books/books-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookListComponent } from './books/book-list/book-list.component';
import { BookService } from './books/book.service';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { SharedLibModule } from '@nx-playground/shared-lib';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    BooksRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    FormsModule,
    ReactiveFormsModule,
    SharedLibModule
  ],
  declarations: [BookListComponent, BookDetailComponent],
  exports: [BookListComponent, BookDetailComponent],
  providers: [BookService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class BooksUiModule {}
