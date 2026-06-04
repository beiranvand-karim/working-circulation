import { Component, inject } from '@angular/core'
import { LivergolPillTakingDeleteOne } from '../livergol-pill-taking-delete-one/livergol-pill-taking-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service'
import { LivergolPillTakingItemModel, PagedResult } from '../../models/livergol-pill-taking.model'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'livergol-pill-taking-list-all',
  imports: [LivergolPillTakingDeleteOne, DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule],
  templateUrl: './livergol-pill-taking-list-all.html',
  styleUrl: './livergol-pill-taking-list-all.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingListAll {
  protected readonly livergolPillTakingService = inject(LivergolPillTakingService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: LivergolPillTakingItemModel[] = []

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

  refreshAfterCreate() {
    this.refresh()
  }

  refreshAfterDelete() {
    this.refresh()
  }

  private loadPage() {
    this.livergolPillTakingService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<LivergolPillTakingItemModel>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
