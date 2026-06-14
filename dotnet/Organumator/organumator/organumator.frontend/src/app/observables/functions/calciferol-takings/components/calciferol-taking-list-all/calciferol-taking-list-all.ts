import { Component, inject, signal } from '@angular/core'
import { CalciferolPillTakingsService } from '../../services/calciferol-pill-takings.service'
import { CalciferolPillTakings, PagedResult } from '../../models/calciferol-pill-takings.model'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator'
import { CalciferolTakingDeleteOne } from '../calciferol-taking-delete-one/calciferol-taking-delete-one'
import { PAGINATION_PAGE_SIZE } from '../../../../../pagination.config'

@Component({
  selector: 'calciferol-taking-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, MatPaginatorModule, CalciferolTakingDeleteOne],
  templateUrl: './calciferol-taking-list-all.html',
  styleUrl: './calciferol-taking-list-all.scss',
  providers: [CalciferolPillTakingsService],
})
export class CalciferolTakingListAll {
  private readonly calciferolPillTakingsService = inject(CalciferolPillTakingsService)
  protected readonly defaultPageSize = inject(PAGINATION_PAGE_SIZE)

  displayedColumns = ['performedOnDate', 'actions']

  protected pageNumber = signal(1)
  protected pageSize = signal(this.defaultPageSize)
  protected totalCount = signal(0)
  protected totalPages = signal(0)
  protected items = signal<CalciferolPillTakings[]>([])

  constructor() {
    this.loadPage()
  }

  onPageChange(event: PageEvent) {
    this.pageNumber.set(event.pageIndex + 1)
    this.pageSize.set(event.pageSize)
    this.loadPage()
  }

  refresh() {
    this.loadPage()
  }

  private loadPage() {
    this.calciferolPillTakingsService.getAll(this.pageNumber(), this.pageSize()).subscribe({
      next: (result: PagedResult<CalciferolPillTakings>) => {
        this.items.set(result.items)
        this.totalCount.set(result.totalCount)
        this.totalPages.set(result.totalPages)
      },
    })
  }
}
