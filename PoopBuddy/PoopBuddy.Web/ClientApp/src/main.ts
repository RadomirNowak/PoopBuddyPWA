import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from "./app/modules/app/app.module";
import { environment } from './environments/environment';
import { Environment } from './environments/environmentEnum';


if (environment.type === Environment.Production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
