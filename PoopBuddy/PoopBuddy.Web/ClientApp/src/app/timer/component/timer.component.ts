import { Component } from '@angular/core';
import { Timer } from '../Timer';
import { Time } from '../Time';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent {
  private timerHelper : Timer;
  private isPooping : boolean;

  public Time: Time;

  constructor() {
    this.timerHelper = new Timer();
    this.Time = this.timerHelper.time;
  }


  togglePooping() {
    if (this.isPooping)
      this.pausePooping();
    else
      this.startPooping();
  }

  pausePooping() {
    console.log("pause pooping");
    this.timerHelper.stop();
    this.isPooping = false;
  }
  startPooping() {
    console.log("start pooping");
    this.timerHelper.start();
    this.isPooping = true;
  }
}
