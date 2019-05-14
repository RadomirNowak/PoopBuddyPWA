import { Component, OnInit } from '@angular/core';
import { ApplicationConfiguration } from "../../../shared/configuration/applicationConfiguration";
import {SwUpdate, SwPush} from "@angular/service-worker"
import { NGXLogger } from 'ngx-logger';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    if (this.swUpdate.isEnabled) {
      this.swUpdate.available.subscribe(() => {
        window.location.reload();
      });
    }

    this.swPush.requestSubscription({
        serverPublicKey: this.configuration.getString("Vapid.PublicKey")
      })
      .then(() => { /*todo*/})
      .catch(err => this.logger.debug("Could not subscribe to notifications", err));
  }

  title = 'PoopBuddy';

  constructor(private swUpdate: SwUpdate, private swPush: SwPush, private configuration: ApplicationConfiguration, private logger: NGXLogger) {  }
}
