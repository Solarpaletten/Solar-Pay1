import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { AuthComponent } from './Layouts/auth/auth.component';
import { guestGuard } from './core/gaurds/guest.gaurd';
import { AuthGaurds } from './core/gaurds/authgaurds.gaurd';
import { MainComponent } from './Layouts/main/main.component';
import path from 'path';
import { flush } from '@angular/core/testing';
import { AddcustomerComponent } from './Components/Customers/addcustomer/addcustomer.component';
import { AllcustomersComponent } from './Components/Customers/allcustomers/allcustomers.component';
import { RegisterComponent } from './Components/register/register.component';

export const routes: Routes = [

  //Auth Routes

  {
    path: '',
    component: AuthComponent,
    children: [
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      {path:'register',component:RegisterComponent},
      {
        path: '',
        loadChildren: () =>
          import('./Layouts/auth/auth.module').then((m) => m.AuthModule),
      },
    ],
  },

  //Dashboard Routes

  {
    path: '',
    component: MainComponent,
    canActivate: [AuthGaurds],
    children: [
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
      {path:'addcustomer/:id',component:AddcustomerComponent},
      {path:'allcustomers',component:AllcustomersComponent},
      {
        path: 'dashboard',
        loadChildren: () =>
          import('./Layouts/main/main.module').then((m) => m.MainModule),
      },
    ],
  },
];
