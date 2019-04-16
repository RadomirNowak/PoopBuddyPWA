import { Component } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { Timer } from "../Timer";
import { Time } from "../../time/Time";
import { RecordPoopingRequest } from "../../dto/RecordPoopingRequest";
import { LocalApiClient } from "../../../core/api-client/localApiClient";

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

  constructor(private logger: NGXLogger, private apiClient: LocalApiClient) {
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

  private pausePooping() {
    this.logger.debug("pause pooping");
    this.timerHelper.stop();
    this.buttonState = ButtonState.Paused;
  }
  private startPooping() {
    this.logger.debug("start pooping");
    this.timerHelper.start();
    this.buttonState = ButtonState.Started;
  }

  recordPooping() {
    var authorName = "Pooping user"; // todo get this from user input
    var wagePerHour = 10; // todo get this from user input
    var recordPoopingRequest = new RecordPoopingRequest();
    recordPoopingRequest.authorName = authorName;
    recordPoopingRequest.durationInMs = this.Time.totalMiliseconds;
    recordPoopingRequest.wagePerHour = wagePerHour;

    this.apiClient.recordPooping(recordPoopingRequest);
  }
}

enum ButtonState {
  Neutral = 0,
  Started = 1,
  Paused = 2,
  Stopped = 3
}
