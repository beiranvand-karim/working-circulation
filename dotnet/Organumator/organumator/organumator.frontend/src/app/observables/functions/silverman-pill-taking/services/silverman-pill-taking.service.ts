import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { SilvermanPillTakingItemModel, PagedResult } from "../models/silverman-pill-taking.model";

@Injectable()
export class SilvermanPillTakingService {
    private readonly httpClient = inject(HttpClient)

    private readonly apiUrl = 'https://localhost:7036/api/SilvermanPillTaking';

    getAll(pageNumber: number, pageSize: number) {
        const params = new HttpParams()
            .set('pageNumber', pageNumber)
            .set('pageSize', pageSize)
        return this.httpClient.get<PagedResult<SilvermanPillTakingItemModel>>(this.apiUrl, { params });
    }

    create() {
        return this.httpClient.post(this.apiUrl, {
            performedOnDate: new Date().toISOString(),
        });
    }

    delete(id: number) {
        return this.httpClient.delete(`${this.apiUrl}/${id}`);
    }

}
