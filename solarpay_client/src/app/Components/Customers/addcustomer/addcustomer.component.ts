import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ContractService } from '../../../core/Services/Contract/contract.service';
import { NotifyService } from '../../../core/Services/Notify/notify.service';
import { IClient, IContract } from '../../../core/Models/IRFQ';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { title } from 'process';
import { CustomerService } from '../../../core/Services/Customer/customer.service';
import { Router } from '@angular/router';
import { CustomerAddressService } from '../../../core/Services/CustomerAddress/customeraddress.service';
import { CustomerbankService } from '../../../core/Services/CustomerBank/customerbank.service';
import { IAddress, IBank, ICustomer } from '../../../core/Models/ICustomer';

@Component({
  selector: 'app-addcustomer',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './addcustomer.component.html',
  styleUrl: './addcustomer.component.css',
})
export class AddcustomerComponent {

  constructor(
    private addressService: CustomerAddressService,
    private notify: NotifyService,
    private bankService: CustomerbankService,
    private customerService: CustomerService, private router:Router,
    private activedRoute: ActivatedRoute
  ) {
  
    //Defined Customer Form
    this.customerForm = new FormGroup({
      id:new FormControl(''),
      title: new FormControl('', Validators.required),
      abbreviation: new FormControl('', Validators.required),
      isActive: new FormControl('false'),
      juridical: new FormControl('false'),
      debt: new FormControl('false'),
      foreigner: new FormControl('', Validators.required),
      code: new FormControl('', Validators.required),
      activityNumber: new FormControl('', Validators.required),
      vatCode: new FormControl('', Validators.required),
      website: new FormControl('', Validators.required),
      tel: new FormControl('', Validators.required),
      postOffice: new FormControl('', Validators.required),
      contactInfo: new FormControl('', Validators.required),
      notes: new FormControl('', Validators.required),
      payThrough: new FormControl('', Validators.required),
      eori: new FormControl('', Validators.required),
      fax: new FormControl('', Validators.required),
      foreign: new FormControl('', Validators.required),
      dob: new FormControl(null, Validators.required),
      vaTrate: new FormControl('', Validators.required),
      creditAmount: new FormControl('', Validators.required),
    });
    //Defined Bank Form
this.bankForm=new FormGroup({
  accountNo: new FormControl('', Validators.required),
  bankName: new FormControl('', Validators.required),
  bankCode: new FormControl('', Validators.required),
  swiftCode: new FormControl('', Validators.required),
  isMain: new FormControl('false'),
  customerId:new FormControl(this.id)
});
    //Defined Address Form
    this.addressForm=new FormGroup({
      location: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      postalCode: new FormControl('', Validators.required),
      employee: new FormControl('', Validators.required),
      registration: new FormControl('false'),
      correspondence: new FormControl('false'),
      loading: new FormControl('false'),
      unloading: new FormControl('false'),
      divid: new FormControl('false'),
      customerId:new FormControl(this.id)
    });
  }
  customerForm: FormGroup;
  addressForm:FormGroup;
  bankForm:FormGroup;
  banks?:IBank[];
  addresses?:IAddress[];
  id?:string;
  customer?:ICustomer;
  //#region customer form fields
  get customerId() {
    return this.customerForm.get('id') as FormControl;
  }
  get title() {
    return this.customerForm.get('title') as FormControl;
  }
  get abbreviation() {
    return this.customerForm.get('abbreviation') as FormControl;
  }
  get isActive() {
    return this.customerForm.get('isActive') as FormControl;
  }
  get juridical() {
    return this.customerForm.get('juridical') as FormControl;
  }
  get debt() {
    return this.customerForm.get('debt') as FormControl;
  }
  get foreigner() {
    return this.customerForm.get('foreigner') as FormControl;
  }
  get code() {
    return this.customerForm.get('code') as FormControl;
  }
  get activityNumber() {
    return this.customerForm.get('activityNumber') as FormControl;
  }
  get vatCode() {
    return this.customerForm.get('vatCode') as FormControl;
  }
  get website() {
    return this.customerForm.get('website') as FormControl;
  }
  get tel() {
    return this.customerForm.get('tel') as FormControl;
  }
  get postOffice() {
    return this.customerForm.get('postOffice') as FormControl;
  }
  get contactInfo() {
    return this.customerForm.get('contactInfo') as FormControl;
  }
  get notes() {
    return this.customerForm.get('notes') as FormControl;
  }
  get payThrough() {
    return this.customerForm.get('payThrough') as FormControl;
  }
  get eori() {
    return this.customerForm.get('eori') as FormControl;
  }
  get fax() {
    return this.customerForm.get('fax') as FormControl;
  }
  get foreign() {
    return this.customerForm.get('foreign') as FormControl;
  }
  get dob() {
    return this.customerForm.get('dob') as FormControl;
  }
  get vaTrate() {
    return this.customerForm.get('vaTrate') as FormControl;
  }
  get creditAmount() {
    return this.customerForm.get('creditAmount') as FormControl;
  }
  //#endregion
//#region bank form fields
get accountNo() {
  return this.bankForm.get('accountNo') as FormControl;
}
get bankName() {
  return this.bankForm.get('bankName') as FormControl;
}
get bankCode() {
  return this.bankForm.get('bankCode') as FormControl;
}
get swiftCode() {
  return this.bankForm.get('swiftCode') as FormControl;
}
get isMain() {
  return this.bankForm.get('isMain') as FormControl;
}
get bankCustomerId() {
  return this.bankForm.get('customerId') as FormControl;
}
//#endregion
//#region address form fields

get location() {
  return this.addressForm.get('location') as FormControl;
}
get city() {
  return this.addressForm.get('city') as FormControl;
}
get country() {
  return this.addressForm.get('country') as FormControl;
}
get postalCode() {
  return this.addressForm.get('postalCode') as FormControl;
}
get employee() {
  return this.addressForm.get('employee') as FormControl;
}
get registration() {
  return this.addressForm.get('registration') as FormControl;
}
get correspondence() {
  return this.addressForm.get('correspondence') as FormControl;
}
get loading() {
  return this.addressForm.get('loading') as FormControl;
}
get unloading() {
  return this.addressForm.get('unloading') as FormControl;
}
get divid() {
  return this.addressForm.get('divid') as FormControl;
}
get addressCustomerId() {
  return this.addressForm.get('customerId') as FormControl;
}
//#endregion



  OnSubmit() {
    if (this.customerForm.valid) {
      this.customerId.setValue(this.id);
      this.customerService.AddCustomer(this.customerForm.value).subscribe({
        next: (response) => {
          if (response.status) {
            this.notify.Success(response.message);
            this.router.navigate(['/allcustomers']);
          } else {
            this.notify.Error(response.message);
          }
        },
      });
    }
  }

  SaveAddress() {
    if (this.id==null) {
      this.notify.Error("Please fill customer information.");
      this.router.navigate(['/addcustomer/']);
     }
    if (this.addressForm.valid) {
      this.addressCustomerId.setValue(this.id);
      this.addressService.AddCustomerAddress(this.addressForm.value).subscribe({
        next: (response) => {
          if (response.status) {
            this.notify.Success(response.message);
            this.router.navigate(['/addcustomer']);
          } else {
            this.notify.Error(response.message);
          }
        },
      });
    }
    }
    SaveBankInfo() {
      if (this.id==null) {
        this.notify.Error("Please fill customer information.");
        this.router.navigate(['/addcustomer/']);
       }
      if (this.bankForm.valid) {
        alert("Valid form.");
        this.bankCustomerId.setValue(this.id);
        this.bankService.AddBank(this.bankForm.value).subscribe({
          next: (response) => {
            if (response.status) {
              this.notify.Success(response.message);
              this.router.navigate(['/addCustomer']);
            } else {
              this.notify.Error(response.message);
            }
          },
        });
      }
    }

    GetAllBanks(){
      this.bankService.GetBanks().subscribe({
        next: (response) => {
          if (response.status) {
            this.banks = response.data;
          } else {
            this.notify.Error("Something wrong while retrieving contracts.")
          }
        },
      });
    }

    GetAllAddresses(){
      this.addressService.GetCustomerAddresses().subscribe({
        next: (response) => {
          if (response.status) {
            this.addresses = response.data;
          } else {
            this.notify.Error("Something wrong while retrieving contracts.")
          }
        },
      });
    }
    GetCustomerDetails(id:string){
      this.customerService.GetCustomerById(id).subscribe({
        next: (response) => {
          if (response.status) {
            this.customer = response.data;
            this.customerForm.patchValue(response.data);
            this.banks=response.data.banks;
            this.addresses=response.data.addresses;
            
          } else {
            this.notify.Error(response.message);
          }
        },
      });console.log(this.customer);
    }
  ngOnInit(): void {
    this.id = this.activedRoute.snapshot.params['id'];
    this.GetCustomerDetails(this.id||'');
  }
}
