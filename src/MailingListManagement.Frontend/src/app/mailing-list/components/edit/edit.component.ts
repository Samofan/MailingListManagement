import { Component, effect, inject, Signal, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MailingList } from '../../models/mailing-list.model';
import { MailingListStore } from '../../stores/mailing-list.store';

@Component({
  selector: 'app-edit',
  imports: [],
  providers: [MailingListStore],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.scss',
})
export class EditComponent {
  private readonly route = inject(ActivatedRoute);
  readonly store = inject(MailingListStore);

  private listId = signal<string>(this.route.snapshot.paramMap.get('id')!);
  currentList: Signal<MailingList | undefined> = this.store.selectById(this.listId());

  constructor() {
    effect(() => {
      const lists = this.store.mailingLists();
      const loading = this.store.isLoading();

      if (lists.length === 0 && !loading) {
        this.store.loadAll();
      }
    });
  }
}
