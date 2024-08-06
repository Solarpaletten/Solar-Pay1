import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from '../../Models/IUser';
import { apiEndpoint } from '../../constrants/constants';
import { IContractLogisticRate } from '../../Models/IRFQ';

@Injectable({
  providedIn: 'root'
})
export class ContractLogisticRateService {

  constructor(private http:HttpClient) { }
  //Get All ContractLogisticRates
  GetContractLogisticRates(): Observable<IResponse<IContractLogisticRate[]>> {
    return this.http.get<IResponse<IContractLogisticRate[]>>(
      `${apiEndpoint.ContractLogisticRateEndpoint.getcontractlogisticrates}`
    );
  }
//Insert new ContractLogisticRate
  AddContractLogisticRate(data: IContractLogisticRate): Observable<IResponse<IContractLogisticRate>> {
    return this.http.post<IResponse<IContractLogisticRate>>(
      `${apiEndpoint.ContractLogisticRateEndpoint.addcontractlogisticrate}`,
      data
    );
  }
//Update existing ContractLogisticRate
  UpdateContractLogisticRate(data:IContractLogisticRate): Observable<IResponse<IContractLogisticRate>> {
    return this.http.put<IResponse<IContractLogisticRate>>(
      `${apiEndpoint.ContractLogisticRateEndpoint.updatecontractlogisticrate}`,
      data
    );
  }
//Delete existing ContractLogisticRate
  DeleteContractLogisticRate(id:string): Observable<IResponse<IContractLogisticRate>> {
    return this.http.delete<IResponse<IContractLogisticRate>>(
      `${apiEndpoint.ContractLogisticRateEndpoint.deletecontractlogisticrate}/${id}`
    );
  }
//Get a ContractLogisticRate by id
  GetContractLogisticRateById(id:string): Observable<IResponse<IContractLogisticRate>> {
    return this.http.get<IResponse<IContractLogisticRate>>(
      `${apiEndpoint.ContractLogisticRateEndpoint.getcontractlogisticratebyid}/${id}`
    );
  }
}
