import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { BetweenTeethBrushing, PagedResult } from "../models/between-teeth-brushing.model";

@Injectable()
export class BetweenTeethBrushingService {
  private readonly httpClient = inject(HttpClient)

  private readonly apiUrl = 'https://localhost:7036/api/BetweenTeethBrushing';

  getAll(pageNumber: number, pageSize: number) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
    return this.httpClient.get<PagedResult<BetweenTeethBrushing>>(this.apiUrl, { params });
  }
    
    create() {
        return this.httpClient.post(this.apiUrl, {
            performedOnDate: new Date().toISOString(),
        });
    }

    delete(id: number) {
        return this.httpClient.delete(`${this.apiUrl}/${id}`);
    }

    getById(id: number) {
        return this.httpClient.get<BetweenTeethBrushing>(`${this.apiUrl}/${id}`);
    }
}