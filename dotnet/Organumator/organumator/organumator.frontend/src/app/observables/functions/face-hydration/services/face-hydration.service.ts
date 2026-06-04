import { HttpClient, HttpParams } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { FaceHydrationItemModel, PagedResult } from '../models/face-hydration.model'

@Injectable()
export class FaceHydrationService {
  protected readonly httpClient = inject(HttpClient)

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<FaceHydrationItemModel>>(
      'https://localhost:7036/api/FaceHydration',
      { params }
    )
  }

  create() {
    return this.httpClient.post<FaceHydrationItemModel>('https://localhost:7036/api/FaceHydration', {
      performedOnDate: new Date().toISOString(),
    })
  }

  delete(id: number) {
    return this.httpClient.delete<FaceHydrationItemModel>(
      `https://localhost:7036/api/FaceHydration/${id}`
    )
  }
}
