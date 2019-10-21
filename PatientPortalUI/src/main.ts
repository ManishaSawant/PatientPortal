import { PatientModule } from './app/Patient/patient.module';
import { PatientComponent } from './app/Patient/patient.component';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(PatientModule)
//platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
