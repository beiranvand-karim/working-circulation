import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AroundBrushing } from './around-brushing';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AroundBrushing],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('organumator.frontend');
}
