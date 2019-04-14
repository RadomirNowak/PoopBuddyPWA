import { Component, OnInit } from '@angular/core';
import { IPooping } from '../../core/models/pooping';
import { LocalApiClient } from "../../core/api-client/localApiClient";


@Component({
  selector: 'list-pooping',
  templateUrl: './list-pooping.component.html',
  styleUrls: ['./list-pooping.component.scss']
})
export class ListPoopingComponent implements OnInit {
  displayedColumns: string[] = ['authorName'];
  poopingList: IPooping[];

  constructor(private apiClient: LocalApiClient) {  }

  ngOnInit() {
    this.apiClient.getAllPoopings((response) => {
      this.poopingList = response.poopingList;
    });
  }

}
