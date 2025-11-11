import { inject } from '@angular/core';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { catchError, finalize, of, tap } from 'rxjs';
import { MailingList } from "../models/mailing-list.model";
import { MailingListService } from '../services/mailing-list.service';

type MailingListState = {
    mailingLists: MailingList[],
    isLoading: boolean
};

const initialState: MailingListState = {
    mailingLists: [],
    isLoading: false
};

export const MailingListStore = signalStore(
    withState(initialState),
    withMethods((store, mailingListService = inject(MailingListService)) => ({
        loadAll(): void {
            patchState(store, { isLoading: true });
            mailingListService.getAll().pipe(
                tap(lists => patchState(store, {mailingLists: lists})),
                catchError(() => {
                    console.error('Failed to load mailing lists');
                    return of([]);
                }),
                finalize(() => patchState(store, { isLoading: false }))
            ).subscribe();
        }
    }))
);