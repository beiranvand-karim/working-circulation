import { inject, Injectable } from '@angular/core'
import { VacuumCleanings, PagedResult } from '../models/vacuum-cleanings.model'
import { HttpClient, HttpParams } from '@angular/common/http'

@Injectable()
export class VacuumCleaningsService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/VacuumCleanings'

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<VacuumCleanings>>(this.apiUrl, { params })
  }

  add(vacuumCleaning: VacuumCleanings) {
    return this.httpClient.post(this.apiUrl, vacuumCleaning)
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }

  getById(id: number) {
    return this.httpClient.get<VacuumCleanings>(`${this.apiUrl}/${id}`)
  }

  update(id: number, vacuumCleaning: VacuumCleanings) {
    return this.httpClient.put(`${this.apiUrl}/${id}`, vacuumCleaning)
  }
}
