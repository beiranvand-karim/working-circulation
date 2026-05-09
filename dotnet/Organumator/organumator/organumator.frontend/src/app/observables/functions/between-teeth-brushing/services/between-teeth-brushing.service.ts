import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { BetweenTeethBrushing } from "../models/between-teeth-brushing.model";

@Injectable()
export class BetweenTeethBrushingService {
  private readonly httpClient = inject(HttpClient)

  private readonly apiUrl = 'https://localhost:7036/api/BetweenTeethBrushing';

    getAll() {
        return this.httpClient.get<BetweenTeethBrushing[]>(this.apiUrl);
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