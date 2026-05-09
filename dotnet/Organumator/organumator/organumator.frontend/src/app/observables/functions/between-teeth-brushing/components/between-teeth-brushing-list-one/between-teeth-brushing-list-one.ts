import { Component, EventEmitter, Input, Output } from '@angular/core'
import { BetweenTeethBrushing } from '../../models/between-teeth-brushing.model'
import { BetweenTeethBrushingDeleteOne } from '../between-teeth-brushing-delete-one/between-teeth-brushing-delete-one'

@Component({
  selector: 'between-teeth-brushing-list-one',
  imports: [BetweenTeethBrushingDeleteOne],
  templateUrl: './between-teeth-brushing-list-one.html',
  styleUrl: './between-teeth-brushing-list-one.scss',
})
export class BetweenTeethBrushingListOne {
  @Input() item!: BetweenTeethBrushing
  @Output() deleted = new EventEmitter<void>()
}
