import { Injectable } from '@angular/core';
import { IResponse } from '../../Models/IUser';
import { Observable } from 'rxjs';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { ISupplier } from '../../Models/IRFQ';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http:HttpClient) { }
  //Get All Suppliers
  GetSuppliers(): Observable<IResponse<ISupplier[]>> {
    return this.http.get<IResponse<ISupplier[]>>(
      `${apiEndpoint.SupplierEndpoint.getsuppliers}`
    );
  }
//Insert new Supplier
  AddSupplier(data: ISupplier): Observable<IResponse<ISupplier>> {
    return this.http.post<IResponse<ISupplier>>(
      `${apiEndpoint.SupplierEndpoint.addsupplier}`,
      data
    );
  }
//Update existing Supplier
  UpdateSupplier(data:ISupplier): Observable<IResponse<ISupplier>> {
    return this.http.put<IResponse<ISupplier>>(
      `${apiEndpoint.SupplierEndpoint.updatesupplier}`,
      data
    );
  }
//Delete existing Supplier
  DeleteSupplier(id:string): Observable<IResponse<ISupplier>> {
    return this.http.delete<IResponse<ISupplier>>(
      `${apiEndpoint.SupplierEndpoint.deletesupplier}/${id}`
    );
  }
//Get a Supplier by id
  GetSupplierById(id:string): Observable<IResponse<ISupplier>> {
    return this.http.get<IResponse<ISupplier>>(
      `${apiEndpoint.SupplierEndpoint.getsupplierbyid}/${id}`
    );
  }
}
