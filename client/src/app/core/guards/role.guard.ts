import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const roleGuard: (allowedRoles: string[]) => CanActivateFn = (allowedRoles: string[]) => {
    return () => {
        const authService = inject(AuthService);
        const router = inject(Router);

        if (authService.hasRole(allowedRoles)) {
            return true;
        }

        router.navigate(['/candidates']);
        return false;
    };
};
