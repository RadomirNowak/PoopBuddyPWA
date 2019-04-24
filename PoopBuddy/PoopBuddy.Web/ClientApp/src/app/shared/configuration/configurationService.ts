import {Injectable, APP_INITIALIZER} from '@angular/core';
import { HttpClientHelper } from "../http/httpClientHelper";
import { Observable } from 'rxjs';

import { environment } from "../../../environments/environment";
import { Environment } from '../../../environments/environmentEnum';


@Injectable()
export class ConfigurationService {
  private _config: Object;
  private _env: string;

  constructor(private http: HttpClientHelper) {  }

  load() {
    return new Promise((resolve, reject) => {
      this._env = 'development';

      switch (environment.type) {
      case Environment.Development:
      {
        this._env = 'development';
        break;
      }
      case Environment.Staging:
      {
        this._env = 'staging';
        break;
      }
      case Environment.Production:
      {
        this._env = 'production';
        break;
      }
      default:
      {
        this._env = 'production';
        break;
      }
      }

      this.http.get('./assets/config/' + this._env + '.json', (response) => {
        this._config = response;
        resolve(true);
      });
    });
  }

  get(key: string) {
    return this._config[key];
  }

}

export function ConfigurationFactory(config: ConfigurationService) {
  return () => config.load();
}

export function init() {
  return {
    provide: APP_INITIALIZER,
    useFactory: ConfigurationFactory,
    deps: [ConfigurationService],
    multi: true
  }
}

const ConfigurationModule = {
  init: init
}

export { ConfigurationModule };
