import { Component, inject } from '@angular/core'
import { AroundBrushingService } from '../../services/around-brushing.service'

@Component({
  selector: 'around-brushing',
  imports: [],
  templateUrl: './around-brushing.html',
  styleUrl: './around-brushing.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushing {
  private readonly aroundBrushingService = inject(AroundBrushingService)

  apiData = this.aroundBrushingService.rxResourceData
}
  