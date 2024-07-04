import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SlideInOverLayRoutingModule } from './slide-in-over-lay-routing.module';
import { SlideInOverLayComponent } from './slide-in-over-lay/slide-in-over-lay.component';


@NgModule({
  declarations: [
    SlideInOverLayComponent
  ],
  imports: [
    CommonModule,
    SlideInOverLayRoutingModule
  ]
})
export class SlideInOverLayModule { }
