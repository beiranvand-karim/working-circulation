import { Component } from '@angular/core';
import { SilvermanPillTakingCreateOne } from "../../components/silverman-pill-taking-create-one/silverman-pill-taking-create-one";
import { SilvermanPillTakingListAll } from "../../components/silverman-pill-taking-list-all/silverman-pill-taking-list-all";

@Component({
  selector: 'silverman-pill-taking-view',
  imports: [SilvermanPillTakingCreateOne, SilvermanPillTakingListAll],
  templateUrl: './silverman-pill-taking-view.html',
  styleUrl: './silverman-pill-taking-view.scss',
})
export class SilvermanPillTakingView {}
