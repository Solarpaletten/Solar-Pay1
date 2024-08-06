import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../../Components/home/home.component';
import { AddcustomerComponent } from '../../Components/Customers/addcustomer/addcustomer.component';
import { AllcustomersComponent } from '../../Components/Customers/allcustomers/allcustomers.component';
import { MainComponent } from './main.component';

const routes: Routes = [
  {path:'',
  component:HomeComponent,
  children:[
  {path:'dashboard',component:HomeComponent},
  {path:'addcustomer',component:AddcustomerComponent},
  {path:'allcustomers',component:AllcustomersComponent}
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
