import { Component, inject, OnInit } from '@angular/core'
import { Observable } from 'rxjs'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { AroundBrushingItemModel } from '../../../../../around-brushing/models/around-brushing.model'
import { CommonModule } from '@angular/common'
import { AroundBrushingListOne } from '../around-brushing-list-one/around-brushing-list-one'

@Component({
  selector: 'around-brushing-list-all',
  imports: [CommonModule, AroundBrushingListOne],
  templateUrl: './around-brushing-list-all.html',
  styleUrl: './around-brushing-list-all.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingListAll {
  protected readonly aroundBrushingService = inject(AroundBrushingService)

  protected aroundBrushingItems$: Observable<AroundBrushingItemModel[]> =
    this.aroundBrushingService.getAll()

  getAll() {
    this.aroundBrushingItems$ = this.aroundBrushingService.getAll()
  }

  refresh() {
    this.getAll()
  }
}
