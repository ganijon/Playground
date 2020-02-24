import { async, TestBed } from '@angular/core/testing';
import { BooksUiModule } from './books-ui.module';

describe('BooksUiModule', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [BooksUiModule]
    }).compileComponents();
  }));

  it('should create', () => {
    expect(BooksUiModule).toBeDefined();
  });
});
