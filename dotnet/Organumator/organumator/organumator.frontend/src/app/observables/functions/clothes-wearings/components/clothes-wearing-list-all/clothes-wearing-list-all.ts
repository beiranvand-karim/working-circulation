import { Component, inject, OnDestroy } from '@angular/core'
import { ClothesWearingService } from '../../services/clothes-wearing.service'
import { ClothesWearing, PagedResult } from '../../models/clothes-wearing.model'
import { Subject, takeUntil } from 'rxjs'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatProgressBarModule } from '@angular/material/progress-bar'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { ClothesWearingDeleteOne } from '../clothes-wearing-delete-one/clothes-wearing-delete-one'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'clothes-wearing-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, MatProgressBarModule, MatPaginatorModule, ClothesWearingDeleteOne],
  templateUrl: './clothes-wearing-list-all.html',
  styleUrl: './clothes-wearing-list-all.scss',
  providers: [ClothesWearingService],
})
export class ClothesWearingListAll implements OnDestroy {
  private readonly clothesWearingService = inject(ClothesWearingService)
  private readonly destroy$ = new Subject<void>()
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['differentiator', 'wearingStart', 'wearingFinish', 'duration', 'actions']

  loading = false
  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: ClothesWearing[] = []

  constructor() {
    this.loadPage()
  }

  onPageChange(event: PageEvent) {
    this.pageNumber = event.pageIndex + 1
    this.pageSize = event.pageSize
    this.loadPage()
  }

  refresh() {
    this.loadPage()
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

  private loadPage() {
    this.loading = true
    this.clothesWearingService.getAll(this.pageNumber, this.pageSize)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (result: PagedResult<ClothesWearing>) => {
          this.items = result.items
          this.totalCount = result.totalCount
          this.totalPages = result.totalPages
          this.loading = false
        },
        error: () => { this.loading = false },
      })
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
