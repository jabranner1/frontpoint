import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'name',
  standalone: true,
})
export class NamePipe implements PipeTransform {
  transform(value: {
    prefix?: string;
    first: string | undefined;
    middle?: string;
    last: string | undefined;
  }): string {
    return [value.prefix, value.first, value.middle, value.last]
      .filter((x) => x)
      .join(' ');
  }
}
