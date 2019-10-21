import { PatientService } from './Patient/patient.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { PatientComponent } from './Patient/patient.component';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    PatientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    
  ],
  providers: [PatientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
