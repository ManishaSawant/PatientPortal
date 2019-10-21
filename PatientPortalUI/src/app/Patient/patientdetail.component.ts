import { Patient } from './../Models/Patient';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'patient-detail',
  templateUrl: './patientdetail.component.html',
  providers:[]
})
export class PatientdetailComponent implements OnInit {
@Input() patienttoeditoradd:Patient;
  constructor() { }

  ngOnInit() {
    this.patienttoeditoradd=new Patient();
  }

}
