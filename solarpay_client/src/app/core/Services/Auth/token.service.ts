import { afterNextRender, inject, Injectable } from '@angular/core';
import { constants } from '../../constrants/constants';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { BrowserStorageService } from './browserstorage.service';
import { BrowserStorageServerService } from './browserstorageservice.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  isAuthentication: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );
  constructor() {
    const token = this.getToken();
    if (token) {
      this.updateToken(true);
    }
  }

  updateToken(status: boolean) {
    this.isAuthentication.next(status);
  }

  setToken(token: string) {
    this.updateToken(true);
    sessionStorage.setItem(constants.CURRENT_TOKEN,token);
  }

  getToken() {
    return sessionStorage.getItem(constants.CURRENT_TOKEN);
  }

  removeToken() {
    this.updateToken(false);
    sessionStorage.removeItem(constants.CURRENT_TOKEN);
  }
}
