import { Component } from '@angular/core';
import { BetweenTeethBrushingListAll } from "../../components/between-teeth-brushing-list-all/between-teeth-brushing-list-all";
import { BetweenTeethBrushingCreateOne } from "../../components/between-teeth-brushing-create-one/between-teeth-brushing-create-one";

@Component({
  selector: 'between-teeth-brushing-view',
  imports: [BetweenTeethBrushingListAll, BetweenTeethBrushingCreateOne],
  templateUrl: './between-teeth-brushing-view.html',
  styleUrl: './between-teeth-brushing-view.scss',
})
export class BetweenTeethBrushingView {}
