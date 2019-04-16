import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';



// Modules
import { AppRoutingModule } from './app-routing.module';
import { AppMaterialModule } from './app-material.module';

import { HttpClientHelper } from "../../shared/http/httpClientHelper";

// Components
import { AppComponent } from "./components/app.component";
import { ListPoopingComponent } from "../list-pooping/list-pooping.component";
import { StartPoopingComponent } from "../start-pooping/start-pooping.component";
import { TimerComponent } from "../../shared/timer/component/timer.component";
import { TimeComponent } from "../../shared/time/component/time.component";

@NgModule({
  declarations: [
    AppComponent,
    ListPoopingComponent,
    StartPoopingComponent,
    TimerComponent,
    TimeComponent
  ],
  imports: [
    LoggerModule.forRoot({
      level: NgxLoggerLevel.DEBUG
    }),
    BrowserModule,
    
    AppRoutingModule,
    BrowserAnimationsModule,
    AppMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent, TimerComponent ]
})
export class AppModule { }
