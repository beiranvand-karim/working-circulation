import { Component, inject, OnDestroy, OnInit } from '@angular/core'
import { Observable, Subject, takeUntil } from 'rxjs'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { AroundBrushingItemModel } from '../../../../around-brushing/models/around-brushing.model'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'around-brushing-list-all',
  imports: [CommonModule],
  templateUrl: './around-brushing-list-all.html',
  styleUrl: './around-brushing-list-all.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingListAll implements OnInit, OnDestroy {
  protected readonly aroundBrushingService = inject(AroundBrushingService)

  protected readonly aroundBrushingItems$: Observable<
    AroundBrushingItemModel[]
  > = this.aroundBrushingService.getAll() as Observable<
    AroundBrushingItemModel[]
    >
  
  private readonly destroy$ = new Subject<void>()

  ngOnInit(): void {
    this.aroundBrushingItems$.pipe(takeUntil(this.destroy$)).subscribe((items: AroundBrushingItemModel[]) =>
      console.log(items)
    )
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
