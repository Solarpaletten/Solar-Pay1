import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from '../../Models/IUser';
import { apiEndpoint } from '../../constrants/constants';
import { IProduct } from '../../Models/IRFQ';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  //Get All Products
  GetProducts(): Observable<IResponse<IProduct[]>> {
    return this.http.get<IResponse<IProduct[]>>(
      `${apiEndpoint.ProductEndpoint.getproducts}`
    );
  }
//Insert new Product
  AddProduct(data: IProduct): Observable<IResponse<IProduct>> {
    return this.http.post<IResponse<IProduct>>(
      `${apiEndpoint.ProductEndpoint.addproduct}`,
      data
    );
  }
//Update existing Product
  UpdateProduct(data:IProduct): Observable<IResponse<IProduct>> {
    return this.http.put<IResponse<IProduct>>(
      `${apiEndpoint.ProductEndpoint.updateproduct}`,
      data
    );
  }
//Delete existing Product
  DeleteProduct(id:string): Observable<IResponse<IProduct>> {
    return this.http.delete<IResponse<IProduct>>(
      `${apiEndpoint.ProductEndpoint.deleteproduct}/${id}`
    );
  }
//Get a Product by id
  GetProductById(id:string): Observable<IResponse<IProduct>> {
    return this.http.get<IResponse<IProduct>>(
      `${apiEndpoint.ProductEndpoint.getproductbyid}/${id}`
    );
  }
}
