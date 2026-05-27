import { Component, EventEmitter, Input, Output } from '@angular/core'
import { CleanupsModel } from '../../models/cleanups.model'
import { CleanupDeleteOne } from '../cleanup-delete-one/cleanup-delete-one'
import { format, toZonedTime } from 'date-fns-tz'

@Component({
  selector: 'cleanup-list-one',
  imports: [CleanupDeleteOne],
  templateUrl: './cleanup-list-one.html',
  styleUrl: './cleanup-list-one.scss',
})
export class CleanupListOne {
  @Input() item!: CleanupsModel
  @Output() deleted = new EventEmitter<void>()

  formatLocalDate(date: string | Date): string {
    const tz = Intl.DateTimeFormat().resolvedOptions().timeZone
    return format(toZonedTime(new Date(date), tz), 'PPpp', { timeZone: tz })
  }
}
