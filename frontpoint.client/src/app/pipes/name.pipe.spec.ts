import { NamePipe } from './name.pipe';

describe('NamePipe', () => {
  let service: NamePipe;
  beforeEach(() => {
    service = new NamePipe();
  });

  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should return with first and last', () => {
    const response = service.transform({
      first: 'First',
      last: 'Last',
    });
    expect(response).toBe('First Last');
  });

  it('should return with prefix, first and last', () => {
    const response = service.transform({
      prefix: 'Prefix',
      first: 'First',
      last: 'Last',
    });
    expect(response).toBe('Prefix First Last');
  });

  it('should return with prefix, first, middle and last', () => {
    const response = service.transform({
      prefix: 'Prefix',
      first: 'First',
      middle: 'Middle',
      last: 'Last',
    });
    expect(response).toBe('Prefix First Middle Last');
  });
});
