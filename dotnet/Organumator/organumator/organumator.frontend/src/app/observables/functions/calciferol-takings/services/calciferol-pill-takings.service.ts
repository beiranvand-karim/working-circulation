import { inject, Injectable } from '@angular/core'
import { CalciferolPillTakings, PagedResult } from '../models/calciferol-pill-takings.model'
import { HttpClient, HttpParams } from '@angular/common/http'

@Injectable()
export class CalciferolPillTakingsService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/CalciferolTaking'

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<CalciferolPillTakings>>(this.apiUrl, { params })
  }

  add(calciferolPillTakings: CalciferolPillTakings) {
    return this.httpClient.post(this.apiUrl, calciferolPillTakings)
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }

  getById(id: number) {
    return this.httpClient.get<CalciferolPillTakings>(`${this.apiUrl}/${id}`)
  }

  update(id: number, calciferolPillTakings: CalciferolPillTakings) {
    return this.httpClient.put(`${this.apiUrl}/${id}`, calciferolPillTakings)
  }
}
