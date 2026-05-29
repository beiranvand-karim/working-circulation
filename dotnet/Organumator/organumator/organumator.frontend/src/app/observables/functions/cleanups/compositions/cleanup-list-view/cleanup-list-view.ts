import { Component } from '@angular/core'
import { CleanupListAll } from '../../components/cleanup-list-all/cleanup-list-all'
import { CleanupCreateOne } from '../../components/cleanup-create-one/cleanup-create-one'

@Component({
  selector: 'cleanup-list-view',
  imports: [CleanupListAll, CleanupCreateOne],
  templateUrl: './cleanup-list-view.html',
  styleUrl: './cleanup-list-view.scss',
})
export class CleanupListView {}
