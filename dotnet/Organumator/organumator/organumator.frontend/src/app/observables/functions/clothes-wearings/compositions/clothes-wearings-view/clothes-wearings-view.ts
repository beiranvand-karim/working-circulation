import { Component } from '@angular/core'
import { ClothesWearingListAll } from '../../components/clothes-wearing-list-all/clothes-wearing-list-all'
import { ClothesWearingCreateOne } from '../../components/clothes-wearing-create-one/clothes-wearing-create-one'

@Component({
  selector: 'clothes-wearings-view',
  imports: [ClothesWearingListAll, ClothesWearingCreateOne],
  templateUrl: './clothes-wearings-view.html',
  styleUrl: './clothes-wearings-view.scss',
})
export class ClothesWearingsView {}
