
export interface ICustomer {
    id: string,
      title: string,
      abbreviation: string,
      isActive: boolean,
      juridical: boolean,
      debt: boolean,
      foreigner: string,
      code: string,
      activityNumber: string,
      vatCode: string,
      website: string,
      tel: string,
      postOffice: string,
      contactInfo: string,
      notes: string,
      payThrough: string,
      eori: string,
      fax: string,
      foreign: string,
      dob: Date,
      vaTrate: number,
      creditAmount: number,
      registrationDate:Date,
      banks?:IBank[],
      addresses?:IAddress[]
}

export interface IAddress{
  id: string,
      location: string,
      city: string,
      country: string,
      postalCode: string,
      employee: string,
      registration: false,
      correspondence: false,
      loading: false,
      unloading: false,
      divid: false,
      customerId?:string
}

export interface IBank{
  id:string,
  accountNo: string,
  bankName: string,
  bankCode: string,
  swiftCode: string,
  isMain: false,
  customerId?:string
}