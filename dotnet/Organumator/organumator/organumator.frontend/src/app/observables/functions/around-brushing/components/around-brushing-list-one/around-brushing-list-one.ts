import { Component, EventEmitter, Input, Output } from '@angular/core'
import { AroundBrushingItemModel } from '../../../../../around-brushing/models/around-brushing.model'
import { AroundBrushingDeleteOne } from '../around-brushing-delete-one/around-brushing-delete-one'

@Component({
  selector: 'around-brushing-list-one',
  imports: [AroundBrushingDeleteOne],
  templateUrl: './around-brushing-list-one.html',
  styleUrl: './around-brushing-list-one.scss',
})
export class AroundBrushingListOne {
  @Input() item!: AroundBrushingItemModel
  @Output() deleted = new EventEmitter<void>()
}
