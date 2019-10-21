import { Patient } from './../Models/Patient';

import { Component, OnInit, OnDestroy, Input, DoBootstrap } from '@angular/core';
import { PatientService } from './patient.service';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  

  selector: 'patients',
  templateUrl: './patient.component.html',
  providers: [PatientService]
})
export class PatientComponent implements OnInit {
  @Input() patienttoeditoradd:Patient;
  constructor(private patientService:PatientService,  private toastr:ToastrService) { }
  

  ngOnInit() {
   // this.retrievePatients();
  }

  onSubmit(form:NgForm){
    debugger
    if (form.value.CUST_ID==0)
    {
      this.addnew(form);
    }
     else
     {
    this.edit(form);
     }
    }

  addnew(form:NgForm)
  {
    this.save(form);
/* his.patienttoeditoradd=new Patient();
this.patientModelTitle="Add new Patients";  */

  }
  edit(form:NgForm)
  {
    
    this.save(form);
  }

  delete(form:NgForm)
  {
this.patientService.remove(form.value.PatientId).subscribe(responseData=>
  {
   if (responseData)
   {
    
   }
  }
  );
  }
  save(form)
  {
    this.patientService.Create(form)
{
  if (form.value.PatientId==0)
{
  this.patientService.Create(form.value).subscribe(
    res=>{
      //this.resetForm(form);
      debugger;
      this.toastr.success('Submitted Successfully','Customer Information');
    },
    err=>{
      console.log(err);
    }
      
    )
    }
    else{
      this.patientService.edit(form.value).subscribe(
        res=>{
          //this.resetForm(form);
          debugger;
          this.toastr.success('Submitted Successfully','Customer Information');
        },
        err=>{
          console.log(err);
        }
          
        )
    }
}
  }

}
