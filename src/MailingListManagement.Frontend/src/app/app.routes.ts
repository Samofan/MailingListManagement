import { Routes } from '@angular/router';
import { MailingListComponent } from './mailing-list/mailing-list.component';

export const routes: Routes = [
    {
        path: '',
        component: MailingListComponent,
        title: 'Mailing Lists'
    }
];
