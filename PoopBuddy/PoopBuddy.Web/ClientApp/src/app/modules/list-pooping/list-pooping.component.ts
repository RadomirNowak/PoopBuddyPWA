import { Component, OnInit } from '@angular/core';
import { IPooping } from '../../core/models/pooping';
import { LocalApiClient } from "../../core/api-client/localApiClient";
import { Time } from "../../shared/time/Time";
import { NGXLogger } from "ngx-logger";


@Component({
  selector: 'list-pooping',
  templateUrl: './list-pooping.component.html',
  styleUrls: ['./list-pooping.component.scss']
})
export class ListPoopingComponent implements OnInit {
  displayedColumns: string[] = ['authorName', 'poopingDuration', 'wagePerHour', 'totalEarnings'];
  poopingList: IPooping[];

  constructor(private apiClient: LocalApiClient, private logger: NGXLogger) {  }

  ngOnInit() {
    this.apiClient.getAllPoopings((response) => {
      this.poopingList = response.poopingList;
      this.poopingList.forEach((pooping) => {
        pooping.duration = new Time();
        pooping.duration.addMs(pooping.durationInMs);
      });
    });
  }

  calculateEarning(duration: Time, wagePerHour: number): number {
    var wagePerSecond = wagePerHour / 60 / 60;
    this.logger.debug(`Calulating earning for ${duration.totalSeconds} seconds and ${wagePerSecond} wage`);
    return duration.totalSeconds * wagePerSecond;
  }

}
