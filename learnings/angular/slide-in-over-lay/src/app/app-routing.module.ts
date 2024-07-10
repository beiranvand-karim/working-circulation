import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "slide-in-over-lay",
    loadChildren: () => import('./slide-in-over-lay/slide-in-over-lay.module').then(m=> m.SlideInOverLayModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
