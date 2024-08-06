import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserStorageService } from './core/Services/Auth/browserstorage.service';
import { BrowserStorageServerService } from './core/Services/Auth/browserstorageservice.service';
import { provideToastr } from 'ngx-toastr';
import { httpInterceptor } from './core/interceptors/http.interceptor';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideHttpClient(withInterceptors([httpInterceptor])),provideToastr(),importProvidersFrom(BrowserAnimationsModule),{provide:BrowserStorageService,useClass:BrowserStorageServerService}]
};
