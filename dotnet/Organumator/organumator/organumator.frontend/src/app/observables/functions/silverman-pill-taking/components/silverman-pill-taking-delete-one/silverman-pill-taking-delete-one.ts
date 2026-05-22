import { Component, EventEmitter, inject, Input, OnDestroy, Output } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { SilvermanPillTakingService } from '../../services/silverman-pill-taking.service';
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'silverman-pill-taking-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './silverman-pill-taking-delete-one.html',
  styleUrl: './silverman-pill-taking-delete-one.scss',
  providers: [SilvermanPillTakingService],
})
export class SilvermanPillTakingDeleteOne implements OnDestroy {
  @Input() itemId!: number
  @Output() deleted = new EventEmitter<void>()

  private readonly destroy$ = new Subject<void>()
  private readonly silvermanPillTakingService = inject(SilvermanPillTakingService)
  

  deleteItem() {
    this.silvermanPillTakingService.delete(this.itemId).pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => {
        console.log(`Item with id ${this.itemId} deleted successfully`)
        this.deleted.emit()
      },
      error: error =>
        console.error(`Failed to delete item with id ${this.itemId}:`, error),
    })

  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
