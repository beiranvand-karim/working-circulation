import { Component, inject, signal } from '@angular/core'
import { EnvironmentService } from '../../services/environment.service'
import { EnvironmentInfo } from '../../models/environment.model'

@Component({
  selector: 'environment-indicator',
  imports: [],
  templateUrl: './environment-indicator.html',
  styleUrl: './environment-indicator.scss',
  providers: [EnvironmentService],
})
export class EnvironmentIndicator {
  private readonly environmentService = inject(EnvironmentService)

  protected environment = signal<string | null>(null)

  constructor() {
    this.environmentService.getCurrent().subscribe({
      next: (result: EnvironmentInfo) => this.environment.set(result.environment),
    })
  }
}
