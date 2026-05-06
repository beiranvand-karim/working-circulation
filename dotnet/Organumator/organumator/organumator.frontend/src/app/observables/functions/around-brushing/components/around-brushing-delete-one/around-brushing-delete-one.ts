import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnDestroy,
  Output,
} from '@angular/core'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { Subject, takeUntil } from 'rxjs'

@Component({
  selector: 'around-brushing-delete-one',
  imports: [],
  templateUrl: './around-brushing-delete-one.html',
  styleUrl: './around-brushing-delete-one.scss',
})
export class AroundBrushingDeleteOne implements OnDestroy {
  private readonly aroundBrushingService = inject(AroundBrushingService)

  @Input() itemId!: number
  @Output() deleted = new EventEmitter<void>()
  private readonly destroy$ = new Subject<void>()

  deleteItem() {
    this.aroundBrushingService
    .delete(this.itemId)
    .pipe(takeUntil(this.destroy$))
    .subscribe({
      next: () => {
        console.log(`Item with id ${this.itemId} deleted successfully`)
        this.deleted.emit()
      },
      error: error =>
        console.error(`Failed to delete item with id ${this.itemId}:`, error),
    })
  }

  ngOnDestroy(): void {
    // Clean up any subscriptions if necessary
    this.destroy$.next()
    this.destroy$.complete()
  }
}
