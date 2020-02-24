import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorsComponent } from './authors.component';

const authorsRoutes: Routes = [{ path: '', component: AuthorsComponent }];

@NgModule({
  imports: [RouterModule.forChild(authorsRoutes)],
  exports: [RouterModule]
})
export class AuthorsRoutingModule {}
