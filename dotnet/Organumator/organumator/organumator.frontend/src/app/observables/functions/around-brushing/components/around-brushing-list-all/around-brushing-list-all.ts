import { Component, inject } from '@angular/core'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { AroundBrushingItemModel, PagedResult } from '../../../../../around-brushing/models/around-brushing.model'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { AroundBrushingDeleteOne } from '../around-brushing-delete-one/around-brushing-delete-one'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'around-brushing-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule, AroundBrushingDeleteOne],
  templateUrl: './around-brushing-list-all.html',
  styleUrl: './around-brushing-list-all.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingListAll {
  protected readonly aroundBrushingService = inject(AroundBrushingService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: AroundBrushingItemModel[] = []

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
    this.aroundBrushingService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<AroundBrushingItemModel>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
