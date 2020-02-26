import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthorsRoutingModule } from './authors-routing.module';
import { AuthorsComponent } from './authors.component';
import { AuthorListComponent } from './author-list/author-list.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    AuthorsRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatListModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [AuthorsComponent, AuthorListComponent, AuthorDetailComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthorsModule {}
