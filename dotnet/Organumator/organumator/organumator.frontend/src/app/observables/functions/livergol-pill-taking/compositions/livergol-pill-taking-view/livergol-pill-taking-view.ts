import { Component } from '@angular/core';
import { LivergolPillTakingCreateOne } from "../../components/livergol-pill-taking-create-one/livergol-pill-taking-create-one";
import { LivergolPillTakingListAll } from "../../components/livergol-pill-taking-list-all/livergol-pill-taking-list-all";

@Component({
  selector: 'livergol-pill-taking-view',
  imports: [LivergolPillTakingCreateOne, LivergolPillTakingListAll],
  templateUrl: './livergol-pill-taking-view.html',
  styleUrl: './livergol-pill-taking-view.scss',
})
export class LivergolPillTakingView {}
