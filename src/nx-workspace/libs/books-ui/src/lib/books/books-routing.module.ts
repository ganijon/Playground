import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './book-list/book-list.component';
import { BookDetailComponent } from './book-detail/book-detail.component';

const booksRoutes: Routes = [
  { path: '', component: BookListComponent },
  { path: ':id', component: BookDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(booksRoutes)],
  exports: [RouterModule]
})
export class BooksRoutingModule {}
