import { Component, EventEmitter, OnDestroy, Output } from '@angular/core'
import { CleanupsService } from '../../services/cleanups.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'cleanup-create-one',
  imports: [MatButtonModule],
  templateUrl: './cleanup-create-one.html',
  styleUrl: './cleanup-create-one.scss',
  providers: [CleanupsService],
})
export class CleanupCreateOne implements OnDestroy {
  destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  constructor(private cleanupsService: CleanupsService) {}

  create() {
    this.cleanupsService
      .start()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          console.log('New cleanup has been created.')
          this.created.emit()
        },
        error: err => {
          console.error('Error creating cleanup:', err)
        },
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
