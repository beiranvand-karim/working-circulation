import { inject, Injectable } from '@angular/core';
import { CleanupsModel } from '../models/cleanups.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CleanupsService {
  private readonly httpClient: HttpClient = inject(HttpClient);
  apiUrl = 'https://localhost:7036/api/CleanupTimeManagement';

  getAll() {
    return this.httpClient.get<CleanupsModel[]>(this.apiUrl);
  }

  start() {
    return this.httpClient.post<CleanupsModel>(`${this.apiUrl}/start`, null);
  }

  finish(id: number) {
    return this.httpClient.post<CleanupsModel>(`${this.apiUrl}/${id}/finish`, null);
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }

  getById(id: number) {
    return this.httpClient.get<CleanupsModel>(`${this.apiUrl}/${id}`);
  }

  getDaysWithData() {
    return this.httpClient.get<{ date: string; count: number; totalDurationSeconds: number }[]>(`${this.apiUrl}/DaysWithData`);
  }

  getByDay(date: string) {
    return this.httpClient.get<CleanupsModel[]>(`${this.apiUrl}/day/${date}`);
  }

  deleteByDay(date: string) {
    return this.httpClient.delete(`${this.apiUrl}/day/${date}`);
  }
}
