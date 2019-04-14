import { Injectable } from '@angular/core';
import {HttpClientHelper} from "../../shared/http/httpClientHelper"
import {ApplicationConfiguration} from "../../shared/configuration/applicationConfiguration"
import { GetAllPoopingsResponse }  from "../../shared/dto/GetAllPoopingsResponse";
import { NGXLogger } from 'ngx-logger';

@Injectable({
  providedIn: 'root',
})
export class LocalApiClient {

  private localApiAddress: string;

  constructor(private httpClientHelper: HttpClientHelper, private configuration: ApplicationConfiguration, private logger: NGXLogger) {

    this.localApiAddress = configuration.getString("localApi.address");
  }

  public getAllPoopings(onResponse: (response: GetAllPoopingsResponse) => void): void {
    this.logger.debug("About to call getAllPoopings on " + this.localApiAddress);
    return this.httpClientHelper.get<GetAllPoopingsResponse>(this.localApiAddress,
      (response) => {
        onResponse(response);
      });
  }
}

