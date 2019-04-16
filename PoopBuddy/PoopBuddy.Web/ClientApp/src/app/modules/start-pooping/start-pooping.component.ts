import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from "@angular/forms";
import { ErrorStateMatcher } from '@angular/material/core';

@Component({
  selector: 'start-pooping',
  templateUrl: './start-pooping.component.html',
  styleUrls: ['./start-pooping.component.scss']
})
export class StartPoopingComponent implements OnInit {
  ngOnInit(): void {  }

  nameFormControl = new FormControl('', [
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
