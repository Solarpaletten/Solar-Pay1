import { AfterViewInit, Component, OnInit, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
declare var $:any;

export type MenuItem={
  icon:String,
  label:String,
  route?:String,
  SubMenu?:MenuItem[]
}


@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})

export class SidebarComponent implements AfterViewInit{
 
  constructor(){}
menuItems:MenuItem[]=[
  {
    icon:'fa fa-tachometer',
    label:'Dashboard',
    route:'/dashboard'
  },
  {
    icon:'fa fa-user',
    label:'Customers',
    SubMenu:[
      {icon:'fa fa-user',label:'Add Customer',route:'/addcustomer'},
      {icon:'fa fa-user',label:'All Customer',route:'/allcustomers'}
  ]
  },
  {
    icon:'fa fa-bank',
    label:'Banks'
  },
];

ngAfterViewInit(): void {
  // Initialize MetisMenu
  $('#left-sidebar').metisMenu();
}
}
