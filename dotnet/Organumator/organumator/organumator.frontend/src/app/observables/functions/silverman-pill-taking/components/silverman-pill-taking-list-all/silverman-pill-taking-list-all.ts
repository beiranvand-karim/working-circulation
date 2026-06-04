import { Component, inject } from '@angular/core'
import { SilvermanPillTakingItemModel, PagedResult } from '../../models/silverman-pill-taking.model'
import { SilvermanPillTakingService } from '../../services/silverman-pill-taking.service'
import { SilvermanPillTakingDeleteOne } from '../silverman-pill-taking-delete-one/silverman-pill-taking-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'silverman-pill-taking-list-all',
  imports: [SilvermanPillTakingDeleteOne, DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule],
  templateUrl: './silverman-pill-taking-list-all.html',
  styleUrl: './silverman-pill-taking-list-all.scss',
  providers: [SilvermanPillTakingService],
})
export class SilvermanPillTakingListAll {
  private silvermanPillTaking = inject(SilvermanPillTakingService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: SilvermanPillTakingItemModel[] = []

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

  private loadPage() {
    this.silvermanPillTaking.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<SilvermanPillTakingItemModel>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
