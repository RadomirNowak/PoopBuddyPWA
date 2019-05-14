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

      this.swPush.requestSubscription({
          serverPublicKey: this.configuration.getString("Vapid.PublicKey")
        })
        .then((subscriber) => {
          this.logger.debug(subscriber);
          var request = new AddSubscriberRequest();
          request.endpoint = subscriber.endpoint;
          request.expirationTime = subscriber.expirationTime;
          request.keys = {
            auth: this.getStringFromArrayBuffer(subscriber.getKey("auth")),
            p256dh: this.getStringFromArrayBuffer(subscriber.getKey("p256dh"))
          };
          this.localApi.addSubscriber(request, () => {});
        })
        .catch(err => this.logger.debug("Could not subscribe to notifications", err));
    }
  }

  private getStringFromArrayBuffer(buffer: ArrayBuffer): string {
    return btoa(String.fromCharCode.apply(null, new Uint8Array(buffer)));
  }

  title = 'PoopBuddy';

  constructor(
    private swUpdate: SwUpdate,
    private swPush: SwPush,
    private configuration: ApplicationConfiguration,
    private logger: NGXLogger,
    private localApi: LocalApiClient) {  }
}
