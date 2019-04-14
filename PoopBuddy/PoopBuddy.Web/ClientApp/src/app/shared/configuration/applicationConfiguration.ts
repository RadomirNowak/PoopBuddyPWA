import { Injectable } from '@angular/core';
import * as configuration from "./configuration.json"


@Injectable({
  providedIn: 'root',
})
export class ApplicationConfiguration {
  public getString(key: string): string {
    return configuration.default[key];
  }
}
