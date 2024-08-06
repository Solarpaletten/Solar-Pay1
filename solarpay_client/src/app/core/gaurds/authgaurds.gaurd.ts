import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { TokenService } from '../Services/Auth/token.service';

export const AuthGaurds: CanActivateFn = (route, state) =>  {
  const tokenService = inject(TokenService);
  const router = inject(Router);

  tokenService.isAuthentication.subscribe({
    next: (value) => {
      if (!value) {
        router.navigate(['']);
      }
    },
  });

  return true;
}
