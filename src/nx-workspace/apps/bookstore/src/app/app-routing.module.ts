import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

const appRoutes: Routes = [
  {
    path: 'authors',
    loadChildren: () =>
      import('./authors/authors.module').then(m => m.AuthorsModule)
  },
  {
    path: 'books',
    loadChildren: () =>
      import('@nx-playground/books-ui').then(m => m.BooksUiModule)
  },
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, {
      enableTracing: false, // <-- debugging purposes only
      preloadingStrategy: PreloadAllModules
    })
  ],
  exports: [RouterModule],
  entryComponents: [HomeComponent]
})
export class AppRoutingModule {}
