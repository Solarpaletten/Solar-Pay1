import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map, throwError } from 'rxjs';
import { TokenService } from '../Services/Auth/token.service';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);
console.log(`Request is on it's way to ${req.url}`);
  tokenService.isAuthentication.subscribe({
    next: (value) => {
      if (value) {
        req = req.clone({
          setHeaders: {
            Authorization: `Bearer ${tokenService.getToken()}`,
          },
        });
      }
    },
  });

  return next(req).pipe(
    catchError((e: HttpErrorResponse) => {
        console.log("Error Status: ",e.status);
      if (e.status === 401 || e.status==404) {
        tokenService.removeToken();
        router.navigate(['']);
      }
      const error = e.error?.error?.message || e.statusText;
      return throwError(() => error);
    })
  );
};