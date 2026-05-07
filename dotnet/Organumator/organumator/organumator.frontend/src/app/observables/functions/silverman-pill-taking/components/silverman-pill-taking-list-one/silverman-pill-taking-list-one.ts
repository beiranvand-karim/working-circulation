import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SilvermanPillTakingItemModel } from '../../models/silverman-pill-taking.model';
import { SilvermanPillTakingDeleteOne } from "../silverman-pill-taking-delete-one/silverman-pill-taking-delete-one";

@Component({
  selector: 'silverman-pill-taking-list-one',
  imports: [SilvermanPillTakingDeleteOne],
  templateUrl: './silverman-pill-taking-list-one.html',
  styleUrl: './silverman-pill-taking-list-one.scss',
})
export class SilvermanPillTakingListOne {
  @Input() item!: SilvermanPillTakingItemModel
  @Output() deleted = new EventEmitter<void>()

  onDelete() {
    this.deleted.emit();
  }
}
