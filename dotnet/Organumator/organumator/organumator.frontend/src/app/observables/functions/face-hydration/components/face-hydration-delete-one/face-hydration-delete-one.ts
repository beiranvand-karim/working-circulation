import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FaceHydrationService } from '../../services/face-hydration.service';

@Component({
  selector: 'face-hydration-delete-one',
  imports: [],
  templateUrl: './face-hydration-delete-one.html',
  styleUrl: './face-hydration-delete-one.scss',
})
export class FaceHydrationDeleteOne {
  private readonly faceHydrationService = inject(FaceHydrationService)
  @Input() itemId!: number
  @Output() deleted = new EventEmitter<void>()
  
  delete() {
    this.faceHydrationService.delete(this.itemId).subscribe(
      () => {
        console.log(`Item with id ${this.itemId} deleted successfully`)
        this.deleted.emit()
      },
      error =>
        console.error(`Failed to delete item with id ${this.itemId}:`, error)
    )
  }
}
