import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AroundBrushing } from './around-brushing';
import { AroundBrushingCreateOne } from "./observables/around-brushing/components/around-brushing-create-one/around-brushing-create-one";
import { AroundBrushingListAll } from "./observables/around-brushing/components/around-brushing-list-all/around-brushing-list-all";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AroundBrushing, AroundBrushingCreateOne, AroundBrushingListAll],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('organumator.frontend');
}
