import { Component, OnInit, ViewChild } from '@angular/core';
import { NGXLogger } from "ngx-logger";
import { MatDialog } from "@angular/material";
import { EnterPooperDataComponent } from "../enter-pooper-data/enter-pooper-data.component";
import { TimerComponent } from "../../shared/timer/component/timer.component";

@Component({
  selector: 'start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent implements OnInit {

  processStarted: boolean = false;

  @ViewChild('timerComponent') timerComponent : TimerComponent;

  constructor(
    public dialog: MatDialog,
    private logger: NGXLogger,
    ) {

  }

  ngOnInit(): void {
  }

  startPooping(): void {
    this.processStarted = true; // because before the ngIf becomes true we can't access TimerComponent!
    this.dialog.open(EnterPooperDataComponent, { disableClose: true });
    setTimeout(() => { this.timerComponent.togglePooping(); }); // setTimeout cause ViewChild has to reload
  }


}
