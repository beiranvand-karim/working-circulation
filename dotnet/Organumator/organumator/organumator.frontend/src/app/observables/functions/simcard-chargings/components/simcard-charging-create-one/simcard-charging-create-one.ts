import { Component, EventEmitter, inject, Output } from '@angular/core'
import { SimcardChargingService } from '../../services/simcard-charging.service'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'simcard-charging-create-one',
  imports: [MatButtonModule],
  templateUrl: './simcard-charging-create-one.html',
  styleUrl: './simcard-charging-create-one.scss',
  providers: [SimcardChargingService],
})
export class SimcardChargingCreateOne {
  private readonly simcardChargingService = inject(SimcardChargingService)
  @Output() created = new EventEmitter<void>()

  create() {
    this.simcardChargingService.create().subscribe({
      next: () => {
        console.log('Item created successfully')
        this.created.emit()
      },
      error: error => console.error('Failed to create item:', error),
    })
  }
}
