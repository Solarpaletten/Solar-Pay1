import { Injectable } from '@angular/core';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { IContract } from '../../Models/IRFQ';
import { IResponse } from '../../Models/IUser';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContractService {

  constructor(private http:HttpClient) { }
//Get All Contracts
  GetContracts(): Observable<IResponse<IContract[]>> {
    return this.http.get<IResponse<IContract[]>>(
      `${apiEndpoint.ContractEndpoint.getcontracts}`
    );
  }
//Insert new contract
  AddContract(data: IContract): Observable<IResponse<IContract>> {
    return this.http.post<IResponse<IContract>>(
      `${apiEndpoint.ContractEndpoint.addcontract}`,
      data
    );
  }
//Update existing contract
  UpdateContract(data:IContract): Observable<IResponse<IContract>> {
    return this.http.put<IResponse<IContract>>(
      `${apiEndpoint.ContractEndpoint.updatecontract}`,
      data
    );
  }
//Delete existing contract
  DeleteContract(id:string): Observable<IResponse<IContract>> {
    return this.http.delete<IResponse<IContract>>(
      `${apiEndpoint.ContractEndpoint.updatecontract}/${id}`
    );
  }
//Get a contract by id
  GetContractById(id:string): Observable<IResponse<IContract>> {
    return this.http.get<IResponse<IContract>>(
      `${apiEndpoint.ContractEndpoint.updatecontract}/${id}`
    );
  }
  
}
