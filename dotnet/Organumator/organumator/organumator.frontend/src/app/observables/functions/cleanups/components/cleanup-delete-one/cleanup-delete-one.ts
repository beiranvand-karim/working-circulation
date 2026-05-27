import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core'
import { CleanupsService } from '../../services/cleanups.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'cleanup-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './cleanup-delete-one.html',
  styleUrl: './cleanup-delete-one.scss',
  providers: [CleanupsService],
})
export class CleanupDeleteOne implements OnDestroy {
  private destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId: number | null = null

  constructor(private cleanupsService: CleanupsService) {}

  deleteCleanup(id: number) {
    this.cleanupsService
      .delete(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.deleted.emit()
        },
        error: err => {
          console.error('Error deleting cleanup:', err)
        },
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
