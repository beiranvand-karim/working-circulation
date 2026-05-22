import { Component, inject } from '@angular/core'
import { FaceHydrationService } from '../../services/face-hydration.service'
import { FaceHydrationItemModel } from '../../models/face-hydration.model'
import { Observable } from 'rxjs'
import { FaceHydrationDeleteOne } from '../face-hydration-delete-one/face-hydration-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'

@Component({
  selector: 'face-hydration-list-all',
  imports: [FaceHydrationDeleteOne, DatePipe, MatTableModule],
  templateUrl: './face-hydration-list-all.html',
  styleUrl: './face-hydration-list-all.scss',
  providers: [FaceHydrationService],
})
export class FaceHydrationListAll {
  protected readonly faceHydrationService = inject(FaceHydrationService)

  protected faceHydrationItems$: Observable<FaceHydrationItemModel[]> =
    this.faceHydrationService.getAll() as Observable<FaceHydrationItemModel[]>

  displayedColumns = ['performedOnDate', 'actions']

  getAll() {
    this.faceHydrationItems$ = this.faceHydrationService.getAll()
  }

  refresh() {
    this.getAll()
  }
}
