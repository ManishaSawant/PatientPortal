import { CustomerDetails} from './customer-details.model';
import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerDetailsService {
formData:CustomerDetails;
list:CustomerDetails[];
readonly rootURL="http://localhost:60562/api"
  constructor(private http:HttpClient) 
  { }
  postCustomerDetail(formData)
  {
    debugger
return this.http.post(this.rootURL + '/Patient/Insert',formData);
  }
  putCustomerDetail(formData)
  {
    debugger;
return this.http.put(this.rootURL + '/Patient/'+this.formData.PatientId ,formData);
  }
  deleteCustomerDetail(id)
  {
  return this.http.delete(this.rootURL + '/Patient/'+id );
  }
  refreshList()
  {
    debugger;
    this.http.get(this.rootURL + '/Patient')
    .toPromise()
    .then(res=>this.list=res as CustomerDetails[]);
  }
}
