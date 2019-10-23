import { Component, OnInit } from '@angular/core';
import { CustomerDetailsService } from 'src/app/shared/customer-details.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styles: []
})
export class CustomerDetailsComponent implements OnInit {

  constructor(private custdetService:CustomerDetailsService,
    private toastr:ToastrService) { }

  ngOnInit() {
   // this.resetForm();
    
  }
  resetForm(form?:NgForm)
  {
    if(form!=null)
    form.resetForm();
    this.custdetService.formData={
      PatientId:0,
      FirstName:"",
      MidName:"",
      LastName:"",
      EmailId:"",
      Phone:""
    }
    this.custdetService.refreshList();
  }
  onSubmit(form:NgForm){
debugger
if (form.value.PatientId==0)
{
  this.insertRecord(form);
}
 else
 {
this.updateRecord(form);
 }
}
  insertRecord(form:NgForm)
  {
    debugger
    this.custdetService.postCustomerDetail(form.value).subscribe(
      res=>{
        this.resetForm(form);
        debugger;
        this.toastr.success('Submitted Successfully','Customer Information');
      },
      err=>{
        console.log(err);
      }
        
      )
  }
  updateRecord(form:NgForm)
  {
    debugger;
    this.custdetService.putCustomerDetail(form.value).subscribe(
      res=>{
        this.resetForm(form);
        debugger;
        this.toastr.success('Submitted Successfully','Customer Information');
      },
      err=>{
        console.log(err);
      }
        
      )
  }
}
