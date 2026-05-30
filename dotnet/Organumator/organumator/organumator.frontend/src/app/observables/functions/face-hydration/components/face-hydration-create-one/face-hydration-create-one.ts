import { Component, EventEmitter, OnDestroy, inject, Output } from '@angular/core'
import { FaceHydrationService } from '../../services/face-hydration.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'face-hydration-create-one',
  imports: [MatButtonModule],
  templateUrl: './face-hydration-create-one.html',
  styleUrl: './face-hydration-create-one.scss',
  providers: [FaceHydrationService],
})
export class FaceHydrationCreateOne implements OnDestroy {
  private readonly faceHydrationService = inject(FaceHydrationService)
  private readonly destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  create() {
    this.faceHydrationService.create().pipe(takeUntil(this.destroy$)).subscribe({
      next: () => this.created.emit(),
      error: error => console.error('Failed to create item:', error),
    })
  }

  ngOnDestroy(): void {
    this.destroy$.next()
    this.destroy$.complete()
  }
}
