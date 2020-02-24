import { getGreeting } from '../support/app.po';
import { getBooks } from '../support/app.po';
import { getAddBookButton } from '../support/app.po';

describe('bookstore', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    // Custom command example, see `../support/commands.ts` file
    cy.login('my-email@something.com', 'myPassword');

    // Function helper example, see `../support/app.po.ts` file
    getGreeting().contains('Welcome to bookstore!');
  });

  it('should display books', () => {
    getBooks().should(b => expect(b.length).equal(2));
    getAddBookButton().click();
    getBooks().should(b => expect(b.length).equal(3));
  });
});
