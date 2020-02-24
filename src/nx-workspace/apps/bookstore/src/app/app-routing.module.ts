import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

const appRoutes: Routes = [
  { path: 'books',  loadChildren: () => import('./books/books.module').then(m => m.BooksModule) },
  { path: '',       component: HomeComponent },
  //{ path: '',   redirectTo: '/books', pathMatch: 'full' },
  { path: '**',     component: NotFoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes, 
      {
        enableTracing: false, // <-- debugging purposes only
        preloadingStrategy: PreloadAllModules,
      })
  ],
  exports: [RouterModule],
  entryComponents:[HomeComponent]
})
export class AppRoutingModule {}
