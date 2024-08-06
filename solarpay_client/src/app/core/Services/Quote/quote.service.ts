import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from '../../Models/IUser';
import { IQuote } from '../../Models/IRFQ';
import { apiEndpoint } from '../../constrants/constants';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  constructor(private http:HttpClient) { }
  //Get All Quotes
  GetQuotes(): Observable<IResponse<IQuote[]>> {
    return this.http.get<IResponse<IQuote[]>>(
      `${apiEndpoint.QuoteEndpoint.getquotes}`
    );
  }
//Insert new Quote
  AddQuote(data: IQuote): Observable<IResponse<IQuote>> {
    return this.http.post<IResponse<IQuote>>(
      `${apiEndpoint.QuoteEndpoint.addquote}`,
      data
    );
  }
//Update existing Quote
  UpdateQuote(data:IQuote): Observable<IResponse<IQuote>> {
    return this.http.put<IResponse<IQuote>>(
      `${apiEndpoint.QuoteEndpoint.updatequote}`,
      data
    );
  }
//Delete existing Quote
  DeleteQuote(id:string): Observable<IResponse<IQuote>> {
    return this.http.delete<IResponse<IQuote>>(
      `${apiEndpoint.QuoteEndpoint.deletequote}/${id}`
    );
  }
//Get a Quote by id
  GetQuoteById(id:string): Observable<IResponse<IQuote>> {
    return this.http.get<IResponse<IQuote>>(
      `${apiEndpoint.QuoteEndpoint.getquotebyid}/${id}`
    );
  }
}
