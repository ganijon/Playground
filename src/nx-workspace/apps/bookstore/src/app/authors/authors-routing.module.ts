import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorsComponent } from './authors.component';

const authorsRoutes: Routes = [
  {
    path: '',
    component: AuthorsComponent,
    data: { animation: 'authors' }
  },
  {
    path: ':id',
    component: AuthorsComponent,
    data: { animation: 'authors' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(authorsRoutes)],
  exports: [RouterModule]
})
export class AuthorsRoutingModule {}
