import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from '../../Models/IUser';
import { IContractQuoteRate } from '../../Models/IRFQ';
import { apiEndpoint } from '../../constrants/constants';

@Injectable({
  providedIn: 'root'
})
export class ContractquoterateService {

  constructor(private http:HttpClient) { }
  //Get All Contracts
  GetContractQuoteRates(): Observable<IResponse<IContractQuoteRate[]>> {
    return this.http.get<IResponse<IContractQuoteRate[]>>(
      `${apiEndpoint.ContractQuoteRateEndpoint.getcontractquoterates}`
    );
  }
//Insert new contract
  AddContractQuoteRate(data: IContractQuoteRate): Observable<IResponse<IContractQuoteRate>> {
    return this.http.post<IResponse<IContractQuoteRate>>(
      `${apiEndpoint.ContractQuoteRateEndpoint.addcontractquoterate}`,
      data
    );
  }
//Update existing contract
  UpdateContractQuoteRate(data:IContractQuoteRate): Observable<IResponse<IContractQuoteRate>> {
    return this.http.put<IResponse<IContractQuoteRate>>(
      `${apiEndpoint.ContractQuoteRateEndpoint.updatecontractquoterate}`,
      data
    );
  }
//Delete existing contract
  DeleteContractQuoteRate(id:string): Observable<IResponse<IContractQuoteRate>> {
    return this.http.delete<IResponse<IContractQuoteRate>>(
      `${apiEndpoint.ContractQuoteRateEndpoint.deletecontractquoterate}/${id}`
    );
  }
//Get a contract by id
  GetContractQuoteRateById(id:string): Observable<IResponse<IContractQuoteRate>> {
    return this.http.get<IResponse<IContractQuoteRate>>(
      `${apiEndpoint.ContractQuoteRateEndpoint.getcontractquoteratebyid}/${id}`
    );
  }
}
