import { inject, Injectable } from '@angular/core'
import { ClothesWearing } from '../models/clothes-wearing.model'
import { HttpClient } from '@angular/common/http'

@Injectable()
export class ClothesWearingService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/ClothesWearings'

  getAll() {
    return this.httpClient.get<ClothesWearing[]>(this.apiUrl)
  }

  add(clothesWearing: ClothesWearing) {
    return this.httpClient.post<ClothesWearing>(this.apiUrl, clothesWearing)
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }

  getById(id: number) {
    return this.httpClient.get<ClothesWearing>(`${this.apiUrl}/${id}`)
  }

  update(id: number, clothesWearing: ClothesWearing) {
    return this.httpClient.put(`${this.apiUrl}/${id}`, clothesWearing)
  }
}
