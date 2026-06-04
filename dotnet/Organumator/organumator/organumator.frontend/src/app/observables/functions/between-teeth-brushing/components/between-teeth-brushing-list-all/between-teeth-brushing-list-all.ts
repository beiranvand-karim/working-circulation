import { Component, inject } from '@angular/core'
import { BetweenTeethBrushingService } from '../../services/between-teeth-brushing.service'
import { BetweenTeethBrushing, PagedResult } from '../../models/between-teeth-brushing.model'
import { BetweenTeethBrushingDeleteOne } from '../between-teeth-brushing-delete-one/between-teeth-brushing-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'between-teeth-brushing-list-all',
  imports: [BetweenTeethBrushingDeleteOne, DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule],
  templateUrl: './between-teeth-brushing-list-all.html',
  styleUrl: './between-teeth-brushing-list-all.scss',
  providers: [BetweenTeethBrushingService],
})
export class BetweenTeethBrushingListAll {
  private readonly betweenTeethBrushingService = inject(BetweenTeethBrushingService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: BetweenTeethBrushing[] = []

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
    this.betweenTeethBrushingService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<BetweenTeethBrushing>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
