import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core'
import { BetweenTeethBrushingService } from '../../services/between-teeth-brushing.service'
import { Subject, takeUntil } from 'rxjs'

@Component({
  selector: 'between-teeth-brushing-delete-one',
  imports: [],
  templateUrl: './between-teeth-brushing-delete-one.html',
  styleUrl: './between-teeth-brushing-delete-one.scss',
  providers: [BetweenTeethBrushingService],
})
export class BetweenTeethBrushingDeleteOne implements OnDestroy {
  private readonly destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId!: number

  constructor(
    private readonly betweenTeethBrushingService: BetweenTeethBrushingService
  ) {}

  delete(id: number) {
    this.betweenTeethBrushingService
    .delete(id)
    .pipe(takeUntil(this.destroy$))
    .subscribe({
      next: () => this.deleted.emit(),
      error: err =>
        console.error('Error deleting between teeth brushing:', err),
    })
  }

  ngOnDestroy(): void {
    // Cleanup logic if needed
    this.destroy$.next()
    this.destroy$.complete()
  }
}
