import { Component, OnInit } from '@angular/core';
import { PoopingViewModel } from "./poopingViewModel";

@Component({
  selector: 'app-pooping',
  templateUrl: './pooping.component.html',
  styleUrls: ['./pooping.component.scss']
})
export class PoopingComponent implements OnInit {
  poopingViewModel: PoopingViewModel;
  elapsedMs: number;

  checkForElapsed: boolean;


  constructor() {
    this.poopingViewModel = new PoopingViewModel();
    console.log("pooping component ctor");
  }

  ngOnInit() {
  }

  togglePooping(newState ?: boolean) {
    this.poopingViewModel.togglePooping();
    if (this.checkForElapsed != true) {
      this.initCheckForElapsed();
      this.elapsedMs = this.poopingViewModel.getElapsedMs();
    }
  }

  initCheckForElapsed(): void {
    this.checkForElapsed = true;
    setInterval(
      () => {
        this.elapsedMs = this.poopingViewModel.getElapsedMs();
        console.log("inside setInterval");
      },
      100
    );
    console.log("initCFE");
  }

}
