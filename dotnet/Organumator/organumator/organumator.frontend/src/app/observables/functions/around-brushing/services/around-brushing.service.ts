import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { AroundBrushingItemModel } from '../../../../around-brushing/models/around-brushing.model'

@Injectable()
export class AroundBrushingService {
  private readonly httpClient = inject(HttpClient)

  getAll() {
    return this.httpClient.get<AroundBrushingItemModel[]>(
      'https://localhost:7036/api/AroundBrushing'
    )
  }

  create() {
    return this.httpClient.post('https://localhost:7036/api/AroundBrushing', {
      performedOnDate: new Date().toISOString(),
    })
  }

  delete(id: number) {
    return this.httpClient.delete(
      `https://localhost:7036/api/AroundBrushing/${id}`
    )
  }
}
