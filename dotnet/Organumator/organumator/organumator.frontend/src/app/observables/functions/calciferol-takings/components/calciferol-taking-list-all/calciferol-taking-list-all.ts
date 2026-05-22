import { Component, inject, OnDestroy } from '@angular/core'
import { CalciferolPillTakingsService } from '../../services/calciferol-pill-takings.service'
import { Subject } from 'rxjs'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { CalciferolTakingDeleteOne } from '../calciferol-taking-delete-one/calciferol-taking-delete-one'

@Component({
  selector: 'calciferol-taking-list-all',
  imports: [DatePipe, MatTableModule, CalciferolTakingDeleteOne],
  templateUrl: './calciferol-taking-list-all.html',
  styleUrl: './calciferol-taking-list-all.scss',
  providers: [CalciferolPillTakingsService],
})
export class CalciferolTakingListAll implements OnDestroy {
  private readonly calciferolPillTakingsService = inject(CalciferolPillTakingsService)
  destroy$ = new Subject<void>()

  calciferolPillTakings$ = this.calciferolPillTakingsService.getAll()
  displayedColumns = ['performedOnDate', 'actions']

  refresh() {
    this.getAll()
  }

  getAll() {
    this.calciferolPillTakings$ = this.calciferolPillTakingsService.getAll()
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
