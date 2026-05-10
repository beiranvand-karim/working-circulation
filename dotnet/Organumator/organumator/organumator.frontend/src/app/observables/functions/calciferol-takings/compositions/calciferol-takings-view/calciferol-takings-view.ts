import { Component } from '@angular/core';
import { CalciferolTakingListAll } from "../../components/calciferol-taking-list-all/calciferol-taking-list-all";
import { CalciferolTakingCreateOne } from "../../components/calciferol-taking-create-one/calciferol-taking-create-one";

@Component({
  selector: 'calciferol-takings-view',
  imports: [CalciferolTakingListAll, CalciferolTakingCreateOne],
  templateUrl: './calciferol-takings-view.html',
  styleUrl: './calciferol-takings-view.scss',
})
export class CalciferolTakingsView {}
