import { Stopwatch } from "ts-stopwatch"

export class TimerHelper {
  isStarted : boolean;

  stopwatch : Stopwatch;

  startTimer():void {
    this.isStarted = true;
    this.stopwatch = new Stopwatch();
    this.stopwatch.start();
  }

  stopTimer(): void {
    this.isStarted = false;
    this.stopwatch.stop();
  }

  toggleTimer(): void {
    if (this.isStarted)
      this.stopTimer();
    else
      this.startTimer();
  }

  getElapsedMs(): number {
    return this.stopwatch.getTime();
  }
}
