import { Component, OnInit } from '@angular/core';
import { ApplicationConfiguration } from "../../../shared/configuration/applicationConfiguration";
import { AddSubscriberRequest } from "../../../shared/dto/AddSubscriberRequest";
import { LocalApiClient } from "../../../core/api-client/localApiClient";
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
    var request = new AddSubscriberRequest();
    this.localApi.addSubscriber(request, () => {});
    this.swPush.requestSubscription({
        serverPublicKey: this.configuration.getString("Vapid.PublicKey")
      })
      .then((subscriber) => {
        this.logger.debug(subscriber);
        var request = new AddSubscriberRequest();
        request.endpoint = subscriber.endpoint;
        request.expirationTime = subscriber.expirationTime;
        request.auth = subscriber.getKey("auth")[0];
        request.p256dh = subscriber.getKey("p256dh")[0];
        this.localApi.addSubscriber(request, () => {});
      })
      .catch(err => this.logger.debug("Could not subscribe to notifications", err));
  }

  title = 'PoopBuddy';

  constructor(
    private swUpdate: SwUpdate,
    private swPush: SwPush,
    private configuration: ApplicationConfiguration,
    private logger: NGXLogger,
    private localApi: LocalApiClient) {  }
}
