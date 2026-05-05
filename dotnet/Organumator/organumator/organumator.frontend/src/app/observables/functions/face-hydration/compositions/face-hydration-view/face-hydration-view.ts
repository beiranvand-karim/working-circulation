import { Component } from '@angular/core';
import { FaceHydrationListAll } from "../../components/face-hydration-list-all/face-hydration-list-all";
import { FaceHydrationCreateOne } from "../../components/face-hydration-create-one/face-hydration-create-one";

@Component({
  selector: 'face-hydration-view',
  imports: [FaceHydrationListAll, FaceHydrationCreateOne],
  templateUrl: './face-hydration-view.html',
  styleUrl: './face-hydration-view.scss',
})
export class FaceHydrationView {

}
