import {
  Component,
  EventEmitter,
  inject,
  OnDestroy,
  Output,
} from '@angular/core'
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'livergol-pill-taking-create-one',
  imports: [MatButtonModule],
  templateUrl: './livergol-pill-taking-create-one.html',
  styleUrl: './livergol-pill-taking-create-one.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingCreateOne implements OnDestroy {
  private readonly livergolPillTakingService = inject(LivergolPillTakingService)
  private readonly destroy$ = new Subject<void>()

  @Output() created = new EventEmitter<void>()

  create() {
    this.livergolPillTakingService
    .create()
    .pipe(takeUntil(this.destroy$))
    .subscribe({
      next: () => {
        console.log('Pill taking created successfully')
        this.created.emit()
      },
      error: error => console.error('Failed to create pill taking:', error),
    })
  }

  ngOnDestroy(): void {
    // Clean up any subscriptions if necessary
    this.destroy$.next()
    this.destroy$.complete()
  }
}
