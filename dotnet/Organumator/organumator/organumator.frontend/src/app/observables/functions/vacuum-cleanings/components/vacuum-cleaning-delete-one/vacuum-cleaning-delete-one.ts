import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core'
import { VacuumCleaningsService } from '../../services/vacuum-cleanings.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'vacuum-cleaning-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './vacuum-cleaning-delete-one.html',
  styleUrl: './vacuum-cleaning-delete-one.scss',
  providers: [VacuumCleaningsService],
})
export class VacuumCleaningDeleteOne implements OnDestroy {
  private destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId: number | null = null

  constructor(private vacuumCleaningsService: VacuumCleaningsService) {}

  deleteVacuumCleaning(id: number) {
    this.vacuumCleaningsService
      .delete(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.deleted.emit()
        },
        error: err => {
          console.error('Error deleting vacuum cleaning:', err)
        },
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
