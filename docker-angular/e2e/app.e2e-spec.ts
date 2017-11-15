import { DockerAngularPage } from './app.po';

describe('docker-angular App', function() {
  let page: DockerAngularPage;

  beforeEach(() => {
    page = new DockerAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
