import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from "@angular/forms";
import { ErrorStateMatcher } from '@angular/material/core';
import { RecordPoopingStateService } from "../../core/state/RecordPoopingStateService";
import { SendNotificationRequest } from "../../shared/dto/SendNotificationRequest";
import { LocalApiClient } from "../../core/api-client/localApiClient";
import { NGXLogger } from "ngx-logger";
import { MatDialogRef } from "@angular/material";

@Component({
  selector: 'enter-pooper-data',
  templateUrl: './enter-pooper-data.component.html',
  styleUrls: ['./enter-pooper-data.component.scss']
})
export class EnterPooperDataComponent implements OnInit {
  constructor(private logger: NGXLogger,
    private recordPoopingStateService: RecordPoopingStateService,
    public dialogRef: MatDialogRef<EnterPooperDataComponent>,
    private localApi: LocalApiClient
  ) {
    
  }

  ngOnInit(): void {
  }

  nameFormControl = new FormControl('', [
    Validators.required
    ]);

  wagePerHourFormControl = new FormControl('', [
    Validators.required
  ]);

  savePooperData(): void {
    this.recordPoopingStateService.setAuthorName(this.nameFormControl.value);
    this.recordPoopingStateService.setWagePerHour(this.wagePerHourFormControl.value);
    var sendNotificationRequest = new SendNotificationRequest();
    sendNotificationRequest.message = this.nameFormControl.value + " has started pooping!";
    this.localApi.sendNotification(sendNotificationRequest, () => {});
    this.dialogRef.close();
  }

  matcher = new MyErrorStateMatcher();
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl, form: FormGroupDirective | NgForm): boolean {
    const isSubmitted = form && form.submitted;
    return (control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
