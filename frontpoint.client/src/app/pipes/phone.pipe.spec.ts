import { PhonePipe } from './phone.pipe';

describe('PhonePipe', () => {
  let service: PhonePipe;
  beforeEach(() => {
    service = new PhonePipe();
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should return empty when invalid number', () => {
    const response = service.transform('123');
    expect(response).toBeFalsy();
  });

  it('should format phone number', () => {
    const response = service.transform('1234567890');
    expect(response).toBe('(123) 456-7890');
  });

  it('should format phone number with extension', () => {
    const response = service.transform('12345678901234');
    expect(response).toBe('(123) 456-7890 x1234');
  });

  it('should extract digits and format phone number', () => {
    const response = service.transform('123-456-7890');
    expect(response).toBe('(123) 456-7890');
  });
});
