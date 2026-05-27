import { Component } from '@angular/core'
import { CleanupListAll } from '../../components/cleanup-list-all/cleanup-list-all'
import { CleanupCreateOne } from '../../components/cleanup-create-one/cleanup-create-one'

@Component({
  selector: 'cleanups-view',
  imports: [CleanupListAll, CleanupCreateOne],
  templateUrl: './cleanups-view.html',
  styleUrl: './cleanups-view.scss',
})
export class CleanupsView {}
