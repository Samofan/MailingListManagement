import { Routes } from '@angular/router';
import { EditComponent } from './mailing-list/components/edit/edit.component';
import { MailingListComponent } from './mailing-list/components/mailing-list.component';

export const routes: Routes = [
  {
    path: '',
    component: MailingListComponent,
    title: 'Mailing Lists',
  },
  {
    path: 'edit/:id',
    component: EditComponent,
    title: 'Edit Mailing List',
  },
];
