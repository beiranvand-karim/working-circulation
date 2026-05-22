import { Component, inject } from '@angular/core'
import { Observable } from 'rxjs'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { AroundBrushingItemModel } from '../../../../../around-brushing/models/around-brushing.model'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { AroundBrushingDeleteOne } from '../around-brushing-delete-one/around-brushing-delete-one'

@Component({
  selector: 'around-brushing-list-all',
  imports: [DatePipe, MatTableModule, MatButtonModule, AroundBrushingDeleteOne],
  templateUrl: './around-brushing-list-all.html',
  styleUrl: './around-brushing-list-all.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingListAll {
  protected readonly aroundBrushingService = inject(AroundBrushingService)

  protected aroundBrushingItems$: Observable<AroundBrushingItemModel[]> =
    this.aroundBrushingService.getAll()

  displayedColumns = ['performedOnDate', 'actions']

  getAll() {
    this.aroundBrushingItems$ = this.aroundBrushingService.getAll()
  }

  refresh() {
    this.getAll()
  }
}
