import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from "@angular/forms";
import { ErrorStateMatcher } from '@angular/material/core';
import { RecordPoopingStateService } from "../../core/state/RecordPoopingStateService";
import { NGXLogger } from "ngx-logger";

@Component({
  selector: 'start-pooping',
  templateUrl: './start-pooping.component.html',
  styleUrls: ['./start-pooping.component.scss']
})
export class StartPoopingComponent implements OnInit {
  constructor(private logger: NGXLogger, private recordPoopingStateService: RecordPoopingStateService) {
    
  }

  ngOnInit(): void {
    this.nameFormControl.valueChanges.subscribe(() => {
      this.logger.debug(this.nameFormControl.value);
    this.recordPoopingStateService.setAuthorName(this.nameFormControl.value);
    });
  }

  nameFormControl = new FormControl('', [
    Validators.required
    ]);

  wagePerHourFormControl = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl, form: FormGroupDirective | NgForm): boolean {
    const isSubmitted = form && form.submitted;
    return (control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
