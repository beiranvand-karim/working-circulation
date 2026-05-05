import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FaceHydrationItemModel } from '../../models/face-hydration.model';
import { FaceHydrationDeleteOne } from "../face-hydration-delete-one/face-hydration-delete-one";

@Component({
  selector: 'face-hydration-list-one',
  imports: [FaceHydrationDeleteOne],
  templateUrl: './face-hydration-list-one.html',
  styleUrl: './face-hydration-list-one.scss',
})
export class FaceHydrationListOne {
  @Input() item!: FaceHydrationItemModel
  @Output() deleted = new EventEmitter<void>()
}
