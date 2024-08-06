import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse, IRole, IUser } from '../../Models/IUser';
import { apiEndpoint } from '../../constrants/constants';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient,private router: Router) { }

  AddUser(data: IUser):Observable<IResponse<IUser>> {
    return this.http.post<IResponse<IUser>>(`${apiEndpoint.AuthEndpoint.register}`, data);
  }

  AddRole(data: IRole):Observable<IResponse<IRole>> {
    return this.http.post<IResponse<IRole>>(`${apiEndpoint.UserEndpoint.addrole}`, data);
  }

  onLogout() {
    this.http.get(`${apiEndpoint.AuthEndpoint.logout}`,).subscribe({
      next: (response) => {
        //this.tokenService.removeToken();
        this.router.navigate(['']);
      },
    });
  }

  GetUsers(): Observable<IResponse<IUser[]>> {
    return this.http.get<IResponse<IUser[]>>(
      `${apiEndpoint.UserEndpoint.getusers}`
    );
  }

  OnRegister(data: IUser): Observable<IResponse<IUser>> {
    return this.http.post<IResponse<IUser>>(
      `${apiEndpoint.AuthEndpoint.register}`,
      data
    );
  }
}
