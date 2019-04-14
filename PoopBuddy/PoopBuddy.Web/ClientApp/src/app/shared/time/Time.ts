export class Time {
  private _hours:number;
  get hours(): number {
    return this._hours;
  }

  private _minutes:number;
  get minutes(): number {
    return this._minutes;
  }

  private _seconds:number;
  get seconds(): number {
    return this._seconds;
  }

  private _miliSeconds:number;
  get miliSeconds(): number {
    return this._miliSeconds;
  }

  private _totalMiliseconds : number;
  get totalMiliseconds(): number {
    var hourMs = this.hours * 60 * 60 * this._miliSecondsInSecond;
    var minutesMs = this.minutes * 60 * this._miliSecondsInSecond;
    var secondsMs = this.seconds * this._miliSecondsInSecond;
    return hourMs + minutesMs + secondsMs + this.miliSeconds;
  }

  private _totalSeconds : number;
  get totalSeconds(): number {
    var hourMs = this.hours * 60 * 60;
    var minutesMs = this.minutes * 60;
    return hourMs + minutesMs + this.seconds;
  }

  private _miliSecondsInSecond = 1000;

  constructor() {
    //console.log("Time constructor");
    this.reset();
  }

  reset() {
    //console.log("Time reset");
    this._hours = this._minutes = this._seconds = this._miliSeconds = 0;
  }

  toString(): string {
    let hours = this._hours.toString().padStart(2, '0');
    let minutes = this._minutes.toString().padStart(2, '0');
    let seconds = this._seconds.toString().padStart(2, '0');
    let miliSeconds = this._miliSeconds.toString().padStart(2, '0');
    let separator = ":";

    let fullText = `${hours}${separator}${minutes}${separator}${seconds}`;

    return fullText;
  }

  addMs(miliSeconds: number) {
    this._miliSeconds += miliSeconds;
    while (this._miliSeconds >= this._miliSecondsInSecond) {
      this.addSeconds(1);
      this._miliSeconds -= this._miliSecondsInSecond;
    }
  }

  private addSeconds(seconds: number) {
    this._seconds += seconds;
    if (this._seconds > 59) {
      this.addMinutes(1);
      this._seconds = 0;
    }
  }

  private addMinutes(minutes: number) {
    this._minutes += minutes;
    if (this._minutes > 59) {
      this.addHours(1);
      this._minutes = 0;
    }
  }

  private addHours(hours: number) {
    this._hours += hours;
  }
}
