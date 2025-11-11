import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MailingListStore } from './stores/mailing-list.store';

@Component({
  selector: 'app-mailing-list',
  imports: [CommonModule],
  providers: [MailingListStore],
  templateUrl: './mailing-list.component.html',
  styleUrl: './mailing-list.component.scss',
})
export class MailingListComponent {
  readonly store = inject(MailingListStore);

  constructor() {
    this.store.loadAll();
  }
}
