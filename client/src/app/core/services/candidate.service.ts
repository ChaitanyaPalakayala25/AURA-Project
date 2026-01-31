import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Candidate } from '../models/candidate.model';

@Injectable({
    providedIn: 'root'
})
export class CandidateService {
    private apiUrl = `${environment.apiUrl}/candidates`;

    constructor(private http: HttpClient) { }

    getAllCandidates(): Observable<Candidate[]> {
        return this.http.get<Candidate[]>(this.apiUrl);
    }

    getCandidateById(id: number): Observable<Candidate> {
        return this.http.get<Candidate>(`${this.apiUrl}/${id}`);
    }

    getActiveOnboardings(): Observable<Candidate[]> {
        return this.http.get<Candidate[]>(`${this.apiUrl}/active`);
    }

    createCandidate(candidate: Candidate): Observable<Candidate> {
        return this.http.post<Candidate>(this.apiUrl, candidate);
    }

    updateCandidate(id: number, candidate: Candidate): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, candidate);
    }

    deleteCandidate(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }

    updateTimestamp(id: number, team: 'recruiter' | 'hr' | 'it' | 'audit' | 'pct'): Observable<void> {
        const timestamp = new Date();
        const payload: any = {};
        payload[`${team}Timestamp`] = timestamp;
        return this.http.patch<void>(`${this.apiUrl}/${id}/timestamp`, payload);
    }
}
