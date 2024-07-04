import { Component } from '@angular/core';
import {
  trigger, state, style, animate, transition, query, group
 } from '@angular/animations';


export enum OverLayVisiblilityPossibleStates {
  hidden = 'hidden',
  shown = 'shown'
}

@Component({
  selector: 'app-slide-in-over-lay',
  templateUrl: './slide-in-over-lay.component.html',
  styleUrl: './slide-in-over-lay.component.scss',
  animations:[
    trigger('overLayTrigger',
      [
        transition
        (':enter',
          [
            style
            ({
              transform: 'translateX(-100%)'
            }),
            animate(300)
          ]
        ),
        transition
        (':leave',
          [
            style
            ({
              transform: 'translateX(100%)'
            }),
            animate(300)
          ]
        )
      ]
    )
  ]
})
export class SlideInOverLayComponent {
  overLayVisiblilityStatus = OverLayVisiblilityPossibleStates.hidden

  makeOverLayVisible(){
    this.overLayVisiblilityStatus = OverLayVisiblilityPossibleStates.shown
  }

  flipOverLayVisiblilityStatus() {
   (this.overLayVisiblilityStatus === OverLayVisiblilityPossibleStates.hidden ? this.makeOverLayVisible() : this.makeOverLayHidden())
  }
  
  makeOverLayHidden(){
    this.overLayVisiblilityStatus = OverLayVisiblilityPossibleStates.hidden
  }

  isOverLayVisible(){
    return this.overLayVisiblilityStatus === OverLayVisiblilityPossibleStates.shown
  }

  isOverLayHidden(){
    return this.overLayVisiblilityStatus === OverLayVisiblilityPossibleStates.hidden
  }
}
