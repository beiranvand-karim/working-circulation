import { inject, Injectable } from "@angular/core"
import { LivergolPillTakingItemModel, PagedResult } from "../models/livergol-pill-taking.model"
import { HttpClient, HttpParams } from "@angular/common/http"

@Injectable()
export class LivergolPillTakingService {
    private readonly httpClient = inject(HttpClient)

    getAll(pageNumber: number, pageSize: number) {
        const params = new HttpParams()
            .set('pageNumber', pageNumber)
            .set('pageSize', pageSize)
        return this.httpClient.get<PagedResult<LivergolPillTakingItemModel>>(
            'https://localhost:7036/api/LivergolPillTaking',
            { params }
        )
    }

    create() {
        return this.httpClient.post('https://localhost:7036/api/LivergolPillTaking', {
            performedOnDate: new Date().toISOString(),
        })
    }

    delete(id: number) {
        return this.httpClient.delete(
            `https://localhost:7036/api/LivergolPillTaking/${id}`
        )
    }   
}

