import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
    selector: 'app-audit-history',
    standalone: true,
    imports: [CommonModule, MatTableModule, MatCardModule],
    template: `
    <div class="container">
      <mat-card>
        <mat-card-header>
          <mat-card-title>System Audit History</mat-card-title>
        </mat-card-header>
        <mat-card-content>
          <table mat-table [dataSource]="logs" class="mat-elevation-z0">
            <ng-container matColumnDef="timestamp">
              <th mat-header-cell *matHeaderCellDef> Time </th>
              <td mat-cell *matCellDef="let element"> {{element.timestamp | date:'medium'}} </td>
            </ng-container>
            <ng-container matColumnDef="performedBy">
              <th mat-header-cell *matHeaderCellDef> Performed By </th>
              <td mat-cell *matCellDef="let element"> {{element.performedBy}} </td>
            </ng-container>
            <ng-container matColumnDef="action">
              <th mat-header-cell *matHeaderCellDef> Action </th>
              <td mat-cell *matCellDef="let element"> {{element.action}} </td>
            </ng-container>
            <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
            <tr mat-row *matRowDef="let row; columns: displayedColumns;"></tr>
          </table>
        </mat-card-content>
      </mat-card>
    </div>
  `,
    styles: [`
    .container { padding: 24px; }
    table { width: 100%; }
    .mat-mdc-header-cell { font-weight: bold; background: #f5f5f5; }
  `]
})
export class AuditHistoryComponent implements OnInit {
    logs: any[] = [];
    displayedColumns: string[] = ['timestamp', 'performedBy', 'action'];

    constructor(private http: HttpClient) { }

    ngOnInit(): void {
        this.http.get<any[]>(`${environment.apiUrl}/audit`).subscribe(data => {
            this.logs = data;
        });
    }
}
