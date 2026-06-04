import { HttpClient, HttpParams } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { AroundBrushingItemModel, PagedResult } from '../../../../around-brushing/models/around-brushing.model'

@Injectable()
export class AroundBrushingService {
  private readonly httpClient = inject(HttpClient)

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<AroundBrushingItemModel>>(
      'https://localhost:7036/api/AroundBrushing',
      { params }
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
