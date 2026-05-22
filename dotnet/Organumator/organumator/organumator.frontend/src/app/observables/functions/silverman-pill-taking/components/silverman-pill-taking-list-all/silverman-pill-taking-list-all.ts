import { Component, inject } from '@angular/core'
import { SilvermanPillTakingItemModel } from '../../models/silverman-pill-taking.model'
import { Observable } from 'rxjs'
import { SilvermanPillTakingService } from '../../services/silverman-pill-taking.service'
import { SilvermanPillTakingDeleteOne } from '../silverman-pill-taking-delete-one/silverman-pill-taking-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'

@Component({
  selector: 'silverman-pill-taking-list-all',
  imports: [SilvermanPillTakingDeleteOne, DatePipe, MatTableModule],
  templateUrl: './silverman-pill-taking-list-all.html',
  styleUrl: './silverman-pill-taking-list-all.scss',
  providers: [SilvermanPillTakingService],
})
export class SilvermanPillTakingListAll {
  private silvermanPillTaking = inject(SilvermanPillTakingService)

  protected silvermanPillTakingItems$: Observable<SilvermanPillTakingItemModel[]> =
    this.silvermanPillTaking.getAll()

  displayedColumns = ['performedOnDate', 'actions']

  getAll() {
    this.silvermanPillTakingItems$ = this.silvermanPillTaking.getAll()
  }

  refresh() {
    this.getAll()
  }
}
