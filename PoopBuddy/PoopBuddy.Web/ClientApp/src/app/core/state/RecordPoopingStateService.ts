import { Time } from "../../shared/time/Time";
import { Injectable } from "@angular/core";
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RecordPoopingStateService {
  recordedPoopingItem = new RecordedPoopingItem();

  private authorNameChangedSource = new Subject<RecordedPoopingItem>();
  private durationChangedSource = new Subject<RecordedPoopingItem>();
  private wagePerHourChangedSource = new Subject<RecordedPoopingItem>();
  authorNameChanged$ = this.authorNameChangedSource.asObservable();
  durationChanged$ = this.durationChangedSource.asObservable();
  wagePerHourChanged$ = this.wagePerHourChangedSource.asObservable();
  
  setAuthorName(authorName: string): void {
    this.recordedPoopingItem.authorName = authorName;
    this.authorNameChangedSource.next(this.recordedPoopingItem);
  }

  setDuration(duration: Time) {
    this.recordedPoopingItem.duration = duration;
    this.durationChangedSource.next(this.recordedPoopingItem);
  }

  setWagePerHour(wagePerHour: number) {
    this.recordedPoopingItem.wagePerHour = wagePerHour;
    this.wagePerHourChangedSource.next(this.recordedPoopingItem);
  }
}

export class RecordedPoopingItem {
  authorName: string;
  duration: Time;
  wagePerHour: number;
}
