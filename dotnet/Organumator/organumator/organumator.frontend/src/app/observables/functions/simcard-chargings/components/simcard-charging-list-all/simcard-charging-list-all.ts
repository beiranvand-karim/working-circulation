import { Component, inject } from '@angular/core'
import { SimcardChargingService } from '../../services/simcard-charging.service'
import { SimcardChargingItemModel, PagedResult } from '../../models/simcard-charging.model'
import { SimcardChargingDeleteOne } from '../simcard-charging-delete-one/simcard-charging-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'simcard-charging-list-all',
  imports: [SimcardChargingDeleteOne, DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule],
  templateUrl: './simcard-charging-list-all.html',
  styleUrl: './simcard-charging-list-all.scss',
  providers: [SimcardChargingService],
})
export class SimcardChargingListAll {
  protected readonly simcardChargingService = inject(SimcardChargingService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['chargedAt', 'actions']

  protected pageNumber = 1
  protected pageSize = this.defaultPageSize
  protected totalCount = 0
  protected totalPages = 0
  protected items: SimcardChargingItemModel[] = []

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
    this.simcardChargingService.getAll(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<SimcardChargingItemModel>) => {
        this.items = result.items
        this.totalCount = result.totalCount
        this.totalPages = result.totalPages
      },
    })
  }
}
