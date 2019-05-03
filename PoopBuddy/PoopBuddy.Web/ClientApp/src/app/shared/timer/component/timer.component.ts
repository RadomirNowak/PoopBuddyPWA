import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
import { Timer } from "../Timer";
import { Time } from "../../time/Time";
import { RecordPoopingRequest } from "../../dto/RecordPoopingRequest";
import { RecordPoopingStateService } from "../../../core/state/RecordPoopingStateService";
import { LocalApiClient } from "../../../core/api-client/localApiClient";


@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent {

  public buttonStateEnum = ButtonState;

  public buttonState: ButtonState = ButtonState.Neutral;

  public Time: Time;

  constructor(private logger: NGXLogger,
    private apiClient: LocalApiClient,
    private timerHelper: Timer,
    private recordPoopingStateService: RecordPoopingStateService,
    private router: Router
    ) {
    this.Time = this.timerHelper.time;
    if (this.timerHelper.isRunning)
      this.buttonState = ButtonState.Started;
    else {
      this.buttonState = ButtonState.Neutral;
    }
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
  private stopPooping() {
    this.logger.debug("stop pooping");
    this.timerHelper.reset();
    this.Time = this.timerHelper.time;
    this.buttonState = ButtonState.Stopped;
  }

  recordPooping() {
    var authorName = this.recordPoopingStateService.recordedPoopingItem.authorName; // todo get this from user input
    var wagePerHour = this.recordPoopingStateService.recordedPoopingItem.wagePerHour; // todo get this from user input
    var recordPoopingRequest = new RecordPoopingRequest();
    recordPoopingRequest.authorName = authorName;
    recordPoopingRequest.durationInMs = this.Time.totalMiliseconds;
    recordPoopingRequest.wagePerHour = wagePerHour;

    this.apiClient.recordPooping(recordPoopingRequest, () => {
      this.router.navigate(['/list']);
    });
    this.stopPooping();
  }
}

enum ButtonState {
  Neutral = 0,
  Started = 1,
  Paused = 2,
  Stopped = 3
}
