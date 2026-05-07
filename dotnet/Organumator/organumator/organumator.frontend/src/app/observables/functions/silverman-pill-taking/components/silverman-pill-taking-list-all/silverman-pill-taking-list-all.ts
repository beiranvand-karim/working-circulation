import { Component, inject } from '@angular/core'
import { SilvermanPillTakingItemModel } from '../../models/silverman-pill-taking.model'
import { Observable } from 'rxjs'
import { SilvermanPillTakingService } from '../../services/silverman-pill-taking.service'
import { SilvermanPillTakingListOne } from '../silverman-pill-taking-list-one/silverman-pill-taking-list-one'
import { AsyncPipe } from '@angular/common'

@Component({
  selector: 'silverman-pill-taking-list-all',
  imports: [SilvermanPillTakingListOne, AsyncPipe],
  templateUrl: './silverman-pill-taking-list-all.html',
  styleUrl: './silverman-pill-taking-list-all.scss',
  providers: [SilvermanPillTakingService],
})
export class SilvermanPillTakingListAll {
  private silvermanPillTaking = inject(SilvermanPillTakingService)

  protected silvermanPillTakingItems$: Observable<
    SilvermanPillTakingItemModel[]
  > = this.silvermanPillTaking.getAll()

  getAll() {
    this.silvermanPillTakingItems$ = this.silvermanPillTaking.getAll()
  }

  refresh() {
    this.getAll()
  }
}
