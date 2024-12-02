import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config'; // Assuming appConfig is imported

bootstrapApplication(AppComponent, {
  ...appConfig, // Spread appConfig properties
  providers: [
    ...(appConfig.providers || []), // Ensure existing providers are included
    provideHttpClient(withFetch()), // Add HttpClient with fetch configuration
  ],
}).catch((err) => console.error(err));
