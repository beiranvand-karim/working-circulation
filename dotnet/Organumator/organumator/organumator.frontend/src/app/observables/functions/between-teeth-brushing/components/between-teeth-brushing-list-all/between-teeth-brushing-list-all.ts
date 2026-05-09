import { Component, inject, OnDestroy } from '@angular/core'
import { Subject } from 'rxjs'
import { BetweenTeethBrushingService } from '../../services/between-teeth-brushing.service'
import { BetweenTeethBrushingListOne } from '../between-teeth-brushing-list-one/between-teeth-brushing-list-one'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'between-teeth-brushing-list-all',
  imports: [BetweenTeethBrushingListOne, CommonModule],
  templateUrl: './between-teeth-brushing-list-all.html',
  styleUrl: './between-teeth-brushing-list-all.scss',
  providers: [BetweenTeethBrushingService],
})
export class BetweenTeethBrushingListAll implements OnDestroy {
  private readonly destroy$ = new Subject<void>()

  private readonly betweenTeethBrushingService = inject(
    BetweenTeethBrushingService
  )
  betweenTeethBrushings$ = this.betweenTeethBrushingService.getAll()

  refresh() {
    this.getAll()
  }

  getAll() {
    this.betweenTeethBrushings$ = this.betweenTeethBrushingService.getAll()
  }

  ngOnDestroy(): void {
    // Cleanup logic if needed
    this.destroy$.next()
    this.destroy$.complete()
  }
}
