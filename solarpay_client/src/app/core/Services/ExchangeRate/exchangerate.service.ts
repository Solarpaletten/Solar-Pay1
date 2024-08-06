import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponse } from '../../Models/IUser';
import { Observable } from 'rxjs';
import { apiEndpoint } from '../../constrants/constants';
import { IExchangeRate } from '../../Models/IRFQ';

@Injectable({
  providedIn: 'root'
})
export class ExchangerateService {

  constructor(private http: HttpClient) { }
  //Get All ExchangeRates
  GetExchangeRates(): Observable<IResponse<IExchangeRate[]>> {
    return this.http.get<IResponse<IExchangeRate[]>>(
      `${apiEndpoint.ExchangeRateEndpoint.getexchangerates}`
    );
  }
//Insert new ExchangeRate
  AddExchangeRate(data: IExchangeRate): Observable<IResponse<IExchangeRate>> {
    return this.http.post<IResponse<IExchangeRate>>(
      `${apiEndpoint.ExchangeRateEndpoint.addexchangerate}`,
      data
    );
  }
//Update existing ExchangeRate
  UpdateExchangeRate(data:IExchangeRate): Observable<IResponse<IExchangeRate>> {
    return this.http.put<IResponse<IExchangeRate>>(
      `${apiEndpoint.ExchangeRateEndpoint.updateexchangerate}`,
      data
    );
  }
//Delete existing ExchangeRate
  DeleteExchangeRate(id:string): Observable<IResponse<IExchangeRate>> {
    return this.http.delete<IResponse<IExchangeRate>>(
      `${apiEndpoint.ExchangeRateEndpoint.deleteexchangerate}/${id}`
    );
  }
  //Get a ExchangeRate by id
    GetExchangeRateById(id:string): Observable<IResponse<IExchangeRate>> {
      return this.http.get<IResponse<IExchangeRate>>(
        `${apiEndpoint.ExchangeRateEndpoint.getexchangeratebyid}/${id}`
      );
    }
    //Get a ExchangeRate by id
      GetExchangeRateLived(currency:string): Observable<any> {
        return this.http.get<any>(
          `${apiEndpoint.ExchangeRateEndpoint.getexchangeratelive}/${currency}`
        );
      }
}
