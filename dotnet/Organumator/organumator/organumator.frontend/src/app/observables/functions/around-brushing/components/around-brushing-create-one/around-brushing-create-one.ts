import { Component, EventEmitter, OnDestroy, Output, inject } from '@angular/core'
import { AroundBrushingService } from '../../services/around-brushing.service'
import { Subject } from 'rxjs'

@Component({
  selector: 'around-brushing-create-one',
  imports: [],
  templateUrl: './around-brushing-create-one.html',
  styleUrl: './around-brushing-create-one.scss',
  providers: [AroundBrushingService],
})
export class AroundBrushingCreateOne implements OnDestroy {
  protected readonly aroundBrushingService = inject(AroundBrushingService)

  @Output() created = new EventEmitter<void>()
  private readonly destroy$ = new Subject<void>()


  create() {
    this.aroundBrushingService.create().subscribe({
      next: () => this.created.emit(),
      error: error => console.error('Failed to create item:', error)
    })
  }

  ngOnDestroy(): void {
    // Clean up any subscriptions if necessary
    this.destroy$.next()
    this.destroy$.complete()
  }
}
