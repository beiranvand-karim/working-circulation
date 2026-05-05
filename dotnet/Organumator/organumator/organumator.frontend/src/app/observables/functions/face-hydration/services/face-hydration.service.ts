import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { FaceHydrationItemModel } from '../models/face-hydration.model'

@Injectable()
export class FaceHydrationService {
  protected readonly httpClient = inject(HttpClient)

  getAll() {
    return this.httpClient.get<FaceHydrationItemModel[]>(
      'https://localhost:7036/api/FaceHydration'
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
