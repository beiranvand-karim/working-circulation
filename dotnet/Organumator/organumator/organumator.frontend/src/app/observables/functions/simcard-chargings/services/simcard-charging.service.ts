import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { SimcardChargingItemModel } from '../models/simcard-charging.model'

@Injectable()
export class SimcardChargingService {
  protected readonly httpClient = inject(HttpClient)

  getAll() {
    return this.httpClient.get<SimcardChargingItemModel[]>(
      'https://localhost:7036/api/SimcardChargings'
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
