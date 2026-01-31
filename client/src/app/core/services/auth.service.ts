import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl = `${environment.apiUrl}/auth`;
    private currentUserSubject = new BehaviorSubject<any>(null);
    public currentUser$ = this.currentUserSubject.asObservable();

    constructor(private http: HttpClient) {
        const user = localStorage.getItem('aura_user');
        if (user) {
            this.currentUserSubject.next(JSON.parse(user));
        }
    }

    login(credentials: any): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/login`, credentials).pipe(
            tap(response => {
                const user = {
                    token: response.token,
                    username: response.username,
                    role: this.decodeTokenRole(response.token)
                };
                localStorage.setItem('aura_user', JSON.stringify(user));
                this.currentUserSubject.next(user);
            })
        );
    }

    logout(): void {
        localStorage.removeItem('aura_user');
        this.currentUserSubject.next(null);
    }

    getToken(): string | null {
        const user = this.currentUserSubject.value;
        return user ? user.token : null;
    }

    getRole(): string | null {
        const user = this.currentUserSubject.value;
        return user ? user.role : null;
    }

    hasRole(roles: string[]): boolean {
        const userRole = this.getRole();
        return userRole ? roles.includes(userRole) : false;
    }

    private decodeTokenRole(token: string): string {
        try {
            const payload = JSON.parse(atob(token.split('.')[1]));
            return payload['role'] || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        } catch (e) {
            return '';
        }
    }
}
