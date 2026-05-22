import { Component } from '@angular/core'
import { VacuumCleaningListAll } from '../../components/vacuum-cleaning-list-all/vacuum-cleaning-list-all'
import { VacuumCleaningCreateOne } from '../../components/vacuum-cleaning-create-one/vacuum-cleaning-create-one'

@Component({
  selector: 'vacuum-cleanings-view',
  imports: [VacuumCleaningListAll, VacuumCleaningCreateOne],
  templateUrl: './vacuum-cleanings-view.html',
  styleUrl: './vacuum-cleanings-view.scss',
})
export class VacuumCleaningsView {}
