import { Injectable } from '@angular/core';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IClient } from '../../Models/IRFQ';
import { IResponse } from '../../Models/IUser';
import { IClientContractDTO } from '../../Models/IDTO';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }
  //Get All Clients
  GetClients(): Observable<IResponse<IClient[]>> {
    return this.http.get<IResponse<IClient[]>>(
      `${apiEndpoint.ClientEndpoint.getclients}`
    );
  }
   //Get Contracts By client Id
   GetClientContractsById(Id:string): Observable<IResponse<IClientContractDTO[]>> {
    return this.http.get<IResponse<IClientContractDTO[]>>(
      `${apiEndpoint.ClientEndpoint.getclientcontracts}/${Id}`
    );
  }
//Insert new client
  AddClient(data: IClient): Observable<IResponse<IClient>> {
    return this.http.post<IResponse<IClient>>(
      `${apiEndpoint.ClientEndpoint.addclient}`,
      data
    );
  }
//Update existing client
  UpdateClient(data:IClient): Observable<IResponse<IClient>> {
    return this.http.put<IResponse<IClient>>(
      `${apiEndpoint.ClientEndpoint.updateclient}`,
      data
    );
  }
//Delete existing client
  DeleteClient(id:string): Observable<IResponse<IClient>> {
    return this.http.delete<IResponse<IClient>>(
      `${apiEndpoint.ClientEndpoint.deleteclient}/${id}`
    );
  }
//Get a client by id
  GetClientById(id:string): Observable<IResponse<IClient>> {
    return this.http.get<IResponse<IClient>>(
      `${apiEndpoint.ClientEndpoint.getclientbyid}/${id}`
    );
  }
}
