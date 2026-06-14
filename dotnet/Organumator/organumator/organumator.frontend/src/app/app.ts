import { Component } from '@angular/core'
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router'
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatButtonModule } from '@angular/material/button'
import { MatListModule } from '@angular/material/list'
import { EnvironmentIndicator } from './observables/functions/environment/components/environment-indicator/environment-indicator'

@Component({
  selector: 'app-root',
  imports: [RouterLink, RouterLinkActive, RouterOutlet, MatSidenavModule, MatToolbarModule, MatIconModule, MatButtonModule, MatListModule, EnvironmentIndicator],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {}
