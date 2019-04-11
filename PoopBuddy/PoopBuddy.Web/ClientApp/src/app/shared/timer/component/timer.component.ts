import { Component } from '@angular/core';
import { Timer } from "../Timer";
import { Time } from "../../time/Time";

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent {
  private timerHelper : Timer;

  public buttonStateEnum = ButtonState;

  public buttonState: ButtonState = ButtonState.Neutral;

  public Time: Time;

  constructor() {
    this.timerHelper = new Timer();
    this.Time = this.timerHelper.time;
  }


  togglePooping() {
    switch (this.buttonState) {
      case ButtonState.Started:
        this.pausePooping();
        return;
      case ButtonState.Neutral:
      case ButtonState.Stopped:
      case ButtonState.Paused:
        this.startPooping();
        return;
      default:
        throw "Button state not supported!";
    }
  }

  pausePooping() {
    console.log("pause pooping");
    this.timerHelper.stop();
    this.buttonState = ButtonState.Paused;
  }
  startPooping() {
    console.log("start pooping");
    this.timerHelper.start();
    this.buttonState = ButtonState.Started;
  }
}

enum ButtonState {
  Neutral = 0,
  Started = 1,
  Paused = 2,
  Stopped = 3
}
