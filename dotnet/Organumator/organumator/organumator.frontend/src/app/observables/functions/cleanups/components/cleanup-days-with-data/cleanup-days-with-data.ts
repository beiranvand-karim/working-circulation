import { Component, inject, OnDestroy } from '@angular/core'
import { CleanupsService } from '../../services/cleanups.service'
import { AsyncPipe, DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { Router } from '@angular/router'
import { Subject, takeUntil } from 'rxjs'

@Component({
  selector: 'cleanup-days-with-data',
  imports: [AsyncPipe, DatePipe, MatTableModule, MatButtonModule, MatIconModule],
  templateUrl: './cleanup-days-with-data.html',
  styleUrl: './cleanup-days-with-data.scss',
  providers: [CleanupsService],
})
export class CleanupDaysWithData implements OnDestroy {
  private readonly cleanupsService = inject(CleanupsService)
  private readonly router = inject(Router)
  private readonly destroy$ = new Subject<void>()

  days$ = this.cleanupsService.getDaysWithData()
  displayedColumns = ['date', 'count', 'duration', 'actions']

  formatDuration(totalSeconds: number): string {
    const h = Math.floor(totalSeconds / 3600)
    const m = Math.floor((totalSeconds % 3600) / 60)
    const s = totalSeconds % 60
    if (h > 0) return `${h}h ${m}m ${s}s`
    if (m > 0) return `${m}m ${s}s`
    return `${s}s`
  }

  refresh() {
    this.days$ = this.cleanupsService.getDaysWithData()
  }

  goToList(date: string) {
    this.router.navigate(['/cleanups/list'], { queryParams: { date } })
  }

  deleteDay(date: string) {
    this.cleanupsService
      .deleteByDay(date)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => this.refresh(),
        error: err => console.error('Error deleting day:', err),
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
