import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorListComponent } from './author-list/author-list.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';

const authorsRoutes: Routes = [
  {
    path: '',
    component: AuthorListComponent,
    data: { animation: 'authors' }
  },
  {
    path: ':id',
    component: AuthorDetailComponent,
    data: { animation: 'authors' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(authorsRoutes)],
  exports: [RouterModule]
})
export class AuthorsRoutingModule {}
