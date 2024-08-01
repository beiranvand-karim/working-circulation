import { Component } from '@angular/core';

export interface User {
  name: string;
}

@Component({
  selector: 'app-a-op',
  templateUrl: './a-op.component.html',
  styleUrl: './a-op.component.scss',
})
export class AOpComponent {
  user: User = { name: 'A' }

  changeName() {
    this.user.name = 'B'
  }
}
