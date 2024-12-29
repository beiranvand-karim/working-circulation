import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input } from '@angular/core';
import { User } from '../a-op/a-op.component';

@Component({
  selector: 'app-b-op',
  templateUrl: './b-op.component.html',
  styleUrl: './b-op.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BOpComponent {
  @Input() user: User | null = null
  previousUserName: string |undefined = ''

  constructor(private readonly cd: ChangeDetectorRef) {}

  ngDoCheck() {
    if (this.user?.name !== this.previousUserName) {
      this.cd.markForCheck()
      this.previousUserName = this.user?.name
    }
  }
}
