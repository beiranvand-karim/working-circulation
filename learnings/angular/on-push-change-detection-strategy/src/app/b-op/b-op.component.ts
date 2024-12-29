import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input } from '@angular/core';
import { User } from '../a-op/a-op.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-b-op',
  templateUrl: './b-op.component.html',
  styleUrl: './b-op.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BOpComponent {
  @Input() user$: Observable<User | undefined | null> | null = null
  user: User | undefined |null = null

  constructor(private cd: ChangeDetectorRef) {}

  ngOnChanges() {
    this.user$?.subscribe(user => {
      if (user !== this.user) {
        this.cd.markForCheck()
        this.user = user
      }
    })
  }
}
