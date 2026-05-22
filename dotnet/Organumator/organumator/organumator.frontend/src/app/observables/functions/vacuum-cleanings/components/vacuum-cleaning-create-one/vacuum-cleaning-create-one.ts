import { Component, EventEmitter, OnDestroy, Output } from '@angular/core'
import { VacuumCleaningsService } from '../../services/vacuum-cleanings.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'vacuum-cleaning-create-one',
  imports: [MatButtonModule],
  templateUrl: './vacuum-cleaning-create-one.html',
  styleUrl: './vacuum-cleaning-create-one.scss',
  providers: [VacuumCleaningsService],
})
export class VacuumCleaningCreateOne implements OnDestroy {
  destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  constructor(private vacuumCleaningsService: VacuumCleaningsService) {}

  create() {
    const newVacuumCleaning = {
      id: 0,
      performedOnDate: new Date().toISOString(),
    }

    this.vacuumCleaningsService
      .add(newVacuumCleaning)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          console.log('New vacuum cleaning has been created.')
          this.created.emit()
        },
        error: err => {
          console.error('Error creating vacuum cleaning:', err)
        },
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
