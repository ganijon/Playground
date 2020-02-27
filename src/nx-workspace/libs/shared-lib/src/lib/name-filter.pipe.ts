import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nameFilter'
})
export class NameFilterPipe implements PipeTransform {
  transform(list: any[], filterText: string): any[] {
    if (!list) return [];
    if (!filterText) return list;

    return list.filter(item =>
      item.name.toLowerCase().includes(filterText.toLowerCase())
    );
  }
}
