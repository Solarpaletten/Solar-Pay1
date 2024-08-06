import { Injectable } from '@angular/core';
import{ToastrService} from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {

  constructor(private toastr:ToastrService) { }
  
  Error(data:string){
    this.toastr.error(data, 'Major Error', {
      timeOut: 3000,
    });
  }

  Success(data:string){
    this.toastr.success(data,"Success");
  }

  Info(data:string){
    this.toastr.info(data,"Info");
  }
}
