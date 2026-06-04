import { Component, inject } from '@angular/core'
import { VacuumCleaningsService } from '../../services/vacuum-cleanings.service'
import { VacuumCleanings, PagedResult } from '../../models/vacuum-cleanings.model'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { VacuumCleaningDeleteOne } from '../vacuum-cleaning-delete-one/vacuum-cleaning-delete-one'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'vacuum-cleaning-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule, VacuumCleaningDeleteOne],
  templateUrl: './vacuum-cleaning-list-all.html',
  styleUrl: './vacuum-cleaning-list-all.scss',
  providers: [VacuumCleaningsService],
})
export class VacuumCleaningListAll {
  private readonly vacuumCleaningsService = inject(VacuumCleaningsService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: VacuumCleanings[] = []

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
    this.vacuumCleaningsService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<VacuumCleanings>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
