import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { EnvironmentInfo } from '../models/environment.model'

@Injectable()
export class EnvironmentService {
  private readonly httpClient = inject(HttpClient)

  getCurrent() {
    return this.httpClient.get<EnvironmentInfo>('https://localhost:7036/api/Environment')
  }
}
