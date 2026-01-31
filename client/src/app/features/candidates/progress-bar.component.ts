import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-progress-bar',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  template: `
    <div class="progress-container">
      <div class="workflow-title">Onboarding Progress: <span>Gate {{currentStep}} of 5</span></div>
      <div class="progress-wrapper">
        <div class="step" [class.active]="currentStep >= 1" [class.completed]="currentStep > 1">
          <div class="circle"><mat-icon>assignment_ind</mat-icon></div>
          <div class="label">Recruiter</div>
        </div>
        <div class="line" [class.completed]="currentStep > 1"></div>
        
        <div class="step" [class.active]="currentStep >= 2" [class.completed]="currentStep > 2">
          <div class="circle"><mat-icon>rate_review</mat-icon></div>
          <div class="label">Manager (RM)</div>
        </div>
        <div class="line" [class.completed]="currentStep > 2"></div>

        <div class="step" [class.active]="currentStep >= 3" [class.completed]="currentStep > 3">
          <div class="circle"><mat-icon>verified_user</mat-icon></div>
          <div class="label">HR Desk</div>
        </div>
        <div class="line" [class.completed]="currentStep > 3"></div>

        <div class="step" [class.active]="currentStep >= 4" [class.completed]="currentStep > 4">
          <div class="circle"><mat-icon>phonelink_setup</mat-icon></div>
          <div class="label">IT Provision</div>
        </div>
        <div class="line" [class.completed]="currentStep > 4"></div>

        <div class="step" [class.active]="currentStep >= 5" [class.completed]="currentStep > 5">
          <div class="circle"><mat-icon>task_alt</mat-icon></div>
          <div class="label">Onboarded</div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .progress-container {
      background: #fff;
      padding: 24px;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0,0,0,0.05);
      margin-bottom: 24px;
    }
    .workflow-title {
      font-size: 16px;
      font-weight: bold;
      margin-bottom: 20px;
      color: #333;
    }
    .workflow-title span {
      color: #1a237e;
    }
    .progress-wrapper {
      display: flex;
      align-items: center;
      justify-content: space-between;
    }
    .step {
      display: flex;
      flex-direction: column;
      align-items: center;
      position: relative;
      z-index: 1;
      flex: 1;
    }
    .circle {
      width: 44px;
      height: 44px;
      border-radius: 50%;
      background: #eceff1;
      display: flex;
      align-items: center;
      justify-content: center;
      color: #90a4ae;
      transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
      border: 2px solid transparent;
    }
    .label {
      margin-top: 12px;
      font-size: 13px;
      font-weight: 500;
      color: #78909c;
    }
    .line {
      flex: 1;
      height: 3px;
      background: #eceff1;
      margin: 0 -22px;
      position: relative;
      top: -14px;
      z-index: 0;
    }
    .step.active .circle {
      background: #1a237e;
      color: #fff;
      transform: scale(1.1);
      box-shadow: 0 4px 10px rgba(26, 35, 126, 0.3);
    }
    .step.active .label {
      color: #1a237e;
      font-weight: bold;
    }
    .step.completed .circle {
      background: #4caf50;
      color: #fff;
    }
    .line.completed {
      background: #4caf50;
    }
  `]
})
export class ProgressBarComponent {
  @Input() currentStep: number = 1;
}
