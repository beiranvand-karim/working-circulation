import { inject, Injectable } from "@angular/core"
import { LivergolPillTakingItemModel } from "../models/livergol-pill-taking.model"
import { HttpClient } from "@angular/common/http"

@Injectable()
export class LivergolPillTakingService {
    private readonly httpClient = inject(HttpClient)

    getAll() {
        return this.httpClient.get<LivergolPillTakingItemModel[]>(
            'https://localhost:7036/api/LivergolPillTaking'
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

