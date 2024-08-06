import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponse } from '../../Models/IUser';
import { apiEndpoint } from '../../constrants/constants';
import { IRFQ } from '../../Models/IRFQ';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RfqService {

  constructor(private http:HttpClient) { }
  //Get All RFQs
  GetRFQs(): Observable<IResponse<IRFQ[]>> {
    return this.http.get<IResponse<IRFQ[]>>(
      `${apiEndpoint.RFQEndpoint.getRFQs}`
    );
  }
//Insert new RFQ
  AddRFQ(data: IRFQ): Observable<IResponse<IRFQ>> {
    return this.http.post<IResponse<IRFQ>>(
      `${apiEndpoint.RFQEndpoint.addRFQ}`,
      data
    );
  }
//Update existing RFQ
  UpdateRFQ(data:IRFQ): Observable<IResponse<IRFQ>> {
    return this.http.put<IResponse<IRFQ>>(
      `${apiEndpoint.RFQEndpoint.updateRFQ}`,
      data
    );
  }
//Delete existing RFQ
  DeleteRFQ(id:string): Observable<IResponse<IRFQ>> {
    return this.http.delete<IResponse<IRFQ>>(
      `${apiEndpoint.RFQEndpoint.updateRFQ}/${id}`
    );
  }
//Get a RFQ by id
  GetRFQById(id:string): Observable<IResponse<IRFQ>> {
    return this.http.get<IResponse<IRFQ>>(
      `${apiEndpoint.RFQEndpoint.updateRFQ}/${id}`
    );
  }
}
