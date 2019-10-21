import { Global } from './../shared/global';
import { Injectable } from '@angular/core';
import { HttpMethod } from 'blocking-proxy/built/lib/webdriver_commands';
import { HttpClient, HttpHeaders,HttpResponse,HttpRequest  } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Patient } from '../Models/Patient';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private headers=new HttpHeaders({'Content-Type':'application/json' });
  private apiUrl=Global.WEB_API_URL;
  formData:Patient;
  constructor(private http: HttpClient) { }
 
  getPatient(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl+ 'Patient')
      .pipe(
        tap(product => console.log('fetched patient')),
        catchError(this.handleError('getPatient', []))
      );
  }
 /*  getPatient(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this._HttpClient.get<any>(url).pipe(
      tap(_ => console.log(`fetched product id=${id}`)),
      catchError(this.handleError<any>(`getProduct id=${id}`))
    );
  } */
  exactData(){

  }
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  Create(formData){
    return this.http.post(this.apiUrl + 'Patient/Insert',formData);
  }
  edit(formData){
    return this.http.put(this.apiUrl + 'Patient/Update'+ this.formData.PatientId ,formData);
  }
  remove(id){
    return this.http.delete(this.apiUrl + 'Patient/Delete'+ id );
  }
}
