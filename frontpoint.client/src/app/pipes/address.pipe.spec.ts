import { AddressPipe } from './address.pipe';

describe('AddressPipe', () => {
  let service: AddressPipe;
  beforeEach(() => {
    service = new AddressPipe();
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should return address without line 2', () => {
    const response = service.transform({
      addressLine1: 'Line 1',
      city: 'City',
      state: 'State',
      zip: '12345',
      country: 'Country',
    });
    expect(response).toBe('Line 1\nCity, State 12345\nCountry');
  });

  it('should return address with line 2', () => {
    const response = service.transform({
      addressLine1: 'Line 1',
      addressLine2: 'Line 2',
      city: 'City',
      state: 'State',
      zip: '12345',
      country: 'Country',
    });
    expect(response).toBe('Line 1\nLine 2\nCity, State 12345\nCountry');
  });
});
