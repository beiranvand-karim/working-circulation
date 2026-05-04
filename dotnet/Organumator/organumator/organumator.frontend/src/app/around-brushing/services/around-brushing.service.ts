import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { rxResource } from '@angular/core/rxjs-interop'
import { AroundBrushingItemModel } from '../models/around-brushing.model'

@Injectable()
export class AroundBrushingService {
  private readonly httpClient = inject(HttpClient)

  rxResourceData = rxResource({
    stream: () =>
      this.httpClient.get<AroundBrushingItemModel[]>(
        'https://localhost:7036/api/AroundBrushing'
      ),
    defaultValue: [],
  })
}
