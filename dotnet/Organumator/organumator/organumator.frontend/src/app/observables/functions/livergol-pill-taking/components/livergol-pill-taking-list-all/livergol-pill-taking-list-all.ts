import { Component, inject } from '@angular/core'
import { LivergolPillTakingDeleteOne } from '../livergol-pill-taking-delete-one/livergol-pill-taking-delete-one'
import { DatePipe } from '@angular/common'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { LivergolPillTakingService } from '../../services/livergol-pill-taking.service'

@Component({
  selector: 'livergol-pill-taking-list-all',
  imports: [LivergolPillTakingDeleteOne, DatePipe, MatTableModule, MatButtonModule],
  templateUrl: './livergol-pill-taking-list-all.html',
  styleUrl: './livergol-pill-taking-list-all.scss',
  providers: [LivergolPillTakingService],
})
export class LivergolPillTakingListAll {
  protected readonly livergolPillTakingService = inject(LivergolPillTakingService)

  protected livergolPillTakings$ = this.livergolPillTakingService.getAll()
  displayedColumns = ['performedOnDate', 'actions']

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
