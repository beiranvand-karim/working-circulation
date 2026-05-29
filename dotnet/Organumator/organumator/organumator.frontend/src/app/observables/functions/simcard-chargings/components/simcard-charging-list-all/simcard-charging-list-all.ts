import { Component, inject } from '@angular/core'
import { SimcardChargingService } from '../../services/simcard-charging.service'
import { SimcardChargingItemModel } from '../../models/simcard-charging.model'
import { Observable } from 'rxjs'
import { SimcardChargingDeleteOne } from '../simcard-charging-delete-one/simcard-charging-delete-one'
import { AsyncPipe, DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'simcard-charging-list-all',
  imports: [SimcardChargingDeleteOne, DatePipe, AsyncPipe, MatTableModule, MatButtonModule],
  templateUrl: './simcard-charging-list-all.html',
  styleUrl: './simcard-charging-list-all.scss',
  providers: [SimcardChargingService],
})
export class SimcardChargingListAll {
  protected readonly simcardChargingService = inject(SimcardChargingService)

  protected items$: Observable<SimcardChargingItemModel[]> =
    this.simcardChargingService.getAll()

  displayedColumns = ['chargedAt', 'actions']

  refresh() {
    this.items$ = this.simcardChargingService.getAll()
  }
}
