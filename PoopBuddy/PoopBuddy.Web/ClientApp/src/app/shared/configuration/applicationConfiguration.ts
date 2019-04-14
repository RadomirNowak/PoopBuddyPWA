import { Injectable } from '@angular/core';
import * as configuration from "./configuration.json"
import { NGXLogger } from 'ngx-logger';


@Injectable({
  providedIn: 'root',
})
export class ApplicationConfiguration {
  constructor(private logger: NGXLogger) {  }

  public getString(key: string): string {
    var value = configuration.default[key];
    if (value === undefined) {
      this.logger.error(`No value found in configuration for key [${key}]`);
      throw new Error(`No value found in configuration for key [${key}]`);
    }
      
    return value;
  }
}
