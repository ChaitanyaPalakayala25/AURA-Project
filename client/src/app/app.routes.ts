import { Routes } from '@angular/router';
import { roleGuard } from './core/guards/role.guard';

export const routes: Routes = [
    {
        path: 'candidates',
        loadComponent: () => import('./features/candidates/candidate-dashboard.component').then(m => m.CandidateDashboardComponent)
    },
    {
        path: 'candidates/add',
        loadComponent: () => import('./features/candidates/candidate-form.component').then(m => m.CandidateFormComponent),
        canActivate: [roleGuard(['Admin', 'Recruiter'])]
    },
    {
        path: 'candidates/edit/:id',
        loadComponent: () => import('./features/candidates/candidate-form.component').then(m => m.CandidateFormComponent)
    },
    {
        path: 'audit',
        loadComponent: () => import('./features/audit/audit-history.component').then(m => m.AuditHistoryComponent),
        canActivate: [roleGuard(['Admin', 'Audit'])]
    },
    {
        path: '',
        redirectTo: 'candidates',
        pathMatch: 'full'
    }
];
