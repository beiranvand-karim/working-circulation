import { HttpClient, HttpParams } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { SimcardChargingItemModel, PagedResult } from '../models/simcard-charging.model'

@Injectable()
export class SimcardChargingService {
  protected readonly httpClient = inject(HttpClient)

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<SimcardChargingItemModel>>(
      'https://localhost:7036/api/SimcardChargings',
      { params }
    )
  }

  create() {
    return this.httpClient.post<SimcardChargingItemModel>(
      'https://localhost:7036/api/SimcardChargings',
      {}
    )
  }

  delete(id: number) {
    return this.httpClient.delete<void>(
      `https://localhost:7036/api/SimcardChargings/${id}`
    )
  }
}
