import { Component, EventEmitter, OnDestroy, Output } from '@angular/core'
import { ClothesWearingService } from '../../services/clothes-wearing.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatDatepickerModule } from '@angular/material/datepicker'
import { DateAdapter, MAT_DATE_FORMATS, NativeDateAdapter } from '@angular/material/core'
import { FormsModule } from '@angular/forms'

class YmdDateAdapter extends NativeDateAdapter {
  override format(date: Date): string {
    const y = date.getFullYear()
    const m = String(date.getMonth() + 1).padStart(2, '0')
    const d = String(date.getDate()).padStart(2, '0')
    return `${y}-${m}-${d}`
  }
}

const YMD_DATE_FORMATS = {
  parse: { dateInput: null },
  display: {
    dateInput: {},
    monthYearLabel: { year: 'numeric', month: 'short' } as Intl.DateTimeFormatOptions,
    dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' } as Intl.DateTimeFormatOptions,
    monthYearA11yLabel: { year: 'numeric', month: 'long' } as Intl.DateTimeFormatOptions,
  },
}

@Component({
  selector: 'clothes-wearing-create-one',
  imports: [MatButtonModule, MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule],
  templateUrl: './clothes-wearing-create-one.html',
  styleUrl: './clothes-wearing-create-one.scss',
  providers: [
    ClothesWearingService,
    { provide: DateAdapter, useClass: YmdDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: YMD_DATE_FORMATS },
  ],
})
export class ClothesWearingCreateOne implements OnDestroy {
  private destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  differentiator = ''
  startDate: Date | null = new Date()

  constructor(private clothesWearingService: ClothesWearingService) {}

  get isValid(): boolean {
    return !!this.differentiator && !!this.startDate
  }

  create() {
    this.clothesWearingService
      .add({
        id: 0,
        differentiator: this.differentiator,
        wearingStart: this.startDate!.toISOString(),
        wearingFinish: null,
      })
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.differentiator = ''
          this.startDate = null
          this.created.emit()
        },
        error: err => console.error('Error creating clothes wearing:', err),
      })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
