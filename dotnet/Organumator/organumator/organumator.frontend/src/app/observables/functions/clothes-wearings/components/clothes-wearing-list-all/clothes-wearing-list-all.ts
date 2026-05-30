import { Component, inject, OnDestroy } from '@angular/core'
import { ClothesWearingService } from '../../services/clothes-wearing.service'
import { ClothesWearing } from '../../models/clothes-wearing.model'
import { Subject, takeUntil, finalize } from 'rxjs'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatProgressBarModule } from '@angular/material/progress-bar'
import { ClothesWearingDeleteOne } from '../clothes-wearing-delete-one/clothes-wearing-delete-one'

@Component({
  selector: 'clothes-wearing-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, MatProgressBarModule, ClothesWearingDeleteOne],
  templateUrl: './clothes-wearing-list-all.html',
  styleUrl: './clothes-wearing-list-all.scss',
  providers: [ClothesWearingService],
})
export class ClothesWearingListAll implements OnDestroy {
  private readonly clothesWearingService = inject(ClothesWearingService)
  destroy$ = new Subject<void>()

  loading = false
  clothesWearings$ = this.load()
  displayedColumns = ['differentiator', 'wearingStart', 'wearingFinish', 'duration', 'actions']

  private load() {
    this.loading = true
    return this.clothesWearingService.getAll().pipe(
      finalize(() => this.loading = false)
    )
  }

  refresh() {
    this.clothesWearings$ = this.load()
  }

  finish(item: ClothesWearing) {
    this.clothesWearingService
      .update(item.id, { ...item, wearingFinish: new Date().toISOString() })
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => this.refresh(),
        error: err => console.error('Error finishing clothes wearing:', err),
      })
  }

  isFinished(item: ClothesWearing): boolean {
    return item.wearingFinish !== null
  }

  durationInDays(item: ClothesWearing): number {
    const start = new Date(item.wearingStart)
    const end = item.wearingFinish ? new Date(item.wearingFinish) : new Date()
    return Math.floor((end.getTime() - start.getTime()) / (1000 * 60 * 60 * 24))
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
