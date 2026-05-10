import { Component, EventEmitter, OnDestroy, Output } from '@angular/core'
import { CalciferolPillTakingsService } from '../../services/calciferol-pill-takings.service'
import { Subject, takeUntil } from 'rxjs'

@Component({
  selector: 'calciferol-taking-create-one',
  imports: [],
  templateUrl: './calciferol-taking-create-one.html',
  styleUrl: './calciferol-taking-create-one.scss',
  providers: [CalciferolPillTakingsService],
})
export class CalciferolTakingCreateOne implements OnDestroy {
  destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  constructor(
    private calciferolPillTakingsService: CalciferolPillTakingsService
  ) {}

  create() {
    const newCalciferolPillTaking = {
      id: 0,
      performedOnDate: new Date().toISOString(),
    }

    this.calciferolPillTakingsService
    .add(newCalciferolPillTaking)
    .pipe(takeUntil(this.destroy$))
    .subscribe({
      next: () => {
        console.log('New calciferol pill taking has been created.')
        this.created.emit()
      },
      error: err => {
        console.error('Error creating calciferol pill taking:', err)
      },
    })
  }

  ngOnDestroy() {
    // Clean up any subscriptions or resources if needed
    this.destroy$.next()
    this.destroy$.complete()
  }
}
