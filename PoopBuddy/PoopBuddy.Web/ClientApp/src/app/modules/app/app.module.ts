import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';



// Modules
import { AppRoutingModule } from './app-routing.module';
import { AppMaterialModule } from './app-material.module';

import { HttpClientHelper } from "../../shared/http/httpClientHelper";

// Components
import { AppComponent } from "./components/app.component";
import { ListPoopingComponent } from "../list-pooping/list-pooping.component";
import { TimerComponent } from "../../shared/timer/component/timer.component";
import { TimeComponent } from "../../shared/time/component/time.component";

@NgModule({
  declarations: [
    AppComponent,
    ListPoopingComponent,
    TimerComponent,
    TimeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AppMaterialModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent, TimerComponent ]
})
export class AppModule { }
