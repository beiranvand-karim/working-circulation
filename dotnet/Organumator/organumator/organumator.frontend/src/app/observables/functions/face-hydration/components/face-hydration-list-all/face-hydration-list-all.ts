import { Component, inject } from '@angular/core';
import { FaceHydrationService } from '../../services/face-hydration.service';
import { FaceHydrationItemModel } from '../../models/face-hydration.model';
import { Observable } from 'rxjs';
import { FaceHydrationListOne } from "../face-hydration-list-one/face-hydration-list-one";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'face-hydration-list-all',
  imports: [FaceHydrationListOne, CommonModule],
  templateUrl: './face-hydration-list-all.html',
  styleUrl: './face-hydration-list-all.scss',
  providers: [FaceHydrationService],
})
export class FaceHydrationListAll {
  protected readonly faceHydrationService = inject(FaceHydrationService)

  protected faceHydrationItems$: Observable<FaceHydrationItemModel[]>
    = this.faceHydrationService.getAll() as Observable<FaceHydrationItemModel[]>

  getAll() {
    this.faceHydrationItems$ = this.faceHydrationService.getAll()
  }

  refresh() {
    this.getAll()
  }
}
