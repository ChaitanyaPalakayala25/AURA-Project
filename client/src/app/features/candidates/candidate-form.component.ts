import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from '../../core/services/candidate.service';
import { Candidate } from '../../core/models/candidate.model';
import { ProgressBarComponent } from './progress-bar.component';
import { MatCardModule } from '@angular/material/card';

@Component({
    selector: 'app-candidate-form',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatTabsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatButtonModule,
        MatIconModule,
        ProgressBarComponent,
        MatCardModule
    ],
    templateUrl: './candidate-form.component.html',
    styleUrls: ['./candidate-form.component.css']
})
export class CandidateFormComponent implements OnInit {
    candidateForm!: FormGroup;
    candidateId?: number;
    isEditMode = false;

    constructor(
        private fb: FormBuilder,
        private candidateService: CandidateService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.initForm();
        this.candidateId = Number(this.route.snapshot.paramMap.get('id'));
        if (this.candidateId) {
            this.isEditMode = true;
            this.loadCandidateData(this.candidateId);
        }
    }

    initForm(): void {
        this.candidateForm = this.fb.group({
            // General Info
            title: ['', Validators.required],
            status: ['In-Process'],
            navitasEmailId: [''],
            candidateDesignation: [''],
            contactDetails: [''],
            personalEmailId: ['', [Validators.email]],
            location: [''],
            region: [''],
            experienceInYears: [0],
            workAuthorization: [''],
            employeeType: [''],
            technicalSkillsSet: [''],
            certifications: [''],

            // Project Details
            projectName: [''],
            projectStartDate: [null],
            projectDuration: [''],
            billRate: [0],
            recruiterName: [''],
            reportingManager: [''],
            securityClearance: [''],
            onboardYear: [new Date().getFullYear()],
            onboardMonth: [new Date().toLocaleString('default', { month: 'long' })],

            // Recruiter Checklist
            resumeCollection: [false],
            passportCopy: [false],
            h1bApprovalCopy: [false],
            recruiterTimestamp: [null],

            // HR Checklist
            hrDesignation: [''],
            hrWorkAuthorization: [''],
            backgroundVerificationStatus: [''],
            payrollSetupStatus: [false],
            orientationCompleted: [false],
            hrTimestamp: [null],

            // IT Checklist
            vpnAccess: [false],
            sharedFolderAccess: [false],
            sharepointAccess: [false],
            laptopIssued: [false],
            laptopSerialNumber: [''],
            distroEmailCreated: [false],
            itTimestamp: [null],

            // Audit Checklist
            msaSigned: [false],
            workOrderReceived: [false],
            coiReceived: [false],
            backgroundInvestigationStatus: [''],
            vendorSetupApproval: [false],
            auditTimestamp: [null],

            // PCT Checklist
            vendorSetupInUnanet: [false],
            resourceSetupInUnanet: [false],
            projectAssignmentToResource: [false],
            billingCodesSetup: [false],
            pctTimestamp: [null],
            managerTimestamp: [null]
        });
    }

    loadCandidateData(id: number): void {
        this.candidateService.getCandidateById(id).subscribe(candidate => {
            this.candidateForm.patchValue(candidate);
        });
    }

    onSubmit(): void {
        if (this.candidateForm.valid) {
            const candidateData: Candidate = this.candidateForm.value;
            if (this.isEditMode && this.candidateId) {
                this.candidateService.updateCandidate(this.candidateId, candidateData).subscribe(() => {
                    this.router.navigate(['/candidates']);
                });
            } else {
                this.candidateService.createCandidate(candidateData).subscribe(() => {
                    this.router.navigate(['/candidates']);
                });
            }
        }
    }

    cancel(): void {
        this.router.navigate(['/candidates']);
    }

    getCurrentStep(): number {
        const values = this.candidateForm.value;
        if (values.auditTimestamp) return 5;
        if (values.itTimestamp) return 4;
        if (values.hrTimestamp) return 3;
        if (values.managerTimestamp) return 2;
        if (values.recruiterTimestamp) return 1;
        return 1;
    }
}
