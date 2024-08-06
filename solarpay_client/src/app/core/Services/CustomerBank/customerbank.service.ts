import { Injectable } from '@angular/core';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IResponse } from '../../Models/IUser';
import { IBank } from '../../Models/ICustomer';

@Injectable({
  providedIn: 'root'
})
export class CustomerbankService {

  constructor(private http: HttpClient) { }
  //Get All Customers
  GetBanks(): Observable<IResponse<IBank[]>> {
    return this.http.get<IResponse<IBank[]>>(
      `${apiEndpoint.BankEndpoint.getcustomerbanks}`
    );
  }
//Insert new Customer
  AddBank(data: IBank): Observable<IResponse<IBank>> {
    return this.http.post<IResponse<IBank>>(
      `${apiEndpoint.BankEndpoint.addcustomerbank}`,
      data
    );
  }
//Update existing Customer
  UpdateBank(data:IBank): Observable<IResponse<IBank>> {
    return this.http.put<IResponse<IBank>>(
      `${apiEndpoint.BankEndpoint.updatecustomerbank}`,
      data
    );
  }
//Delete existing Customer
  DeleteBank(id:string): Observable<IResponse<IBank>> {
    return this.http.delete<IResponse<IBank>>(
      `${apiEndpoint.BankEndpoint.deletecustomerbank}/${id}`
    );
  }
//Get a Customer by id
  GetCustomerBankById(id:string): Observable<IResponse<IBank>> {
    return this.http.get<IResponse<IBank>>(
      `${apiEndpoint.BankEndpoint.getcustomerbankbyid}/${id}`
    );
  }
}
