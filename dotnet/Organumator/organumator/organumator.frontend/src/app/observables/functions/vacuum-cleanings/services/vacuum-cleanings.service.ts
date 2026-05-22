import { inject, Injectable } from '@angular/core'
import { VacuumCleanings } from '../models/vacuum-cleanings.model'
import { HttpClient } from '@angular/common/http'

@Injectable()
export class VacuumCleaningsService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/VacuumCleanings'

  getAll() {
    return this.httpClient.get<VacuumCleanings[]>(this.apiUrl)
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
