import { Component, inject, OnDestroy } from '@angular/core'
import { VacuumCleaningsService } from '../../services/vacuum-cleanings.service'
import { Subject } from 'rxjs'
import { AsyncPipe } from '@angular/common'
import { VacuumCleaningListOne } from '../vacuum-cleaning-list-one/vacuum-cleaning-list-one'

@Component({
  selector: 'vacuum-cleaning-list-all',
  imports: [AsyncPipe, VacuumCleaningListOne],
  templateUrl: './vacuum-cleaning-list-all.html',
  styleUrl: './vacuum-cleaning-list-all.scss',
  providers: [VacuumCleaningsService],
})
export class VacuumCleaningListAll implements OnDestroy {
  private readonly vacuumCleaningsService = inject(VacuumCleaningsService)
  destroy$ = new Subject<void>()

  vacuumCleanings$ = this.vacuumCleaningsService.getAll()

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
