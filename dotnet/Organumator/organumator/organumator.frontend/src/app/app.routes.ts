import { Routes } from '@angular/router'
import { AroundBrushingView } from './observables/functions/around-brushing/compositions/around-brushing-view/around-brushing-view'
import { FaceHydrationView } from './observables/functions/face-hydration/compositions/face-hydration-view/face-hydration-view'
import { SilvermanPillTakingView } from './observables/functions/silverman-pill-taking/compositions/silverman-pill-taking-view/silverman-pill-taking-view'

export const routes: Routes = [
    { path: 'around-brushing', component: AroundBrushingView },
    { path: 'face-hydration', component: FaceHydrationView },
    { path: 'silverman-pill-taking', component: SilvermanPillTakingView },
]
