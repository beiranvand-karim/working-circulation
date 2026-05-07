import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { SilvermanPillTakingItemModel } from "../models/silverman-pill-taking.model";


@Injectable()
export class SilvermanPillTakingService {
    private readonly httpClient = inject(HttpClient)

    private readonly apiUrl = 'https://localhost:7036/api/SilvermanPillTaking';

    getAll() {
        return this.httpClient.get<SilvermanPillTakingItemModel[]>(this.apiUrl);
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
