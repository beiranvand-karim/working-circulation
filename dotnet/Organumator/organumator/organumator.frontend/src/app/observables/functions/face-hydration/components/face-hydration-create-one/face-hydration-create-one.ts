import { Component, EventEmitter, inject, Output } from '@angular/core'
import { FaceHydrationService } from '../../services/face-hydration.service'

@Component({
  selector: 'face-hydration-create-one',
  imports: [],
  templateUrl: './face-hydration-create-one.html',
  styleUrl: './face-hydration-create-one.scss',
  providers: [FaceHydrationService],
})
export class FaceHydrationCreateOne {
  private readonly faceHydrationService = inject(FaceHydrationService)
  @Output() created = new EventEmitter<void>()


  create() {
    this.faceHydrationService.create().subscribe(
      () => {
        console.log('Item created successfully')
        this.created.emit()
      },
      error => console.error('Failed to create item:', error)
    )
  }
}
