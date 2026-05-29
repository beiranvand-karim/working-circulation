import { Component } from '@angular/core'
import { SimcardChargingListAll } from '../../components/simcard-charging-list-all/simcard-charging-list-all'
import { SimcardChargingCreateOne } from '../../components/simcard-charging-create-one/simcard-charging-create-one'

@Component({
  selector: 'simcard-chargings-view',
  imports: [SimcardChargingListAll, SimcardChargingCreateOne],
  templateUrl: './simcard-chargings-view.html',
  styleUrl: './simcard-chargings-view.scss',
})
export class SimcardChargingsView {}
