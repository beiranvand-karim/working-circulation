import { inject, Injectable } from '@angular/core'
import { ClothesWearing, PagedResult } from '../models/clothes-wearing.model'
import { HttpClient, HttpParams } from '@angular/common/http'

@Injectable()
export class ClothesWearingService {
  private readonly httpClient: HttpClient = inject(HttpClient)
  apiUrl = 'https://localhost:7036/api/ClothesWearings'

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<ClothesWearing>>(this.apiUrl, { params })
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
