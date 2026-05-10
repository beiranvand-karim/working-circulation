import { Component, inject, OnDestroy } from '@angular/core';
import { CalciferolPillTakingsService } from '../../services/calciferol-pill-takings.service';
import { Subject } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { CalciferolTakingListOne } from '../calciferol-taking-list-one/calciferol-taking-list-one';

@Component({
  selector: 'calciferol-taking-list-all',
  imports: [AsyncPipe, CalciferolTakingListOne],
  templateUrl: './calciferol-taking-list-all.html',
  styleUrl: './calciferol-taking-list-all.scss',
  providers: [CalciferolPillTakingsService],
})
export class CalciferolTakingListAll implements OnDestroy {
 private readonly calciferolPillTakingsService = inject(CalciferolPillTakingsService)
  destroy$ = new Subject<void>

  calciferolPillTakings$ = this.calciferolPillTakingsService.getAll()

  refresh() {
    this.getAll()
  }

  getAll() {
    this.calciferolPillTakings$ = this.calciferolPillTakingsService.getAll()
  }
  
  ngOnDestroy(): void {
    
    this.destroy$.next()
    this.destroy$.complete()
  }

}
