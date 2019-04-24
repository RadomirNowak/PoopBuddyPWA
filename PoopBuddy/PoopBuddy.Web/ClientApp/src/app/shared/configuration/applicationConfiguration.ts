import { Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { ConfigurationService } from "./configurationService";


@Injectable({
  providedIn: 'root',
})
export class ApplicationConfiguration {
  constructor(private logger: NGXLogger, private configuration: ConfigurationService) {  }

  public getString(key: string): string {
    var value = this.configuration.get(key);
    if (value === undefined) {
      this.logger.error(`No value found in configuration for key [${key}]`);
      throw new Error(`No value found in configuration for key [${key}]`);
    }
      
    return value;
  }
}
