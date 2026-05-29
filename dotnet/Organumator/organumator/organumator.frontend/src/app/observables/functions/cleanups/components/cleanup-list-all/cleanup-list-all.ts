import { Component, inject, OnDestroy } from '@angular/core'
import { CleanupsService } from '../../services/cleanups.service'
import { BehaviorSubject, combineLatest, interval, Subject, switchMap, takeUntil } from 'rxjs'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { CleanupDeleteOne } from '../cleanup-delete-one/cleanup-delete-one'
import { CleanupsModel } from '../../models/cleanups.model'
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'cleanup-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, CleanupDeleteOne],
  templateUrl: './cleanup-list-all.html',
  styleUrl: './cleanup-list-all.scss',
  providers: [CleanupsService],
})
export class CleanupListAll implements OnDestroy {
  private readonly cleanupsService = inject(CleanupsService)
  private readonly route = inject(ActivatedRoute)
  private readonly refresh$ = new BehaviorSubject<void>(undefined)
  destroy$ = new Subject<void>()
  now = new Date()

  constructor() {
    interval(1000).pipe(takeUntil(this.destroy$)).subscribe(() => this.now = new Date())
  }

  cleanups$ = combineLatest([this.route.queryParamMap, this.refresh$]).pipe(
    switchMap(([params]) => {
      const date = params.get('date')
      return date ? this.cleanupsService.getByDay(date) : this.cleanupsService.getAll()
    })
  )

  displayedColumns = ['startedAt', 'finishedAt', 'duration', 'actions']

  formatDuration(startedAt: string, finishedAt: string | null): string {
    const end = finishedAt ? new Date(finishedAt) : this.now
    const totalSeconds = Math.floor((end.getTime() - new Date(startedAt).getTime()) / 1000)
    const h = Math.floor(totalSeconds / 3600)
    const m = Math.floor((totalSeconds % 3600) / 60)
    const s = totalSeconds % 60
    if (h > 0) return `${h}h ${m}m ${s}s`
    if (m > 0) return `${m}m ${s}s`
    return `${s}s`
  }

  finish(item: CleanupsModel) {
    this.cleanupsService
      .finish(item.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => this.refresh(),
        error: err => console.error('Error finishing cleanup:', err),
      })
  }

  refresh() {
    this.refresh$.next()
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
