import { Component } from '@angular/core'
import { RouterLink, RouterOutlet } from '@angular/router'
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatButtonModule } from '@angular/material/button'
import { MatListModule } from '@angular/material/list'

@Component({
  selector: 'app-root',
  imports: [RouterLink, RouterOutlet, MatSidenavModule, MatToolbarModule, MatIconModule, MatButtonModule, MatListModule],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {}
