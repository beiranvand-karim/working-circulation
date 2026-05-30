import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core'
import { ClothesWearingService } from '../../services/clothes-wearing.service'
import { Subject, takeUntil } from 'rxjs'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { MatDialog } from '@angular/material/dialog'
import { MatDialogModule } from '@angular/material/dialog'

@Component({
  selector: 'clothes-wearing-delete-one',
  imports: [MatButtonModule, MatIconModule, MatDialogModule],
  templateUrl: './clothes-wearing-delete-one.html',
  styleUrl: './clothes-wearing-delete-one.scss',
  providers: [ClothesWearingService],
})
export class ClothesWearingDeleteOne implements OnDestroy {
  private destroy$ = new Subject<void>()
  @Output() deleted = new EventEmitter<void>()
  @Input() itemId: number | null = null

  constructor(private clothesWearingService: ClothesWearingService, private dialog: MatDialog) {}

  delete(id: number) {
    const ref = this.dialog.open(ClothesWearingDeleteConfirm)
    ref.afterClosed().pipe(takeUntil(this.destroy$)).subscribe(confirmed => {
      if (!confirmed) return
      this.clothesWearingService
        .delete(id)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: () => this.deleted.emit(),
          error: err => console.error('Error deleting clothes wearing:', err),
        })
    })
  }

  ngOnDestroy() {
    this.destroy$.next()
    this.destroy$.complete()
  }
}

@Component({
  template: `
    <h2 mat-dialog-title>Delete</h2>
    <mat-dialog-content>Are you sure you want to delete this record?</mat-dialog-content>
    <mat-dialog-actions align="end">
      <button mat-button [mat-dialog-close]="false">Cancel</button>
      <button mat-button color="warn" [mat-dialog-close]="true">Delete</button>
    </mat-dialog-actions>
  `,
  imports: [MatDialogModule, MatButtonModule],
})
export class ClothesWearingDeleteConfirm {}
