import { Component, inject } from '@angular/core'
import { Router, RouterOutlet } from '@angular/router'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'cleanups-view',
  imports: [RouterOutlet, MatButtonModule, MatIconModule],
  templateUrl: './cleanups-view.html',
  styleUrl: './cleanups-view.scss',
})
export class CleanupsView {
  private readonly router = inject(Router)

  back() {
    this.router.navigate(['/cleanups/days'])
  }

  forward() {
    this.router.navigate(['/cleanups/list'])
  }
}
