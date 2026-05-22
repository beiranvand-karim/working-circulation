import { Component, EventEmitter, Input, Output } from '@angular/core'
import { VacuumCleanings } from '../../models/vacuum-cleanings.model'
import { VacuumCleaningDeleteOne } from '../vacuum-cleaning-delete-one/vacuum-cleaning-delete-one'
import { format, toZonedTime } from 'date-fns-tz'

@Component({
  selector: 'vacuum-cleaning-list-one',
  imports: [VacuumCleaningDeleteOne],
  templateUrl: './vacuum-cleaning-list-one.html',
  styleUrl: './vacuum-cleaning-list-one.scss',
})
export class VacuumCleaningListOne {
  @Input() item!: VacuumCleanings
  @Output() deleted = new EventEmitter<void>()

  formatLocalDate(date: string | Date): string {
    const tz = Intl.DateTimeFormat().resolvedOptions().timeZone
    return format(toZonedTime(new Date(date), tz), 'PPpp', { timeZone: tz })
  }
}
