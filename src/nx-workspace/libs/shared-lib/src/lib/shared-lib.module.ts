import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NameFilterPipe } from './name-filter.pipe';

@NgModule({
  imports: [CommonModule],
  exports: [NameFilterPipe],
  declarations: [NameFilterPipe]
})
export class SharedLibModule {}
