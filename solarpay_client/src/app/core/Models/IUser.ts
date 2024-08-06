export interface IUser {
  id: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: true;
  passwordHash: string;
  securityStamp: string;
  concurrencyStamp: string;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd: Date;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  firstName: string;
  lastName: string;
  jwt: string;
  isApproved: boolean;
  roleid:string;
  rolename:string;
}

export interface IRole {
  id: string;
  name: string;
  normalizedName: string;
  concurrencyStamp: string;
}

export interface IResponse<T>{
    data:T,
    message:string,
    status: boolean
}