import { Component, inject, OnDestroy } from '@angular/core'
import { VacuumCleaningsService } from '../../services/vacuum-cleanings.service'
import { Subject } from 'rxjs'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { VacuumCleaningDeleteOne } from '../vacuum-cleaning-delete-one/vacuum-cleaning-delete-one'

@Component({
  selector: 'vacuum-cleaning-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, VacuumCleaningDeleteOne],
  templateUrl: './vacuum-cleaning-list-all.html',
  styleUrl: './vacuum-cleaning-list-all.scss',
  providers: [VacuumCleaningsService],
})
export class VacuumCleaningListAll implements OnDestroy {
  private readonly vacuumCleaningsService = inject(VacuumCleaningsService)
  destroy$ = new Subject<void>()

  vacuumCleanings$ = this.vacuumCleaningsService.getAll()
  displayedColumns = ['performedOnDate', 'actions']

  refresh() {
    this.getAll()
  }

  getAll() {
    this.vacuumCleanings$ = this.vacuumCleaningsService.getAll()
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
