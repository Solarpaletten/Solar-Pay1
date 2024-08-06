import { Injectable } from '@angular/core';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICustomer } from '../../Models/ICustomer';
import { IResponse } from '../../Models/IUser';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }
  //Get All Customers
  GetCustomers(): Observable<IResponse<ICustomer[]>> {
    return this.http.get<IResponse<ICustomer[]>>(
      `${apiEndpoint.CustomerEndpoint.getcustomers}`
    );
  }
//Insert new Customer
  AddCustomer(data: ICustomer): Observable<IResponse<ICustomer>> {
    return this.http.post<IResponse<ICustomer>>(
      `${apiEndpoint.CustomerEndpoint.addcustomer}`,
      data
    );
  }
//Update existing Customer
  UpdateCustomer(data:ICustomer): Observable<IResponse<ICustomer>> {
    return this.http.put<IResponse<ICustomer>>(
      `${apiEndpoint.CustomerEndpoint.updatecustomer}`,
      data
    );
  }
//Delete existing Customer
  DeleteCustomer(id:string): Observable<IResponse<ICustomer>> {
    return this.http.delete<IResponse<ICustomer>>(
      `${apiEndpoint.CustomerEndpoint.deletecustomer}/${id}`
    );
  }
//Get a Customer by id
  GetCustomerById(id:string): Observable<IResponse<ICustomer>> {
    return this.http.get<IResponse<ICustomer>>(
      `${apiEndpoint.CustomerEndpoint.getcustomerbyid}/${id}`
    );
  }
}
