import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core';
import { CalciferolPillTakingsService } from '../../services/calciferol-pill-takings.service';
import { Subject, takeUntil } from 'rxjs';
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'calciferol-taking-delete-one',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './calciferol-taking-delete-one.html',
  styleUrl: './calciferol-taking-delete-one.scss',
  providers: [CalciferolPillTakingsService]
})
export class CalciferolTakingDeleteOne implements OnDestroy {
  private destroy$ = new Subject<void>();
  @Output() deleted = new EventEmitter<void>();
  @Input() itemId: number | null = null;
  constructor(private calciferolPillTakingsService: CalciferolPillTakingsService) {}

  deleteCalciferolPillTaking(id: number) {
    this.calciferolPillTakingsService.delete(id).pipe(
      takeUntil(this.destroy$)
    ).subscribe({next: () => {
      this.deleted.emit();
    },
    error: (err) => {
      console.error('Error deleting calciferol pill taking:', err);
    }});
  }

  ngOnDestroy() {
    // Clean up any subscriptions or resources if needed
    this.destroy$.next();
    this.destroy$.complete(); 

  }
}
