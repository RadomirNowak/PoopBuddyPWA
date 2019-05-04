import { Component, OnInit } from '@angular/core';
import {SwUpdate} from "@angular/service-worker"


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
    }
  }

  title = 'PoopBuddy';

  constructor(private swUpdate: SwUpdate) {  }
}
