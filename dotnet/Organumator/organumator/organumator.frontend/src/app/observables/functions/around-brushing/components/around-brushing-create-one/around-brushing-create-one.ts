import { Component, EventEmitter, Output, inject } from '@angular/core'
import { AroundBrushingService } from '../../services/around-brushing.service'

@Component({
  selector: 'around-brushing-create-one',
  imports: [],
  templateUrl: './around-brushing-create-one.html',
  styleUrl: './around-brushing-create-one.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingCreateOne {
  protected readonly aroundBrushingService = inject(AroundBrushingService)

  @Output() created = new EventEmitter<void>()

  create() {
    this.aroundBrushingService.create().subscribe(
      () => this.created.emit(),
      error => console.error('Failed to create item:', error)
    )
  }
}
