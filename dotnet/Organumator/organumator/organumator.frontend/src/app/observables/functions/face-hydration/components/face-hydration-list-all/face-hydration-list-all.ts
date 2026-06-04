import { Component, inject } from '@angular/core'
import { FaceHydrationService } from '../../services/face-hydration.service'
import { FaceHydrationItemModel, PagedResult } from '../../models/face-hydration.model'
import { FaceHydrationDeleteOne } from '../face-hydration-delete-one/face-hydration-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'face-hydration-list-all',
  imports: [FaceHydrationDeleteOne, DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule],
  templateUrl: './face-hydration-list-all.html',
  styleUrl: './face-hydration-list-all.scss',
  providers: [FaceHydrationService],
})
export class FaceHydrationListAll {
  protected readonly faceHydrationService = inject(FaceHydrationService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: FaceHydrationItemModel[] = []

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
    this.faceHydrationService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<FaceHydrationItemModel>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
