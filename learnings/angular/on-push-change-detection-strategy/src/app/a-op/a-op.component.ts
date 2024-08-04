import { Component } from '@angular/core';
import { produce } from 'immer';
import { BehaviorSubject } from 'rxjs';

export interface User {
  name: string;
}

@Component({
  selector: 'app-a-op',
  templateUrl: './a-op.component.html',
  styleUrl: './a-op.component.scss',
})
export class AOpComponent {
  user$ = new BehaviorSubject({ name: 'A' })

  changeName() {
    const user = this.user$.getValue()
    this.user$.next(
      produce(user, draft => {
        draft.name = 'B'
      })
    )
  }
}
