export interface IContract{
    id: string,
    createdDate:Date,
    updatedDate: Date,
    name: string,
    fullform: string,
    attachment: string,
    limit: number,
    facilities: string,
    doc:File,
    startDate:Date,
    endDate:Date
}

export interface IClient{
    id: string,
  createdDate: Date,
  updatedDate: Date,
  firstName: string,
  lastName: string,
  mobileNo: string,
  email: string,
  attachment: string,
  address: string,
  doc:File,
  contractId:string
}

export interface IContractLogisticRate{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    rangeFrom: number,
    rangeTo: number,
    logisticCharges: number,
    description: string,
    contractId:string
}

export interface IContractQuoteRate{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    rangeFrom: number,
    rangeTo: number,
    noOfQuotes: number,
    description: string,
    contractId: string,
}

export interface IRFQ{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    rfqNumber: string,
    periority: number,
    requestorName: string,
    requestorEmail: string,
    requestorPhone: string,
    clientId: string,
    sla:Date,
    docNo:string,
    title:string,
    contract:IContract,
    client:IClient,
    exchangeRates:IExchangeRate[],
    products:IProduct[]
}

export interface IProduct{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    name: string,
    doc:File,
    imageUrl: string,
    description: string,
    quantity:number,
    reference: string,
    rfqId: string,
    quotes:IQuote[]
}

export interface IExchangeRate{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    currency: string,
    actualExchange: number,
    additional: number,
    totalExchange: number,
    rfqId: string,
    
}

export interface IQuote{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    unitPrice: number,
    packaging: number,
    shippingCost: number,
    shippingDelivery: number,
    bankCharges: number,
    vat: number,
    jic: number,
    profit: number,
    unitPriceToClient: number,
    productId: string,
    quoteCurrency:string,
    supplier:ISupplier,
}

export interface ISupplier{
    id: string,
    createdDate: Date,
    updatedDate: Date,
    firstName: string,
    lastName: string,
    email: string,
    phone: string,
    fax: string,
    address: string,
    creditLimit: number,
    paymentMethod: string,
    website: string,
    taxationNo: string,
    imageUrl: string,
    description: string
}

export interface CurrencyDropDown {
    code: string
    text: string
}
