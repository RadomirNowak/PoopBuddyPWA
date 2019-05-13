import {Component, Input} from '@angular/core'
import {Time} from "../../time/Time";
import { EarningHelper } from "../earningHelper";
import { RecordPoopingStateService } from "../../../core/state/RecordPoopingStateService";



@Component({
  selector: 'app-earning',
  templateUrl: './earnings.component.html',
  styleUrls: ['./earnings.component.scss']
})
export class EarningsComponent {
  @Input() time: Time = new Time();
  earned: number = 0;
  show: boolean = false;
  wagePerHour: number;
  currencySign = '$';

  constructor(private earningHelper: EarningHelper, private recordPoopingStateService: RecordPoopingStateService) {
    recordPoopingStateService.wagePerHourChanged$.subscribe((item) => {
      this.wagePerHour = item.wagePerHour;
      this.earned = earningHelper.calculateEarning(this.time, this.wagePerHour);
      this.show = true;
    });
  }

  
}
