import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SlideInOverLayComponent } from './slide-in-over-lay/slide-in-over-lay.component';

const routes: Routes = [
  {
    path: '',
    component: SlideInOverLayComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SlideInOverLayRoutingModule { }
