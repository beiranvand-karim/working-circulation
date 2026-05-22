import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { BetweenTeethBrushingService } from '../../services/between-teeth-brushing.service';
import { Subject } from 'rxjs';
import { MatButtonModule } from '@angular/material/button'

@Component({
  selector: 'between-teeth-brushing-create-one',
  imports: [MatButtonModule],
  templateUrl: './between-teeth-brushing-create-one.html',
  styleUrl: './between-teeth-brushing-create-one.scss',
  providers: [BetweenTeethBrushingService],
})
export class BetweenTeethBrushingCreateOne implements OnDestroy {
  private readonly destroy$ = new Subject<void>()
  @Output() created = new EventEmitter<void>()

  constructor(private readonly betweenTeethBrushingService: BetweenTeethBrushingService) { }
  
  create() {
    this.betweenTeethBrushingService.create().subscribe({
      next: () => {
        console.log('Between teeth brushing created successfully');
        this.created.emit();
      },
      error: err => console.error('Error creating between teeth brushing:', err),
    });
  }

  ngOnDestroy(): void {
    // Cleanup logic if needed
    this.destroy$.next()
    this.destroy$.complete()
  }
}
