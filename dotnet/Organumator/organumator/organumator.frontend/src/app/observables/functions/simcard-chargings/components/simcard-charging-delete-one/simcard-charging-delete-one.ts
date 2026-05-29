import { Component, EventEmitter, inject, Input, OnDestroy, Output } from '@angular/core'
import { SimcardChargingService } from '../../services/simcard-charging.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'simcard-charging-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './simcard-charging-delete-one.html',
  styleUrl: './simcard-charging-delete-one.scss',
})
export class SimcardChargingDeleteOne implements OnDestroy {
  private readonly simcardChargingService = inject(SimcardChargingService)
  @Input() itemId!: number
  @Output() deleted = new EventEmitter<void>()
  private readonly destroy$ = new Subject<void>()

  confirming = false

  requestDelete() {
    this.confirming = true
  }

  cancelDelete() {
    this.confirming = false
  }

  confirmDelete() {
    this.confirming = false
    this.simcardChargingService
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
    this.destroy$.next()
    this.destroy$.complete()
  }
}
