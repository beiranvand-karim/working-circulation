import { Component, EventEmitter, inject, Input, OnDestroy, Output } from '@angular/core'
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'livergol-pill-taking-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './livergol-pill-taking-delete-one.html',
  styleUrl: './livergol-pill-taking-delete-one.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingDeleteOne implements OnDestroy {
  private readonly livergolPillTakingService = inject(LivergolPillTakingService)
  private readonly destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId!: number

  delete() {
    this.livergolPillTakingService.delete(this.itemId).pipe(takeUntil(this.destroy$)).subscribe({
      next: () => this.deleted.emit(),
      error: error => console.error('Failed to delete pill taking:', error),
    })
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
