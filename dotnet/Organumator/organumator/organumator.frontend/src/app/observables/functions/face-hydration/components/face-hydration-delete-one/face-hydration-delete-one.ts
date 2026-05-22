import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnDestroy,
  Output,
} from '@angular/core'
import { FaceHydrationService } from '../../services/face-hydration.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'face-hydration-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './face-hydration-delete-one.html',
  styleUrl: './face-hydration-delete-one.scss',
})
export class FaceHydrationDeleteOne implements OnDestroy {
  private readonly faceHydrationService = inject(FaceHydrationService)
  @Input() itemId!: number
  @Output() deleted = new EventEmitter<void>()
  private readonly destroy$ = new Subject<void>()

  delete() {
    this.faceHydrationService
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
