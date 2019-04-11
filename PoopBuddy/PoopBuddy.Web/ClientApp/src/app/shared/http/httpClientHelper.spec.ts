import { TestBed, getTestBed} from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClientHelper } from './httpClientHelper';



export class DummyType {
  index: number;
  name: string;
}


describe("HttpClientHelper", () => {
  let injector: TestBed;
  let httpClientHelper: HttpClientHelper;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [HttpClientHelper]
    });

    injector = getTestBed();
    httpClientHelper = injector.get(HttpClientHelper);
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should pass proper object on callback',
    () => {
      console.log('test begin');
      var dummyResponse = new DummyType();
      dummyResponse.index = 1;
      dummyResponse.name = 'test';

      var address = "http://localhost/test";
      httpClientHelper.get<DummyType>(address,
        (response) => {
          expect(response.index).toBe(1);
          expect(response.name).toBe('test');
        });

      const req = httpMock.expectOne(address);
      expect(req.request.method).toBe('GET');
      req.flush(dummyResponse);

    });
});
