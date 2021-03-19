import { Shopping_cartTemplatePage } from './app.po';

describe('Shopping_cart App', function() {
  let page: Shopping_cartTemplatePage;

  beforeEach(() => {
    page = new Shopping_cartTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
