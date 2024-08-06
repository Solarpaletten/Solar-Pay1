import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Apiresponsemodel } from '../../Models/apiresponsemodel';
import { TokenService } from './token.service';
import { apiEndpoint } from '../../constrants/constants';
import { IResponse, IRole, IUser } from '../../Models/IUser';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthServiceService {
  constructor(private http: HttpClient, private tokenService: TokenService,private router: Router) {}

  onLogin(data: IUser):Observable<IResponse<IUser>> {
    return this.http.post<IResponse<IUser>>(`${apiEndpoint.AuthEndpoint.login}`, data);
  }
  // .pipe(
  //   map((response: Apiresponsemodel) => {
  //     if (response) {
  //       if(response.status){
  //       this.tokenService.setToken(response.data.jwt);
  //       console.log(response.data);
  //       }
  //     }
  //     return response;
  //   })
  // );

  onLogout() {
    this.http.get(`${apiEndpoint.AuthEndpoint.logout}`,).subscribe({
      next: (response) => {
        this.tokenService.removeToken();
        this.router.navigate(['']);
      },
    });
  }

  GetRoles(): Observable<IResponse<IRole[]>> {
    return this.http.get<IResponse<IRole[]>>(
      `${apiEndpoint.AuthEndpoint.getroles}`
    );
  }

  OnRegister(data: IUser): Observable<IResponse<IUser>> {
    return this.http.post<IResponse<IUser>>(
      `${apiEndpoint.AuthEndpoint.register}`,
      data
    );
  }
}
