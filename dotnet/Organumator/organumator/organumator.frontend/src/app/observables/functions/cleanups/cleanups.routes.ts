import { Routes } from '@angular/router'
import { CleanupListView } from './compositions/cleanup-list-view/cleanup-list-view'
import { CleanupDaysWithData } from './components/cleanup-days-with-data/cleanup-days-with-data'

export const cleanupsRoutes: Routes = [
  { path: '', redirectTo: 'days', pathMatch: 'full' },
  { path: 'list', component: CleanupListView },
  { path: 'days', component: CleanupDaysWithData },
]
