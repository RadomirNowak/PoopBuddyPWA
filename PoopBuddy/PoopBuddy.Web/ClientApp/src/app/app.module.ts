import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TimerComponent } from './timer/component/timer.component';
import { TimeComponent } from './timer/view/time.component';

import { AppMaterialModule } from './app-material.module';


@NgModule({
  declarations: [
    AppComponent,
    TimerComponent,
    TimeComponent 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AppMaterialModule,
  ],
  providers: [],
  bootstrap: [AppComponent, TimerComponent ]
})
export class AppModule { }
