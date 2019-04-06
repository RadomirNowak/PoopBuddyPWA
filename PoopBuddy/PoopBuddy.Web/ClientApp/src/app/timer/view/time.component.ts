import { Component, Input } from '@angular/core';
import { Time } from '../Time';

@Component({
  selector: 'app-time',
  templateUrl: './time.component.html',
  styleUrls: ['./time.component.scss']
})
export class TimeComponent {
  @Input() time: Time;

  get seconds(): string {
    return this.addLeadingZeroes(this.time.seconds);
  }

  get minutes(): string {
    return this.addLeadingZeroes(this.time.minutes);
  }

  get hours(): string {
    return this.addLeadingZeroes(this.time.hours);
  }

  get miliSeconds(): string {
    return this.addLeadingZeroes(this.time.miliSeconds);
  }

  private addLeadingZeroes(input:number): string {
    return input.toString().padStart(2, '0').substr(0, 2);
  }

  constructor() {
  }

}
