import {Injectable} from "@angular/core";
import { Time } from "../time/Time";

@Injectable({
  providedIn: 'root'
})
export class EarningHelper {

  public calculateEarning(duration: Time, wagePerHour: number): number {
    var wagePerSecond = wagePerHour / 60 / 60;
    return duration.totalSeconds * wagePerSecond;
  }

}
