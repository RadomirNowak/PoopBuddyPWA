import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-poopings',
  templateUrl: './poopings.component.html'
})
export class PoopingsComponent {
  public poopings: Poopings[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Poopings[]>(baseUrl + 'api/SampleData/Poopings').subscribe(result => {
      this.poopings = result;
    }, error => console.error(error));
  }
}

interface Poopings {
  title: string;
  duration: number;
  earning: number;
}

