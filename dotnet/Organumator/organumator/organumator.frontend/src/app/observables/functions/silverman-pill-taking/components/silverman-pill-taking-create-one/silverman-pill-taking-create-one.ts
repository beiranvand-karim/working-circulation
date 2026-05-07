import {
  Component,
  EventEmitter,
  inject,
  OnDestroy,
  Output,
} from '@angular/core'
import { SilvermanPillTakingService } from '../../services/silverman-pill-taking.service'
import { Subject, takeUntil } from 'rxjs'

@Component({
  selector: 'silverman-pill-taking-create-one',
  imports: [],
  templateUrl: './silverman-pill-taking-create-one.html',
  styleUrl: './silverman-pill-taking-create-one.scss',
  providers: [SilvermanPillTakingService],
})
export class SilvermanPillTakingCreateOne implements OnDestroy {
  private readonly silvermanPillTakingService = inject(
    SilvermanPillTakingService
  )
  @Output() created = new EventEmitter<void>()
  private readonly destroy$ = new Subject<void>()

  create() {
    this.silvermanPillTakingService
    .create()
    .pipe(takeUntil(this.destroy$))
    .subscribe({
      next: () => {
        console.log('Item created successfully')
        this.created.emit()
      },
      error: error => console.error('Failed to create item:', error),
    })
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
