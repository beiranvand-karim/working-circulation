import { Component, inject } from '@angular/core'
import { LivergolPillTakingDeleteOne } from '../livergol-pill-taking-delete-one/livergol-pill-taking-delete-one'
import { AsyncPipe } from '@angular/common'
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service'

@Component({
  selector: 'livergol-pill-taking-list-all',
  imports: [LivergolPillTakingDeleteOne, AsyncPipe],
  templateUrl: './livergol-pill-taking-list-all.html',
  styleUrl: './livergol-pill-taking-list-all.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingListAll {
  protected readonly livergolPillTakingService = inject(
    LivergolPillTakingService
  )

  protected livergolPillTakings$ = this.livergolPillTakingService.getAll()

  refresh() {
    this.livergolPillTakings$ = this.livergolPillTakingService.getAll()
  }
  refreshAfterCreate() {
    this.refresh()
  }

  refreshAfterDelete() {
    this.refresh()
  }
}
