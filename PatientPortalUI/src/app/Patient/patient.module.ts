import { BrowserModule } from '@angular/platform-browser';
import { PatientComponent } from './patient.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { PatientdetailComponent } from './patientdetail.component';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule} from '@angular/forms';

@NgModule({
  declarations: [PatientComponent, PatientdetailComponent],
  imports: [
    CommonModule,BrowserModule,HttpClientModule,ToastrModule.forRoot(),
    FormsModule
  ],
  bootstrap:[PatientComponent]
})
export class PatientModule { }
