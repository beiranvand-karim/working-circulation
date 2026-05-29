import { Routes } from '@angular/router'
import { AroundBrushingView } from './observables/functions/around-brushing/compositions/around-brushing-view/around-brushing-view'
import { FaceHydrationView } from './observables/functions/face-hydration/compositions/face-hydration-view/face-hydration-view'
import { SilvermanPillTakingView } from './observables/functions/silverman-pill-taking/compositions/silverman-pill-taking-view/silverman-pill-taking-view'
import { LivergolPillTakingView } from './observables/functions/livergol-pill-taking/compositions/livergol-pill-taking-view/livergol-pill-taking-view'
import { BetweenTeethBrushingView } from './observables/functions/between-teeth-brushing/compositions/between-teeth-brushing-view/between-teeth-brushing-view'
import { CalciferolTakingsView } from './observables/functions/calciferol-takings/compositions/calciferol-takings-view/calciferol-takings-view'
import { VacuumCleaningsView } from './observables/functions/vacuum-cleanings/compositions/vacuum-cleanings-view/vacuum-cleanings-view'
import { CleanupsView } from './observables/functions/cleanups/compositions/cleanups-view/cleanups-view'
import { cleanupsRoutes } from './observables/functions/cleanups/cleanups.routes'
import { SimcardChargingsView } from './observables/functions/simcard-chargings/compositions/simcard-chargings-view/simcard-chargings-view'

export const routes: Routes = [
  { path: 'around-brushing', component: AroundBrushingView },
  { path: 'face-hydration', component: FaceHydrationView },
  { path: 'silverman-pill-taking', component: SilvermanPillTakingView },
  { path: 'livergol-pill-taking', component: LivergolPillTakingView },
  { path: 'between-teeth-brushing', component: BetweenTeethBrushingView },
  { path: 'calciferol-pill-takings', component: CalciferolTakingsView },
  { path: 'vacuum-cleanings', component: VacuumCleaningsView },
  { path: 'cleanups', component: CleanupsView, children: cleanupsRoutes },
  { path: 'simcard-chargings', component: SimcardChargingsView },
]
