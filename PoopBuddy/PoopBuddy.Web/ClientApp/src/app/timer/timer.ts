import {Time} from './Time'

export class Timer {
  time: Time;
  timerInterval = 1;
  count = 0;
  interval;

  constructor() {
    console.log("Timer constructor");
    this.reset();
  }

  reset() {
    console.log("Timer reset");
    this.time = new Time();

    if (this.interval) {
      console.log("Timer reset - this.interval !== null");
      clearInterval(this.interval);
    }
      
  }

  start() {
    console.log("Timer start");
    if (this.time === null) {
      console.log("Timer start - this.time === null");
      this.reset();
    }

    if (this.interval) {
      console.log("Timer start - this.interval");
      clearInterval(this.interval);
    }

    var that = this;
    this.interval = setInterval(() => {
      this.updateTime(that);
    }, this.timerInterval);
  }

  stop() {
    console.log("Timer stop");
    clearInterval(this.interval);
  }

  updateTime(self) {
    console.log("Timer updateTime: " + this.count);
    self.time.addMs(this.timerInterval);
  }
}
