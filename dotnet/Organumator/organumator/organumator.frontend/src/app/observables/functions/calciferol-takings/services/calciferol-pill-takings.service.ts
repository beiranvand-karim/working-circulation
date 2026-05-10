import { inject, Injectable } from '@angular/core'
import { CalciferolPillTakings } from '../models/calciferol-pill-takings.model'
import { HttpClient } from '@angular/common/http'

@Injectable()
export class CalciferolPillTakingsService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/CalciferolTaking'

  getAll() {
    return this.httpClient.get<CalciferolPillTakings[]>(this.apiUrl)
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
