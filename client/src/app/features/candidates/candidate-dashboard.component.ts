import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { CandidateService } from '../../core/services/candidate.service';
import { Candidate } from '../../core/models/candidate.model';
import { AuthService } from '../../core/services/auth.service';

@Component({
    selector: 'app-candidate-dashboard',
    standalone: true,
    imports: [CommonModule, MatTableModule, MatCardModule, MatButtonModule, MatIconModule, RouterModule],
    templateUrl: './candidate-dashboard.component.html',
    styleUrls: ['./candidate-dashboard.component.css']
})
export class CandidateDashboardComponent implements OnInit {
    candidates: Candidate[] = [];
    displayedColumns: string[] = ['title', 'status', 'region', 'recruiterName', 'reportingManager'];

    constructor(
        private candidateService: CandidateService,
        public authService: AuthService
    ) { }

    ngOnInit(): void {
        this.loadActiveOnboardings();
    }

    loadActiveOnboardings(): void {
        this.candidateService.getActiveOnboardings().subscribe({
            next: (data) => {
                this.candidates = this.filterByRole(data);
            },
            error: (err) => {
                console.error('Error loading candidates', err);
            }
        });
    }

    private filterByRole(data: Candidate[]): Candidate[] {
        const role = this.authService.getRole();
        if (role === 'IT') {
            return data.filter(c => c.status === 'IT Provisioning');
        }
        if (role === 'HR') {
            return data.filter(c => c.status === 'HR Verification');
        }
        if (role === 'Manager') {
            return data.filter(c => c.status === 'Manager Approval');
        }
        return data; // Admin/Recruiter see all
    }

    canAddCandidate(): boolean {
        return this.authService.hasRole(['Admin', 'Recruiter']);
    }
}
