import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ICustomer } from '../../../core/Models/ICustomer';
import { apiEndpoint } from '../../../core/constrants/constants';
import { CustomerService } from '../../../core/Services/Customer/customer.service';
import { NotifyService } from '../../../core/Services/Notify/notify.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-allcustomers',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './allcustomers.component.html',
  styleUrl: './allcustomers.component.css'
})
export class AllcustomersComponent implements OnInit{
  customers?:ICustomer[];
  apiurl:any=apiEndpoint.ApiURL;
  constructor(private customerService: CustomerService,
    private notify: NotifyService){}
  GetCustomers() {
    this.customerService.GetCustomers().subscribe({
      next: (response) => {
        if (response.status) {
          this.customers = response.data;
        } else {
          this.notify.Error("Something wrong while retrieving contracts.")
        }
      },
    });
  }
ngOnInit(): void {
  this.GetCustomers();
}
}
