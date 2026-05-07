import { Component, EventEmitter, inject, Input, OnDestroy, Output } from '@angular/core';
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'livergol-pill-taking-delete-one',
  imports: [],
  templateUrl: './livergol-pill-taking-delete-one.html',
  styleUrl: './livergol-pill-taking-delete-one.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingDeleteOne implements OnDestroy {
  private readonly livergolPillTakingService = inject(LivergolPillTakingService)
  private readonly destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId!: number

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }

  delete() {
    this.livergolPillTakingService.delete(this.itemId).subscribe({
      next: () => {
        console.log('Pill taking deleted successfully')
        this.deleted.emit()
      },
      error: error => console.error('Failed to delete pill taking:', error),
    })
  }
}
