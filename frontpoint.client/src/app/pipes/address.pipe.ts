import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'address',
  standalone: true,
})
export class AddressPipe implements PipeTransform {
  transform(value: {
    addressLine1: string | undefined;
    addressLine2?: string;
    city: string | undefined;
    state: string | undefined;
    zip: string | undefined;
    country: string | undefined;
  }): string {
    return [
      value.addressLine1,
      value.addressLine2,
      `${value.city}, ${value.state} ${value.zip}`,
      value.country,
    ]
      .filter((x) => x)
      .join('\n');
  }
}
