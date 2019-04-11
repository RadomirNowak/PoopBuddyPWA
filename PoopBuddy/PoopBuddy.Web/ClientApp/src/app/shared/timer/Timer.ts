import {Time} from "../time/Time"

export class Timer {


  private _time: Time;
  get time(): Time {
    return this._time;
  }



  private timerInterval = 50;
  private interval;

  constructor() {
    //console.log("Timer constructor");
    this.reset();
  }

  reset() {
    //console.log("Timer reset");
    this._time = new Time();

    if (this.interval) {
      //console.log("Timer reset - this.interval !== null");
      this.clearAllIntervalAndTimeout();
      if (this.interval != undefined) {
        throw "Timer interval not properly cleared! Interval: " + this.interval;
      }
        
    }
      
  }

  private clearAllIntervalAndTimeout() {
    clearTimeout(this.interval);
    this.interval = null;
  }

  start() {
    //console.log("Timer start");
    if (this.time === null) {
      //console.log("Timer start - this.time === null");
      this.reset();
    }

    if (this.interval) {
      //console.log("Timer start - this.interval");
      this.clearAllIntervalAndTimeout();
    }

    this.setTimeout();
  }

  stop() {
    //console.log("Timer stop");
    this.clearAllIntervalAndTimeout();
  }

  private updateTime(self) {
    //console.log("Timer updateTime: " + self.time.miliSeconds + " ms " + self.time.seconds + " s");
    self.time.addMs(this.timerInterval);
  }

  private setTimeout() {
    var that = this;
    this.interval = setTimeout(() => {
      this.updateTime(that);
      this.setTimeout();
    }, this.timerInterval);
  }
}
