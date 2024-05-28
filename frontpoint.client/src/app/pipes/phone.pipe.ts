import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone',
  standalone: true,
})
export class PhonePipe implements PipeTransform {
  transform(value: string | undefined): string | null {
    const rawNumber = value?.replace(/[^0-9]/g, '');
    if (!rawNumber || this.isValid(rawNumber)) return null;

    let phone = `(${rawNumber.slice(0, 3)}) ${rawNumber.slice(
      3,
      6,
    )}-${rawNumber.slice(6, 10)}`;

    if (this.isStandardNumber(rawNumber)) return phone;
    return `${phone} x${rawNumber.slice(10)}`;
  }

  private isValid(value: string) {
    return value.length < 10;
  }

  private isStandardNumber(value: string) {
    return value.length === 10;
  }
}
