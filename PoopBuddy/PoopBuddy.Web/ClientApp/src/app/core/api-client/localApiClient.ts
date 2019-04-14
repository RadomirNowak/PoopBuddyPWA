import { Injectable } from '@angular/core';
import {HttpClientHelper} from "../../shared/http/httpClientHelper"
import {ApplicationConfiguration} from "../../shared/configuration/applicationConfiguration"
import { GetAllPoopingsResponse }  from "../../shared/dto/GetAllPoopingsResponse";

@Injectable({
  providedIn: 'root',
})
export class LocalApiClient {

  private localApiAddress: string;

  constructor(private httpClientHelper: HttpClientHelper, private configuration: ApplicationConfiguration) {
    this.localApiAddress = configuration.getString("localApi.address");
  }

  public getAllPoopings(onResponse: (response: GetAllPoopingsResponse) => void): void {
    return this.httpClientHelper.get<GetAllPoopingsResponse>(this.localApiAddress,
      (response) => {
        console.log("response below from localApiClient");
        console.log(response);
        onResponse(response);
      });
  }
}

