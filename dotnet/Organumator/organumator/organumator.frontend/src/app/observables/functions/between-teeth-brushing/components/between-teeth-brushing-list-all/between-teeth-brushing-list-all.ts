import { Component, inject, OnDestroy } from '@angular/core'
import { Subject } from 'rxjs'
import { BetweenTeethBrushingService } from '../../services/between-teeth-brushing.service'
import { BetweenTeethBrushingDeleteOne } from '../between-teeth-brushing-delete-one/between-teeth-brushing-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'between-teeth-brushing-list-all',
  imports: [BetweenTeethBrushingDeleteOne, DatePipe, MatTableModule, MatButtonModule],
  templateUrl: './between-teeth-brushing-list-all.html',
  styleUrl: './between-teeth-brushing-list-all.scss',
  providers: [BetweenTeethBrushingService],
})
export class BetweenTeethBrushingListAll implements OnDestroy {
  private readonly destroy$ = new Subject<void>()
  private readonly betweenTeethBrushingService = inject(BetweenTeethBrushingService)

  betweenTeethBrushings$ = this.betweenTeethBrushingService.getAll()
  displayedColumns = ['performedOnDate', 'actions']

  refresh() {
    this.getAll()
  }

  getAll() {
    this.betweenTeethBrushings$ = this.betweenTeethBrushingService.getAll()
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
