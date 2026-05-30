import { Component, EventEmitter, OnDestroy, inject, Output } from '@angular/core'
import { SimcardChargingService } from '../../services/simcard-charging.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'simcard-charging-create-one',
  imports: [MatButtonModule],
  templateUrl: './simcard-charging-create-one.html',
  styleUrl: './simcard-charging-create-one.scss',
  providers: [SimcardChargingService],
})
export class SimcardChargingCreateOne implements OnDestroy {
  private readonly simcardChargingService = inject(SimcardChargingService)
  private readonly destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  create() {
    this.simcardChargingService.create().pipe(takeUntil(this.destroy$)).subscribe({
      next: () => this.created.emit(),
      error: error => console.error('Failed to create item:', error),
    })
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
