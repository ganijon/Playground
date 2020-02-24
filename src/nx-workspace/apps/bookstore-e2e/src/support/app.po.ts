export const getGreeting = () => cy.get('h1');
export const getBooks = () => cy.get('li.books');
export const getAddBookButton = () => cy.get('button#add-book');