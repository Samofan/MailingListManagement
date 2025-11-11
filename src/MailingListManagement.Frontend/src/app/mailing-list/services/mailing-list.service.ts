import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { MailingList } from "../models/mailing-list.model";

@Injectable({ providedIn: 'root' })
export class MailingListService {
    private readonly http = inject(HttpClient);
    private readonly baseUrl = 'api/MailingLists';

    getAll(): Observable<MailingList[]> {
        return this.http.get<MailingList[]>(this.baseUrl);
    }
}