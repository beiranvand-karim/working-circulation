import { Component, EventEmitter, Input, Output } from '@angular/core'
import { CalciferolPillTakings } from '../../models/calciferol-pill-takings.model'
import { CalciferolTakingDeleteOne } from "../calciferol-taking-delete-one/calciferol-taking-delete-one";

@Component({
  selector: 'calciferol-taking-list-one',
  imports: [CalciferolTakingDeleteOne],
  templateUrl: './calciferol-taking-list-one.html',
  styleUrl: './calciferol-taking-list-one.scss',
})
export class CalciferolTakingListOne {
  @Input() item!: CalciferolPillTakings // You can replace 'any' with the actual type of your item

  @Output() deleted = new EventEmitter<void>()
}
