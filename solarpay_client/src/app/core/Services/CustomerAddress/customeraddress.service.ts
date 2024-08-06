import { Injectable } from '@angular/core';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAddress, ICustomer } from '../../Models/ICustomer';
import { IResponse } from '../../Models/IUser';

@Injectable({
  providedIn: 'root'
})
export class CustomerAddressService {

  constructor(private http: HttpClient) { }
  //Get All Customers
  GetCustomerAddresses(): Observable<IResponse<IAddress[]>> {
    return this.http.get<IResponse<IAddress[]>>(
      `${apiEndpoint.AddressEndpoint.getcustomeraddresses}`
    );
  }
//Insert new Customer
  AddCustomerAddress(data: IAddress): Observable<IResponse<IAddress>> {
    return this.http.post<IResponse<IAddress>>(
      `${apiEndpoint.AddressEndpoint.addcustomeraddress}`,
      data
    );
  }
//Update existing Customer
  UpdateCustomerAddress(data:IAddress): Observable<IResponse<IAddress>> {
    return this.http.put<IResponse<IAddress>>(
      `${apiEndpoint.AddressEndpoint.updatecustomeraddress}`,
      data
    );
  }
//Delete existing Customer
  DeleteCustomerAddress(id:string): Observable<IResponse<IAddress>> {
    return this.http.delete<IResponse<IAddress>>(
      `${apiEndpoint.AddressEndpoint.deletecustomeraddress}/${id}`
    );
  }
//Get a Customer by id
  GetCustomerAddressById(id:string): Observable<IResponse<IAddress>> {
    return this.http.get<IResponse<IAddress>>(
      `${apiEndpoint.AddressEndpoint.getcustomeraddressbyid}/${id}`
    );
  }
}
