import {TimerHelper} from "./timerHelper";

export class PoopingViewModel {
  private _isPooping: boolean;

  private timerHelper: TimerHelper;

  constructor() { this.timerHelper = new TimerHelper(); }

  isPooping(): boolean {
    return this._isPooping;
  }

  togglePooping(newState?: boolean): void {
    if (newState != null) {
      this._isPooping = newState;
    } else {
      this._isPooping = !this._isPooping;
    }

    if (this._isPooping)
      this.startTimer();
    else
      this.stopTimer();
  }

  startTimer(): void {
    this.timerHelper.startTimer();
  }

  stopTimer(): void {
    this.timerHelper.stopTimer();
  }

  getElapsedMs(): number {
    return this.timerHelper.getElapsedMs();
  }
}
