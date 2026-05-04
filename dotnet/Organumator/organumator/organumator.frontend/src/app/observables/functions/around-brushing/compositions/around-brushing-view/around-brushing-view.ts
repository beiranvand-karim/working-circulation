import { Component } from '@angular/core';
import { AroundBrushingListAll } from '../../components/around-brushing-list-all/around-brushing-list-all';
import { AroundBrushingCreateOne } from '../../components/around-brushing-create-one/around-brushing-create-one';

@Component({
  selector: 'around-brushing-view',
  imports: [AroundBrushingCreateOne, AroundBrushingListAll],
  templateUrl: './around-brushing-view.html',
  styleUrl: './around-brushing-view.scss',
})
export class AroundBrushingView {}
